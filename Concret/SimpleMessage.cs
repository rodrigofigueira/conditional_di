using ConditionalDI.Interfaces;

namespace ConditionalDI.Concret
{
    public class SimpleMessage : IMessageService
    {
        public string GetMessage()
        {
            return "Simple Message";
        }
    }
}