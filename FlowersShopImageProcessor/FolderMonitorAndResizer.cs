using SixLabors.ImageSharp;
using System.Collections.Concurrent;

namespace FlowersShopMVCTraining.ImageProcessor
{
    public class FolderMonitorAndResizer
    {
        private readonly string _watchPath;
        private readonly ImageProcessor _imageProcessor;
        private FileSystemWatcher _watcher;
        private readonly int _delay;
        private readonly ConcurrentQueue<string> _fileQueue = new ConcurrentQueue<string>();
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);
        private const int MaxRetryCount = 3;

        public FolderMonitorAndResizer(string watchPath, string outputPathSmall,
                                        string outputPathLarge, int smallWidth,
                                        int smallHeight, int largeWidth,
                                        int largeHeight, int delay)
        {
            var smallSize = new Size(smallWidth, smallHeight);
            var largeSize = new Size(largeWidth, largeHeight);
            _delay = delay;
            _imageProcessor = new ImageProcessor(outputPathSmall, outputPathLarge, smallSize, largeSize, delay);
            _watchPath = watchPath;
            CreateWatchDirectories();
            LoadExistingFiles();
        }

        public void StartWatching()
        {
            _watcher = new FileSystemWatcher
            {
                Path = _watchPath,
                Filter = "*.*",
                EnableRaisingEvents = true
            };

            _watcher.Created += OnChanged;

            Console.WriteLine($"Watching for changes in {_watchPath}. Press Ctrl+C to exit.");

            while (true)
            {
                System.Threading.Thread.Sleep(1000);
            }
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            _fileQueue.Enqueue(e.FullPath);
            ProcessQueue();
        }

        private async void ProcessQueue()
        {
            await _semaphore.WaitAsync();
            try
            {
                while (_fileQueue.TryDequeue(out var filePath))
                {
                    await ProcessFileWithRetries(filePath);
                }
            }
            finally
            {
                _semaphore.Release();
            }
        }

        private async Task ProcessFileWithRetries(string filePath)
        {
            int retryCount = 0;
            bool success = false;

            while (retryCount < MaxRetryCount && !success)
            {
                try
                {
                    await _imageProcessor.ProcessImageAsync(filePath);
                    success = true;
                }
                catch (Exception ex)
                {
                    retryCount++;
                    Console.WriteLine($"Error processing file {filePath}. Attempt {retryCount} of {MaxRetryCount}. Error: {ex.Message}");
                    await Task.Delay(1000); // Задержка перед повторной попыткой
                }
            }

            if (!success)
            {
                Console.WriteLine($"Failed to process file {filePath} after {MaxRetryCount} attempts. Adding back to queue.");
                _fileQueue.Enqueue(filePath);
            }
        }

        private void LoadExistingFiles()
        {
            var files = Directory.GetFiles(_watchPath);
            foreach (var file in files)
            {
                _fileQueue.Enqueue(file);
            }
            ProcessQueue();
        }

        private void CreateWatchDirectories()
        {
            if (!Directory.Exists(_watchPath))
            {
                Directory.CreateDirectory(_watchPath);
            }
        }
    }
}
