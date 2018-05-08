using ForumForGeeksForLess.DL.Interfaces;
using ForumForGeeksForLess.Models.DBModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ForumForGeeksForLess.DL.Repositories
{
    public class messageInTheTopicRepository : IRepository<messageInTheTopic>
    {

        private ForumForGeeksForLessBD db;

        public messageInTheTopicRepository(ForumForGeeksForLessBD context)
        {
            this.db = context;
        }

        public IEnumerable<messageInTheTopic> GetAll()
        {
            return db.MessageInTheTopic;
        }

        public messageInTheTopic Get(int id)
        {
            return db.MessageInTheTopic.Find(id);
        }

        public void Create(messageInTheTopic item)
        {
            db.MessageInTheTopic.Add(item);
        }

        public void Update(messageInTheTopic item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public async void Delete(int id)
        {
            messageInTheTopic MessageInTheTopic = await db.MessageInTheTopic.FindAsync(id);
            if (MessageInTheTopic != null)
                db.MessageInTheTopic.Remove(MessageInTheTopic);
        }
    }
}