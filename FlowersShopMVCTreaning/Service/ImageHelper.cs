using FlowersShopMVCTraining.Service.Interface;

namespace FlowersShopMVCTraining.Service
{
    public class ImageHelper : IImageHelper
    {
        private IPathHelper _pathHelper;

        public ImageHelper(IPathHelper pathHelper)
        {
            _pathHelper = pathHelper;
        }
        public void RenameImage(string newName, string oldName)
        {

            var imageOldFileFileLarge = _pathHelper.GetPathByFolder("img\\output\\large", oldName + ".jpg");
            var imageOldFileFileSmall = _pathHelper.GetPathByFolder("img\\output\\small", oldName + ".jpg");

            FileInfo fileInfoLarge = new FileInfo(imageOldFileFileLarge);
            FileInfo fileInfoSmall = new FileInfo(imageOldFileFileSmall);

            var newFilePathLarge = Path.Combine(fileInfoLarge.Directory.FullName, newName + ".jpg");
            var newFilePathSmall = Path.Combine(fileInfoSmall.Directory.FullName, newName + ".jpg");

            fileInfoLarge.MoveTo(newFilePathLarge);
            fileInfoSmall.MoveTo(newFilePathSmall);
        }
        public void SaveImageToFolder(IFormFile file, string imageName)
        {
            string fileName = file.FileName;
            var extension = Path.GetExtension(fileName);
            var path = _pathHelper.GetPathByFolder("img\\watch", imageName + extension);
            using (var fs = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(fs);
            }
        }
    }
}
