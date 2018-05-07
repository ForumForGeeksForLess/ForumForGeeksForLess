using ForumForGeeksForLess.Models.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForumForGeeksForLess.Models.ForumWebModel
{
    public class IndexWebModel
    {
        public Dictionary<string, List<subsectionForumWEB>> SectionAndsubsectionForum { get; set; }

        public IndexWebModel()
        {
            SectionAndsubsectionForum = new Dictionary<string, List<subsectionForumWEB>>();
        }

    }
}