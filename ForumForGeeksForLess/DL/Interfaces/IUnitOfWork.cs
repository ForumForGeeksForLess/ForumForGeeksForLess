using ForumForGeeksForLess.Models.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumForGeeksForLess.DL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<messageInTheTopic> MessageInTheTopics { get; }
        IRepository<ratingList> RatingsList { get; }
        IRepository<sectionForum> SectionsForum { get; }
        IRepository<subsectionForum> SubsectionsForum { get; }
        IRepository<topicInTheForum> TopicsInTheForum { get; }
        IRepository<visitList> VisitsList { get; }
        void Save();
    }
}
