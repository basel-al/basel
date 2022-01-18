namespace MovieShopMVC.Helpers
{
    public interface ICurrentLoginUserService
    {
        int UserId { get; set; }
        string Email { get; set; }
        string FullName { get; set; }
        
        bool IsAdmin { get; set; }
    }
}
