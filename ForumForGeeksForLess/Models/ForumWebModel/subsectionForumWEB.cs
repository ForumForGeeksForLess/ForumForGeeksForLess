namespace ForumForGeeksForLess.Models.DBModel
{

   public partial class subsectionForumWEB
    {
        public int Id { get; set; }
        public int idSectionForum { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
    }
}
