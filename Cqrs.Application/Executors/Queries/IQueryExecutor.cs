using System.Threading.Tasks;

namespace Cqrs.Application.Executors.Queries
{
    public interface IQueryExecutor
    {
        Task<TResult> Execute<TCriteria, TResult>(TCriteria criteria);
        Task<TResult> Execute<TResult>();
    }
}
