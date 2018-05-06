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

        public async Task<IEnumerable<subsectionForum>> GetAll()
        {
            return await db.subsectionForum.ToListAsync();
        }

        public async Task<subsectionForum> Get(int id)
        {
            return await db.subsectionForum.FindAsync(id);
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