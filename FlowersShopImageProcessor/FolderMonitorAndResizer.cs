﻿using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Formats.Jpeg;

namespace FlowersShopMVCTraining.ImageProcessor
{
    public class FolderMonitorAndResizer
    {
        private readonly string _watchPath;
        private readonly ImageProcessor _imageProcessor;
        private FileSystemWatcher _watcher;
        private int _delay;


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
