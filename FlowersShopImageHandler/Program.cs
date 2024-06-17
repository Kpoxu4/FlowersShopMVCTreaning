using FlowersShopImageHandler;


var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
var imageProcessor = new ImageProcessor(Path.Combine(baseDirectory, PathFolder("test", "output", "small")), Path.Combine(baseDirectory, PathFolder("test", "output", "large")));
var folderWatcher = new FolderWatcher(imageProcessor, Path.Combine(baseDirectory, PathFolder("test", "watch")));

folderWatcher.StartWatching();

static string PathFolder(params string[] paths)
{
   return Path.Combine(paths);
}