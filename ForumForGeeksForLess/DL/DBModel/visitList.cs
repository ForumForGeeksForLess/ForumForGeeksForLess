namespace ForumForGeeksForLess.Models.DBModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("visitList")]
    public partial class visitList
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime date { get; set; }

        [Required]
        [StringLength(128)]
        public string user { get; set; }
    }
}
