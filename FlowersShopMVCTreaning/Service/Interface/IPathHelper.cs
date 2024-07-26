namespace FlowersShopMVCTraining.Service.Interface
{
    public interface IPathHelper
    {
        string GetFolderPath(string pathToFolder);
        string GetPathByFolder(string pathToFolder, string fileName);
    }
}