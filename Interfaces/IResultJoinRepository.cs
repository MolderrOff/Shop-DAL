using Shop.Domain.Entity;
using System.Threading.Tasks;

namespace Shop.DAL.Interfaces
{
    public interface IResultJoinRepository : IBaseRepository<ResultJoin>
    {
        Task<ResultJoin> GetResultJoin(string NameProduct);
        Task GetResultJoin();
    }
}
