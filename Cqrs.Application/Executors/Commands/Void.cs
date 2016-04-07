namespace Cqrs.Application.Executors.Commands
{
    public class Void
    {
        public static readonly Void Value = new Void();

        private Void()
        {            
        }
    }
}