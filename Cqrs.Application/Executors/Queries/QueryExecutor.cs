using System.Threading.Tasks;

namespace Cqrs.Application.Executors.Queries
{
    public class QueryExecutor : IQueryExecutor
    {
        private readonly IQueryFactory _queryFactory;

        public QueryExecutor(IQueryFactory queryFactory)
        {
            _queryFactory = queryFactory;
        }

        public async Task<TResult> Execute<TCriteria, TResult>(TCriteria criteria)
        {
            var query = _queryFactory.Create<TCriteria, TResult>();
            try
            {
                return await query.Execute(criteria).ConfigureAwait(false);
            }
            finally
            {
                _queryFactory.Destroy(query);
            }    
        }

        public async Task<TResult> Execute<TResult>()
        {
            return await Execute<NullCriteria, TResult>(NullCriteria.Value);
        }
    }
}
