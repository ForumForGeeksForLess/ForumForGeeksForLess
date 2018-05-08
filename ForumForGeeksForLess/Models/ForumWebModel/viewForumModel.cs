using ForumForGeeksForLess.Models.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForumForGeeksForLess.Models.ForumWebModel
{
    public class viewForumModel
    {
        public string Name { get; set; }

        public List<topicInTheForumWEB> SubsectionForum { get; set; }

       public viewForumModel()
       {
            SubsectionForum = new List<topicInTheForumWEB>();
       }
    }
}