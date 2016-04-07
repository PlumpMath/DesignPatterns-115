using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using Cqrs.Application.Executors.Commands;
using Cqrs.Application.Executors.Queries;

namespace Cqrs.Web.Controllers
{
    public class UserController : BaseController
    {

        [HttpPost]
        public ActionResult Register()
        {
            Command.Execute(new RegisterUserCommand() { FirstName = "Mohsin", LastName = "Naveed" });

            return View();
        }

        public ActionResult Login()
        {
            var result = Query.Execute<UserLoginCriteria, UserLoginResult>(new UserLoginCriteria("Mohsin", "Naveed")).Result;
            return View();
        }
    }

    public class UserLoginCriteria
    {
        public UserLoginCriteria(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
    }

    public class UserLoginResult
    {
        public UserLoginResult(bool isValid)
        {
            IsValid = isValid;
        }

        public bool IsValid { get; private set; }
    }


    public class RegisterUserCommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }


    public class RegisterUserCommandHandler : CommandHandler<RegisterUserCommand>
    {
        public RegisterUserCommandHandler()
        {
            // Repository
        }

        protected override void DoHandle(RegisterUserCommand command)
        {
            //Register User
        }
    }


    public class UserLoginQueryHandler : IQuery<UserLoginCriteria, UserLoginResult>
    {

        // private readonly IUserRepository _userCredentialRepository;

        public UserLoginQueryHandler()
        {
            // _userCredentialRepository = userRepository;
        }


        public UserLoginResult Execute(UserLoginCriteria criteria)
        {
            // var result = await Task.Run(() => _userCredentialRepository.Register(criteria.Id)).ConfigureAwait(false);
            return new UserLoginResult(true);
        }

        Task<UserLoginResult> IQuery<UserLoginCriteria, UserLoginResult>.Execute(UserLoginCriteria criteria)
        {
            throw new NotImplementedException();
        }

        //public async Task<UserLoginResult> Execute(UserLoginCriteria criteria)
        //{
        //    // var result = await Task.Run(() => _userCredentialRepository.Register(criteria.Id)).ConfigureAwait(false);
        //    return new UserLoginResult(true);
        //}
    }

}