namespace AutoFacDemo.Services
{
    public class UserServices : IUserServices
    {
        public string GetCurrentUsername(int id)
        {
            return $"Username: {id}";
        }
    }
}