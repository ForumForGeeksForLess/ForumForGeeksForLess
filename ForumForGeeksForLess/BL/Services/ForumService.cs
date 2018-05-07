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
        IUnitOfWork Database { get; set; }
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
                            tempList[i].LastMessage.lastId = temp.Id;
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
    }
}

