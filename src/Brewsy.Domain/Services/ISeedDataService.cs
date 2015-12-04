using System.Threading.Tasks;

namespace Brewsy.Domain.Services
{
    public interface ISeedDataService
    {
        Task EnsureSeedDataExists();
    }
}
