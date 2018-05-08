using ForumForGeeksForLess.Models.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForumForGeeksForLess.Models.ForumWebModel
{
    public class viewTopicWEBModel
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public List<messageInTheTopicWEB> SubsectionForum { get; set; }

        public viewTopicWEBModel()
        {
            SubsectionForum = new List<messageInTheTopicWEB>();
        }
    }
}