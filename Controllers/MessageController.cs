using ConditionalDI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ConditionalDI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }        

        [HttpGet]
        public string Get()
        {
            return _messageService.GetMessage();
        }
    
    }
}