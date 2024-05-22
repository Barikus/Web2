using Web2.Server.Data;
using Web2.Server.Models;
using Web2.Server.Services.interfaces;

namespace Web2.Server.Services
{
    public class MessagesService : IMessagesService
    {
        private MyDataContext _myDataContext;
        public MessagesService(MyDataContext dataContext)
        {
            _myDataContext = dataContext;
        }
            
        public MessageModel Create(MessageModel model)
        {
            var lastMessage = _myDataContext.Messages.LastOrDefault();
            int newId = lastMessage is null ? 1 : lastMessage.Id + 1;
            
            model.Id = newId;
            _myDataContext.Messages.Add(model);

            return model;
        }

        public MessageModel Update(MessageModel model)
        {
            var modelToUpdate = _myDataContext.Messages.FirstOrDefault(x => x.Id == model.Id);
            
            modelToUpdate.Time = model.Time;
            modelToUpdate.Title = model.Title;
            modelToUpdate.Message = model.Message;

            return modelToUpdate;
        }

        public void Delete(int id)
        {
            var modelToDelete = _myDataContext.Messages.FirstOrDefault(x => x.Id == id);
            _myDataContext.Messages.Remove(modelToDelete);
        }

        public MessageModel Get(int id)
        {
            return _myDataContext.Messages.FirstOrDefault(x => x.Id == id);
        }

        public List<MessageModel> Get()
        {
            return _myDataContext.Messages;
        }
    }
}
