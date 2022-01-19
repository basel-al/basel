using System.Security.Claims;

namespace MovieShopMVC.Helpers
{
    public class CurrentLoginUserService : ICurrentLoginUserService
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public CurrentLoginUserService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public int UserId => Convert.ToInt32(_contextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value);

        public string Email => _contextAccessor.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;

        public string FullName => _contextAccessor.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value
                + " " + _contextAccessor.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value;

        public List<string> Roles { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool IsAdmin => throw new NotImplementedException();
    }
}
