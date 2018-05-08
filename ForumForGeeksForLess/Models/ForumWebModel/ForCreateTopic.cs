using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ForumForGeeksForLess.Models
{
    public class ForCreateTopic
    {
        public int idsubsectionForum { get; set; }

        public string idIdent { get; set; }

        [Required(ErrorMessage = "Сообщение не может быть пустым")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Длина темы должна быть в пределах 3 - 25 символов")]
        [Display(Name = "Название темы:")]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Сообщение не может быть пустым")]
        [StringLength(75, MinimumLength = 3, ErrorMessage = "Длина темы должна быть в пределах 3 - 75 символов")]
        [Display(Name = "Примечание к теме:")]
        public string notes { get; set; }

        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Сообщение не может быть пустым")]
        [StringLength(500, MinimumLength = 3, ErrorMessage = "Длина сообщения должна быть в пределах 3 - 500 символов")]
        [Display(Name = "Сообщение:")]
        public string text { get; set; }

        [Required(ErrorMessage = "Заголовок не может быть пустым")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Длина сообщения должна быть в пределах 3 - 25 символов")]
        [Display(Name = "Заголовок:")]
        public string caption { get; set; }

     
    }
}