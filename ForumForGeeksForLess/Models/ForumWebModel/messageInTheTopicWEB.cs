namespace ForumForGeeksForLess.Models.DBModel
{
    using System;

   public partial class messageInTheTopicWEB
    {
        public int Id { get; set; }
        public int idtopicInTheForum { get; set; }
        public string idIdent { get; set; }
        public string text { get; set; }
        public string caption { get; set; }
        public DateTime date { get; set; }
        public int rating { get; set; }
    }
}
