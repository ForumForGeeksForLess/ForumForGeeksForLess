using ForumForGeeksForLess.DL.Interfaces;
using ForumForGeeksForLess.Models.DBModel;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace ForumForGeeksForLess.DL.Repositories
{
    public class visitListRepository : IRepository<visitList>
    {
        private ForumForGeeksForLessBD db;

        public visitListRepository(ForumForGeeksForLessBD context)
        {
            this.db = context;
        }

        public IEnumerable<visitList> GetAll()
        {
            return db.visitList;
        }

        public visitList Get(int id)
        {
            return db.visitList.Find(id);
        }

        public void Create(visitList item)
        {
            db.visitList.Add(item);
        }

        public void Update(visitList item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public async void Delete(int id)
        {
            visitList VisitList = await db.visitList.FindAsync(id);
            if (VisitList != null)
                db.visitList.Remove(VisitList);
        }
    }
}