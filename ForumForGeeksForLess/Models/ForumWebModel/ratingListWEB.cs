namespace ForumForGeeksForLess.Models.DBModel
{

    public partial class ratingListWEB
    {
       public int Id { get; set; }
       public string user { get; set; }
       public int idmessageInTheTopic { get; set; }
    }
}
