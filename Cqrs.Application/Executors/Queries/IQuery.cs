using System.Threading.Tasks;

namespace Cqrs.Application.Executors.Queries
{
    public interface IQuery
    {
    }

    public interface IQuery<in TCriteria, TResult> : IQuery
    {
        Task<TResult> Execute(TCriteria criteria);
    }

}
