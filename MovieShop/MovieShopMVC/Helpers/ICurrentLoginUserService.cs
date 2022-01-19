namespace MovieShopMVC.Helpers
{
    public interface ICurrentLoginUserService
    {
        int UserId { get; }
        string Email { get; }
        string FullName { get; }
        List<string> Roles { get; set; }
        bool IsAdmin { get; }

    }
}
