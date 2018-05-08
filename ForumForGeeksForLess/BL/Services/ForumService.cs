using AutoMapper;
using ForumForGeeksForLess.BL.interfaceDTO;
using ForumForGeeksForLess.DL.Interfaces;
using ForumForGeeksForLess.DL.Repositories;
using ForumForGeeksForLess.Models;
using ForumForGeeksForLess.Models.DBModel;
using ForumForGeeksForLess.Models.ForumWebModel;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ForumForGeeksForLess.BL.Services
{
    public class ForumService : IRepositoryBL
    {
        private IUnitOfWork Database { get; set; }
        public ForumService() => Database = new EFUnitOfWork();

    
       public void Dispose() => Database.Dispose();

        public IndexWebModel GetAllSectionAndSub()
        {

            IndexWebModel webModel = new IndexWebModel();

            var tempSection = Database.SectionsForum.GetAll();
            if (tempSection != null)
            {
                Dictionary<string, List<subsectionForumWEB>> SectionAndsubsectionForum = new Dictionary<string, List<subsectionForumWEB>>();
                try{ Mapper.Initialize(cfg => cfg.CreateMap<subsectionForum, subsectionForumWEB>());}
                catch { }
                foreach (var el in tempSection)
                {
                    List<subsectionForumWEB> tempList = Mapper.Map<IEnumerable<subsectionForum>, List<subsectionForumWEB>>(Database.SubsectionsForum.GetAll().Where(p=>p.idSectionForum==el.Id));

                    for (int i = 0, j = tempList.Count(); i < j; i++)
                    {

                        var topicsInTheForum = Database.TopicsInTheForum.GetAll();
                        tempList[i].CountTopics = topicsInTheForum.Where(p => p.idsubsectionForum == tempList[i].Id).Count();
                        List<int> ListMess = topicsInTheForum.Where(p => p.idsubsectionForum == tempList[i].Id).Select(p => p.Id).ToList();
                        var listMes = Database.MessageInTheTopics.GetAll().Where(p => ListMess.Contains(p.idtopicInTheForum)).OrderByDescending(p=>p.date);

                        tempList[i].CountReplies = listMes.Count();

                        if (tempList[i].CountReplies > 0)
                        {
                            var temp = listMes.FirstOrDefault();

                            tempList[i].LastMessage.Lastdate = temp.date;
                            tempList[i].LastMessage.lastCaption = topicsInTheForum.Where(p => p.Id == temp.idtopicInTheForum).Select(p => p.Name).FirstOrDefault();

                            using (ApplicationDbContext bd = new ApplicationDbContext())
                            {
                                tempList[i].LastMessage.lastAutor = bd.Users.Where(p => p.Id == temp.idIdent).Select(p => p.UserName).FirstOrDefault();
                            }



                            tempList[i].LastMessage.lastId = temp.idtopicInTheForum;
                        }
                    }

                    SectionAndsubsectionForum.Add(el.Name, tempList);
                }
                webModel.SectionAndsubsectionForum = SectionAndsubsectionForum;
            }
            var visitList = Database.VisitsList.GetAll();

            var VisitToday = visitList.Where(p => p.date.Date == DateTime.Today).Select(p => p.user);
            //webModel.VisitToday.Date = DateTime.Today;
            webModel.VisitToday.Count = VisitToday.Count();
            webModel.VisitToday.listVisitName = VisitToday.OrderBy(q => q).ToList();


            var dateList = visitList.Select(p => p.date.Date).Distinct();
            Dictionary<DateTime, int> listVisDate = new Dictionary<DateTime, int>();
            foreach (var el in dateList)
            {
                listVisDate.Add(el, visitList.Where(p => p.date.Date == el).Count());
            }
            var maxDate = listVisDate.FirstOrDefault(x => x.Value == listVisDate.Values.Max()).Key;
            var VisitmaxDate = visitList.Where(p => p.date.Date == maxDate).Select(p => p.user);

            webModel.VisitMax.Date = maxDate;
            webModel.VisitMax.Count = VisitmaxDate.Count();
            webModel.VisitMax.listVisitName = VisitmaxDate.OrderBy(q => q).ToList();

            return webModel;
        }

        public void SetVisirer(in string name)
        {
            var visitsList = Database.VisitsList.GetAll().Where(p=>p.date.Date==DateTime.Today).Select(p=>p.user);
            if (!visitsList.Contains(name))
                Database.VisitsList.Create(new visitList { user = name, date = DateTime.Now });
            Database.Save();
        }



        public viewForumModel GetViewForum(int id)
        {
            viewForumModel TopicInTheForumWEB = new viewForumModel
            {
                Id = id,
                Name = Database.SubsectionsForum.GetAll().Where(p => p.Id == id).Select(p => p.Name).FirstOrDefault()
            };
            var subsectionForum = Database.TopicsInTheForum.GetAll().Where(p => p.idsubsectionForum == id);
            foreach (var el in subsectionForum)
            {
                string nameAutor;
                using (ApplicationDbContext bd = new ApplicationDbContext())
                {
                    nameAutor = bd.Users.Where(p => p.Id == el.idIdent).Select(p => p.UserName).FirstOrDefault();
                }
                var tempMes = Database.MessageInTheTopics.GetAll().Where(p => p.idtopicInTheForum == el.Id).OrderByDescending(p=>p.date);
                int countReplies = tempMes.Count();

                var lastMes = tempMes.FirstOrDefault();
                DateTime lasdate = lastMes.date;
                string lasAutor = null;

                if (countReplies > 0)
                {
                   
                    using (ApplicationDbContext bd = new ApplicationDbContext())
                    {
                        lasAutor = bd.Users.Where(p => p.Id == lastMes.idIdent).Select(p => p.UserName).FirstOrDefault();
                    }
                }

                TopicInTheForumWEB.SubsectionForum.Add(new topicInTheForumWEB { Id = el.Id, Date = el.Date, idIdent = nameAutor, Name = el.Name, idsubsectionForum = el.idsubsectionForum, CountReplies= countReplies, LastMessage = new LastMessage { Lastdate= lasdate, lastAutor= lasAutor } });
            }
            TopicInTheForumWEB.SubsectionForum = TopicInTheForumWEB.SubsectionForum.OrderByDescending(p => p.LastMessage.Lastdate).ToList();


            return TopicInTheForumWEB;
        }

        public viewTopicWEBModel GetMessageForun(int id)
        {
            viewTopicWEBModel ViewTopicWEBModel = new viewTopicWEBModel
            {
                Name = Database.TopicsInTheForum.GetAll().Where(p => p.Id == id).Select(p => p.Name).FirstOrDefault(),
                Id = id
            };

            var mess = Database.MessageInTheTopics.GetAll().Where(p => p.idtopicInTheForum == id);
            string Autor;
            foreach (var el in mess)
            {
                Autor = null;
                using (ApplicationDbContext bd = new ApplicationDbContext())
                {
                    Autor = bd.Users.Where(p => p.Id == el.idIdent).Select(p => p.UserName).FirstOrDefault();
                }
                ViewTopicWEBModel.SubsectionForum.Add(new messageInTheTopicWEB { Id = el.Id, date = el.date, caption = el.caption, text = el.text, idIdent= Autor});
            }
            return ViewTopicWEBModel;
        }

        public void SaveMessage(messageInTheTopicWEB mes)
        {
            messageInTheTopic mesDL = new messageInTheTopic { idIdent = mes.idIdent, date = DateTime.Now, idtopicInTheForum = mes.idtopicInTheForum, rating=0, caption = mes.caption, text=mes.text};

            Database.MessageInTheTopics.Create(mesDL);
            Database.Save();
        }

        public void SaveTopic(ForCreateTopic top)
        {
            topicInTheForum tm = new topicInTheForum { Date = DateTime.Now, idIdent = top.idIdent, idsubsectionForum = top.idsubsectionForum, Name = top.Name, Notes = top.notes };
            Database.TopicsInTheForum.Create(tm);
            Database.Save();
            messageInTheTopic mesDL = new messageInTheTopic { idIdent = top.idIdent, date = DateTime.Now, idtopicInTheForum = tm.Id, rating = 0, caption = top.caption, text = top.text };
            Database.MessageInTheTopics.Create(mesDL);
            Database.Save();
        }

        public messageInTheTopicWEB FindMessage(int i)
        {
            var el = Database.MessageInTheTopics.Get(i);
            return new messageInTheTopicWEB { Id = el.Id, caption = el.caption, idIdent = el.idIdent, text = el.text, idtopicInTheForum=el.idtopicInTheForum };
        }

        public void EditMessage(messageInTheTopicWEB mes)
        {
            messageInTheTopic mesDL = Database.MessageInTheTopics.Get(mes.Id);

            mesDL.date = DateTime.Now;
            mesDL.caption = mes.caption;
            mesDL.text = mes.text;
            Database.MessageInTheTopics.Update(mesDL);
            Database.Save();
        }
    }
}

