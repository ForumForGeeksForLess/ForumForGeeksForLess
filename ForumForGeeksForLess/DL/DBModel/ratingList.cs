namespace ForumForGeeksForLess.Models.DBModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ratingList")]
    public partial class ratingList
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(128)]
        public string user { get; set; }

        public int idmessageInTheTopic { get; set; }

        public virtual messageInTheTopic messageInTheTopic { get; set; }
    }
}
