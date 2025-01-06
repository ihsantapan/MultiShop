namespace MultiShop.Basket.Login_Services
{
    public class LoginService : ILoginService
    {
        public readonly IHttpContextAccessor _httpContextAccessor;

        public LoginService(IHttpContextAccessor contextAccessor)
        {
            _httpContextAccessor = contextAccessor;
        }

        public string GetUserId => _httpContextAccessor.HttpContext.User.FindFirst("sub").Value;
    }
}
