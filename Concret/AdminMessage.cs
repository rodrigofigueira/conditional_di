using ConditionalDI.Interfaces;

namespace ConditionalDI.Concret
{
    public class AdminMessage : IMessageService
    {
        public string GetMessage()
        {
            return "Admin message";
        }
    }
}