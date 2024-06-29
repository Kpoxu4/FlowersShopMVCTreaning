using FlowersShopMVCTraining.ImageProcessor;
using System.Drawing;

namespace FlowersShopMVCTraining.Service
{
    public class ImageProcessingService : BackgroundService
    {
        private const int SMALL_WIDTH = 266;
        private const int SMALL_HIGHT= 245;
        private const int LARGE_WIDTH = 459;
        private const int LARGE_HIGHT = 459;
        private const int DELAY = 1;
        private readonly FolderMonitorAndResizer _folderWatcher;

        public ImageProcessingService(IWebHostEnvironment webHostEnvironment)
        {
            var baseDirectory = webHostEnvironment.WebRootPath;
            var watchPath = Path.Combine(baseDirectory, "img", "watch");
            var outputPathSmall = Path.Combine(baseDirectory, "img", "output", "small");
            var outputPathLarge = Path.Combine(baseDirectory, "img", "output", "large");
       
            _folderWatcher = new FolderMonitorAndResizer(watchPath, outputPathSmall, outputPathLarge, SMALL_WIDTH, SMALL_HIGHT, LARGE_WIDTH, LARGE_HIGHT, DELAY);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            return Task.Run(() => _folderWatcher.StartWatching(), stoppingToken);
        }
    }
}
