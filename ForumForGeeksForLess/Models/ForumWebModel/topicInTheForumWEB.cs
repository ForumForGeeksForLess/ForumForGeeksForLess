using System;
using System.ComponentModel.DataAnnotations;

namespace ForumForGeeksForLess.Models.DBModel
{
    using System;

    public partial class topicInTheForumWEB
    {
       public int Id { get; set; }
       public int idsubsectionForum { get; set; }
       [Display(Name = "�����")]
       public string idIdent { get; set; }
       [Display(Name = "����")]
       public string Name { get; set; }
       
       public DateTime Date { get; set; }

        [Display(Name = "���������")]
        public int CountReplies { get; set; }

        [Display(Name = "��������� ���������")]
        public LastMessage LastMessage { get; set; }

        public topicInTheForumWEB()
        {
            LastMessage = new LastMessage();
        }

    }
}
