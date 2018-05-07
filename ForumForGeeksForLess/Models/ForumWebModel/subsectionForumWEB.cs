using System;
using System.ComponentModel.DataAnnotations;

namespace ForumForGeeksForLess.Models.DBModel
{

   public partial class subsectionForumWEB
    {
        public int Id { get; set; }
        public int idSectionForum { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        [Display(Name = "Тем")]
        public int CountTopics { get; set; }
        [Display(Name = "Сообщений")]
        public int CountReplies { get; set; }

        [Display(Name = "Последнее сообщение")]
        public LastMessage LastMessage { get; set; }

        public subsectionForumWEB()
        {
            LastMessage = new LastMessage();
        }

    }

    public class LastMessage
    {
        public string lastCaption { get; set; }
        public DateTime? Lastdate { get; set; }
        public string lastAutor { get; set; }
        public int lastId { get; set; }
    }
}
