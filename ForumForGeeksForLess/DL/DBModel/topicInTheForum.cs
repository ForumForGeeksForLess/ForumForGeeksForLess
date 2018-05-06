namespace ForumForGeeksForLess.Models.DBModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("topicInTheForum")]
    public partial class topicInTheForum
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public topicInTheForum()
        {
            messageInTheTopic = new HashSet<messageInTheTopic>();
        }

        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int idsubsectionForum { get; set; }

        [Required]
        [StringLength(128)]
        public string idIdent { get; set; }

        [Required]
        [StringLength(25)]
        public string Name { get; set; }

        [Required]
        [StringLength(75)]
        public string Notes { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime Date { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<messageInTheTopic> messageInTheTopic { get; set; }

        public virtual subsectionForum subsectionForum { get; set; }
    }
}
