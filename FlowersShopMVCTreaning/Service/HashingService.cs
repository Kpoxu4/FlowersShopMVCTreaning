using FlowersShopMVCTraining.Service.Interface;

namespace FlowersShopMVCTraining.Service
{
    public class HashingService : IHashingService
    {
        private const int SaltWorkFactor = 10;

        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, SaltWorkFactor);
        }

        public bool VerifyPassword(string hashedPassword, string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}
