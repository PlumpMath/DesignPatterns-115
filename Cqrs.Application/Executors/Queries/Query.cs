using System.Threading.Tasks;

namespace Cqrs.Application.Executors.Queries
{
    public abstract class Query<TCriteria, TResult> : IQuery<TCriteria, TResult>
    {
        public Task<TResult> Execute(TCriteria criteria)
        {
            return  DoExecute(criteria);
        }

        protected abstract Task<TResult> DoExecute(TCriteria criteria);
    }
}
