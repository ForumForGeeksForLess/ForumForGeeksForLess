namespace ForumForGeeksForLess.Models.DBModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("messageInTheTopic")]
    public partial class messageInTheTopic
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public messageInTheTopic()
        {
            ratingList = new HashSet<ratingList>();
        }

        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int idtopicInTheForum { get; set; }

        [Required]
        [StringLength(128)]
        public string idIdent { get; set; }

        [Required]
        public string text { get; set; }

        [Required]
        [StringLength(25)]
        public string caption { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime date { get; set; }

        public int rating { get; set; }

        public virtual topicInTheForum topicInTheForum { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ratingList> ratingList { get; set; }
    }
}
