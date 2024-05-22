using Microsoft.AspNetCore.Mvc;
using Web2.Server.Models;

namespace Web2.Server.Services.interfaces
{
    public interface IMessagesService
    {
        MessageModel Create(MessageModel message);
        MessageModel Update(MessageModel message);
        MessageModel Get(int id);
        List<MessageModel> Get();
        void Delete(int id);
    }
}
