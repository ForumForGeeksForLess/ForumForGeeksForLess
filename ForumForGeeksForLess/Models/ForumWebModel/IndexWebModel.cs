using ForumForGeeksForLess.Models.DBModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ForumForGeeksForLess.Models.ForumWebModel
{
    public class IndexWebModel
    {
        public Dictionary<string, List<subsectionForumWEB>> SectionAndsubsectionForum { get; set; }

        public VilsVisitWeb VisitToday { get; set; }
        public VilsVisitWeb VisitMax{ get; set; }

        public IndexWebModel()
        {
            SectionAndsubsectionForum = new Dictionary<string, List<subsectionForumWEB>>();
            VisitToday = new VilsVisitWeb();
            VisitMax = new VilsVisitWeb();
        }
    }
}

public class VilsVisitWeb
{
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy'-'MM'-'dd}", ApplyFormatInEditMode = true)]
    public DateTime Date { get; set; }
    public int Count { get; set; }
    public List<string> listVisitName { get; set; }

    public VilsVisitWeb()
    {
        listVisitName = new List<string>();
    }
 }

