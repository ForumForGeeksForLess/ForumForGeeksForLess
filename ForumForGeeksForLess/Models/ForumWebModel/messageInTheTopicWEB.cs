namespace ForumForGeeksForLess.Models.DBModel
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class messageInTheTopicWEB
    {
        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public int idtopicInTheForum { get; set; }

        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public string idIdent { get; set; }

        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Сообщение не может быть пустым")]
        [StringLength(500, MinimumLength = 3, ErrorMessage = "Длина сообщения должна быть в пределах 3 - 500 символов")]
        [Display(Name = "Сообщение:")]
        public string text { get; set; }

        [Required(ErrorMessage = "Заголовок не может быть пустым")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Длина сообщения должна быть в пределах 3 - 25 символов")]
        [Display(Name = "Заголовок:")]
        public string caption { get; set; }

        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public DateTime date { get; set; }
        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public int rating { get; set; }
    }
}
