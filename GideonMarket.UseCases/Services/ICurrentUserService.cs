

namespace GideonMarket.UseCases.Services
{
    public interface ICurrentUserService
    {
        int Id { get; }
        bool IsAuthenticated { get; }
        bool UserName { get; }
        string Email { get; set; }
    }
}
