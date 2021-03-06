using System;
using System.ComponentModel.DataAnnotations;

namespace ForumForGeeksForLess.Models.ForumWebModel
{

   public partial class subsectionForumWEB
    {
        public int Id { get; set; }
        public int idSectionForum { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        [Display(Name = "����")]
        public int CountTopics { get; set; }
        [Display(Name = "���������")]
        public int CountReplies { get; set; }

        [Display(Name = "��������� ���������")]
        public LastMessage LastMessage { get; set; }

        public subsectionForumWEB()
        {
            LastMessage = new LastMessage();
        }

    }

    public class LastMessage
    {
        public string lastCaption { get; set; }
        [Display(Name = "����")]
        public DateTime? Lastdate { get; set; }
        [Display(Name = "�����")]
        public string lastAutor { get; set; }
        public int lastId { get; set; }
    }
}
