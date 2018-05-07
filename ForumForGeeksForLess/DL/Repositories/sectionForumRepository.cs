using ForumForGeeksForLess.DL.Interfaces;
using ForumForGeeksForLess.Models.DBModel;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace ForumForGeeksForLess.DL.Repositories
{
    public class sectionForumRepository : IRepository<sectionForum>
    {
        private ForumForGeeksForLessBD db;

        public sectionForumRepository(ForumForGeeksForLessBD context)
        {
            this.db = context;
        }
  
        public IEnumerable<sectionForum> GetAll()
        {
            return db.sectionForum;
        }

        public sectionForum Get(int id)
        {
            return db.sectionForum.Find(id);
        }

        public void Create(sectionForum item)
        {
            db.sectionForum.Add(item);
        }

        public void Update(sectionForum item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public async void Delete(int id)
        {
            sectionForum SectionForum = await db.sectionForum.FindAsync(id);
            if (SectionForum != null)
                db.sectionForum.Remove(SectionForum);
        }
    }
}