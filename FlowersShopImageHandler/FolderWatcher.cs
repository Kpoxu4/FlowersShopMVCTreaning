namespace FlowersShopImageHandler
{
    public class FolderWatcher
    {
        private readonly string _watchPath;
        private readonly ImageProcessor _imageProcessor;
        private FileSystemWatcher _watcher;

        public FolderWatcher(ImageProcessor imageProcessor, string watchPath)
        {
            _imageProcessor = imageProcessor;
            _watchPath = watchPath;
            CreateWatchDirectories();
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
            Task.Run(() => _imageProcessor.ProcessImageAsync(e.FullPath));
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
