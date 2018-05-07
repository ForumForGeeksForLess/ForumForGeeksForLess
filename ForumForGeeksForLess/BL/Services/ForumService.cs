using AutoMapper;
using ForumForGeeksForLess.BL.interfaceDTO;
using ForumForGeeksForLess.DL.Interfaces;
using ForumForGeeksForLess.DL.Repositories;
using ForumForGeeksForLess.Models.DBModel;
using ForumForGeeksForLess.Models.ForumWebModel;
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
                Mapper.Initialize(cfg => cfg.CreateMap<subsectionForum, subsectionForumWEB>());
                foreach (var el in tempSection)
                {
                    List<subsectionForumWEB> tempList = Mapper.Map<IEnumerable<subsectionForum>, List<subsectionForumWEB>>(Database.SubsectionsForum.GetAll().Where(p=>p.idSectionForum==el.Id));
                    SectionAndsubsectionForum.Add(el.Name, tempList);
                }
                webModel.SectionAndsubsectionForum = SectionAndsubsectionForum;
            }
            return webModel;
        }
    }
}

