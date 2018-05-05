namespace ForumForGeeksForLess.Models.DBModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("subsectionForum")]
    public partial class subsectionForum
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public subsectionForum()
        {
            topicInTheForum = new HashSet<topicInTheForum>();
        }

        public int Id { get; set; }

        public int idSectionForum { get; set; }

        [Required]
        [StringLength(25)]
        public string Name { get; set; }

        [Required]
        [StringLength(75)]
        public string Notes { get; set; }

        public virtual sectionForum sectionForum { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<topicInTheForum> topicInTheForum { get; set; }
    }
}
