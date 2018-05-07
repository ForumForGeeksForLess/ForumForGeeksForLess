using ForumForGeeksForLess.DL.Interfaces;
using ForumForGeeksForLess.Models.DBModel;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace ForumForGeeksForLess.DL.Repositories
{
    public class subsectionForumRepository : IRepository<subsectionForum>
    {
        private ForumForGeeksForLessBD db;

        public subsectionForumRepository(ForumForGeeksForLessBD context)
        {
            this.db = context;
        }

        public IEnumerable<subsectionForum> GetAll()
        {
            return  db.subsectionForum;
        }

        public subsectionForum Get(int id)
        {
            return  db.subsectionForum.Find(id);
        }

        public void Create(subsectionForum item)
        {
            db.subsectionForum.Add(item);
        }

        public void Update(subsectionForum item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public async void Delete(int id)
        {
            subsectionForum SubsectionForum = await db.subsectionForum.FindAsync(id);
            if (SubsectionForum != null)
                db.subsectionForum.Remove(SubsectionForum);
        }
    }
}