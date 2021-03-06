using System;
using System.ComponentModel.DataAnnotations;

namespace ForumForGeeksForLess.Models.ForumWebModel
{
    public class MessageInTheTopicWEB
    {
        public int Id { get; set; }

        public int idtopicInTheForum { get; set; }

        public string idIdent { get; set; }

        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "��������� �� ����� ���� ������")]
        [StringLength(500, MinimumLength = 3, ErrorMessage = "����� ��������� ������ ���� � �������� 3 - 500 ��������")]
        [Display(Name = "���������:")]
        public string text { get; set; }


        [Required(ErrorMessage = "��������� �� ����� ���� ������")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "����� ��������� ������ ���� � �������� 3 - 25 ��������")]
        [Display(Name = "���������:")]
        public string caption { get; set; }

        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public DateTime date { get; set; }
        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public int rating { get; set; }
    }
}