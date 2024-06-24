namespace FlowersShopMVCTraining.Service
{
    public class PathHelper
    {
        private IWebHostEnvironment _webHostEnvironment;

        public PathHelper(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public string GetPathByFolder(string pathToFolder, string fileName)
        {
            var path = Path.Combine(_webHostEnvironment.WebRootPath, pathToFolder, fileName);
            return path;
        }
        public string GetFolderPath(string pathToFolder)
        {
            var path = Path.Combine(_webHostEnvironment.WebRootPath, pathToFolder);
            return path;
        }
        
    }
}
