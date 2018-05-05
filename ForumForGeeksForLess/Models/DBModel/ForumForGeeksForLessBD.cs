namespace ForumForGeeksForLess.Models.DBModel
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ForumForGeeksForLessBD : DbContext
    {
        public ForumForGeeksForLessBD()
            : base("name=ForumForGeeksForLessBD")
        {
        }

        public virtual DbSet<messageInTheTopic> messageInTheTopic { get; set; }
        public virtual DbSet<ratingList> ratingList { get; set; }
        public virtual DbSet<sectionForum> sectionForum { get; set; }
        public virtual DbSet<subsectionForum> subsectionForum { get; set; }
        public virtual DbSet<topicInTheForum> topicInTheForum { get; set; }
        public virtual DbSet<visitList> visitList { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<messageInTheTopic>()
                .HasMany(e => e.ratingList)
                .WithRequired(e => e.messageInTheTopic)
                .HasForeignKey(e => e.idmessageInTheTopic);

            modelBuilder.Entity<sectionForum>()
                .HasMany(e => e.subsectionForum)
                .WithRequired(e => e.sectionForum)
                .HasForeignKey(e => e.idSectionForum);

            modelBuilder.Entity<subsectionForum>()
                .HasMany(e => e.topicInTheForum)
                .WithRequired(e => e.subsectionForum)
                .HasForeignKey(e => e.idsubsectionForum);

            modelBuilder.Entity<topicInTheForum>()
                .HasMany(e => e.messageInTheTopic)
                .WithRequired(e => e.topicInTheForum)
                .HasForeignKey(e => e.idtopicInTheForum);
        }
    }
}
