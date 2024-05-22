using Web2.Server.Models;

namespace Web2.Server.Data
{
    public class MyDataContext
    {
        public List<MessageModel> Messages { get; set; }

        public MyDataContext() 
        {
            Messages = new List<MessageModel>();
        }
    }
}
