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
        public string ImagePath { get; set; }

        public List<MessageInTheTopicWEB> SubsectionForum { get; set; }

        public viewTopicWEBModel()
        {
            SubsectionForum = new List<MessageInTheTopicWEB>();
            ImagePath = "Images/Avatar.png";

        }
    }
}