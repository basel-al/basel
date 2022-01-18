namespace MovieShopMVC.Helpers
{
    public class CurrentLoginUserService : ICurrentLoginUserService
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public CurrentLoginUserService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }
        public int UserId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Email { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string FullName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IsAdmin { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
