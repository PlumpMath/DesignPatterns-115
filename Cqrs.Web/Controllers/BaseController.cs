
using System.Web.Mvc;
using Cqrs.Application.Executors.Commands;
using Cqrs.Application.Executors.Queries;

namespace Cqrs.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        /// <summary>
        /// Executes a query in the system and is wired with property injection to ensure the constructor is clean
        /// </summary>
        public IQueryExecutor Query { get; set; }

        /// <summary>
        /// Executes a command in the system and is wired with property injection to ensure the constructor is clean
        /// </summary>
        public ICommandExecutor Command { get; set; }
    }
}