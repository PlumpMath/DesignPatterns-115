namespace Cqrs.Application.Executors.Queries
{
    public class NullCriteria
    {
        public static readonly NullCriteria Value = new NullCriteria();

        private NullCriteria()
        {
        }
    }
}
