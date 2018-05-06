using ForumForGeeksForLess.DL.Interfaces;
using ForumForGeeksForLess.Models.DBModel;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace ForumForGeeksForLess.DL.Repositories
{
    public class topicInTheForumRepository : IRepository<topicInTheForum>
    {
        private ForumForGeeksForLessBD db;

        public topicInTheForumRepository(ForumForGeeksForLessBD context)
        {
            this.db = context;
        }

        public async Task<IEnumerable<topicInTheForum>> GetAll()
        {
            return await db.topicInTheForum.ToListAsync();
        }

        public async Task<topicInTheForum> Get(int id)
        {
            return await db.topicInTheForum.FindAsync(id);
        }

        public void Create(topicInTheForum item)
        {
            db.topicInTheForum.Add(item);
        }

        public void Update(topicInTheForum item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public async void Delete(int id)
        {
            topicInTheForum TopicInTheForum = await db.topicInTheForum.FindAsync(id);
            if (TopicInTheForum != null)
                db.topicInTheForum.Remove(TopicInTheForum);
        }
    }
}