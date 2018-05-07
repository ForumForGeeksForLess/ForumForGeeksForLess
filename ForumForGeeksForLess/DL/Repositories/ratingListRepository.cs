using ForumForGeeksForLess.DL.Interfaces;
using ForumForGeeksForLess.Models.DBModel;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace ForumForGeeksForLess.DL.Repositories
{
    class ratingListRepository : IRepository<ratingList>
    {
        private ForumForGeeksForLessBD db;

        public ratingListRepository(ForumForGeeksForLessBD context)
        {
            this.db = context;
        }

        public IEnumerable<ratingList> GetAll()
        {
            return db.ratingList;
        }

        public  ratingList Get(int id)
        {
            return  db.ratingList.Find(id);
        }

        public void Create(ratingList item)
        {
            db.ratingList.Add(item);
        }

        public void Update(ratingList item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public async void Delete(int id)
        {
            ratingList ratingList = await db.ratingList.FindAsync(id);
            if (ratingList != null)
                db.ratingList.Remove(ratingList);
        }
    }
}