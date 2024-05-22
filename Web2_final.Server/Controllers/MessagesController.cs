using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using Web2.Server.Models;
using Web2.Server.Services;
using Web2.Server.Services.interfaces;

namespace Web2.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private IMessagesService _messageService;

        public MessagesController(IMessagesService messageService)
        {
            _messageService = messageService;
        }

        [HttpPost]
        public MessageModel Create([FromBody] MessageModel model)
        {
            HttpContext.Response.Headers.Add("Location", "https://localhost:7240/");

            DateTime dateTime = DateTime.Now;
            model.Time = dateTime.ToLongTimeString();
            return _messageService.Create(model);
        }

        [HttpPatch]
        public MessageModel Update(MessageModel model)
        {
            return _messageService.Update(model);
        }

        [HttpGet("{id}")]
        public MessageModel Get(int id)
        {
            HttpContext.Response.Headers.Add("Location", "https://localhost:7240/");

            return _messageService.Get(id);
        }

        [HttpGet]
        public IEnumerable<MessageModel> GetAll()
        {
            return _messageService.Get();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _messageService.Delete(id);

            return Ok();
        }
    }
}
