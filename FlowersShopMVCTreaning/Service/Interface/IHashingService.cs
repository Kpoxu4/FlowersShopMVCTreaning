namespace FlowersShopMVCTraining.Service.Interface
{
    public interface IHashingService
    {
        string HashPassword(string password);
        bool VerifyPassword(string hashedPassword, string password);
    }
}