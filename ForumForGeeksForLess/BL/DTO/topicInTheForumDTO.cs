namespace ForumForGeeksForLess.Models.DBModel
{
    using System;

    public partial class topicInTheForumDTO
    {
       public int Id { get; set; }
       public int idsubsectionForum { get; set; }
       public string idIdent { get; set; }
       public string Name { get; set; }
       public string Notes { get; set; }
        public DateTime Date { get; set; }
    
    }
}
