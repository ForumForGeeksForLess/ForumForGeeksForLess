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
            return db.messageInTheTopic;
        }

        public messageInTheTopic Get(int id)
        {
            return db.messageInTheTopic.Find(id);
        }

        public void Create(messageInTheTopic item)
        {
            db.messageInTheTopic.Add(item);
        }

        public void Update(messageInTheTopic item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public async void Delete(int id)
        {
            messageInTheTopic MessageInTheTopic = await db.messageInTheTopic.FindAsync(id);
            if (MessageInTheTopic != null)
                db.messageInTheTopic.Remove(MessageInTheTopic);
        }
    }
}