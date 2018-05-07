using ForumForGeeksForLess.DL.Interfaces;
using ForumForGeeksForLess.Models.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForumForGeeksForLess.DL.Repositories
{
    public class EFUnitOfWork: IUnitOfWork, IDisposable
    {

        private ForumForGeeksForLessBD db;


        private messageInTheTopicRepository MessageInTheTopicRepository;
        private ratingListRepository RatingListRepository;
        private sectionForumRepository SectionForumRepository;
        private subsectionForumRepository SubsectionForumRepository;
        private topicInTheForumRepository TopicInTheForumRepository;
        private visitListRepository VisitListRepository;
      
        public EFUnitOfWork()
        {
            db = new ForumForGeeksForLessBD();
            //db = new ForumForGeeksForLessBD(connectionString);
        }

        public IRepository<messageInTheTopic> MessageInTheTopics
        {
            get
            {
                if (MessageInTheTopicRepository == null)
                    MessageInTheTopicRepository = new messageInTheTopicRepository(db);
                return MessageInTheTopicRepository;
            }
        }

        public IRepository<ratingList> RatingsList
        {
            get
            {
                if (RatingListRepository == null)
                    RatingListRepository = new ratingListRepository(db);
                return RatingListRepository;
            }
        }

        public IRepository<sectionForum> SectionsForum
        {
            get
            {
                if (SectionForumRepository == null)
                    SectionForumRepository = new sectionForumRepository(db);
                return SectionForumRepository;
            }
        }

        public IRepository<subsectionForum> SubsectionsForum
        {
            get
            {
                if (SubsectionForumRepository == null)
                    SubsectionForumRepository = new subsectionForumRepository(db);
                return SubsectionForumRepository;
            }
        }

        public IRepository<topicInTheForum> TopicsInTheForum
        {
            get
            {
                if (TopicInTheForumRepository == null)
                    TopicInTheForumRepository = new topicInTheForumRepository(db);
                return TopicInTheForumRepository;
            }
        }

        public IRepository<visitList> VisitsList
        {
            get
            {
                if (VisitListRepository == null)
                    VisitListRepository = new visitListRepository(db);
                return VisitListRepository;
            }
        }
  
        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}