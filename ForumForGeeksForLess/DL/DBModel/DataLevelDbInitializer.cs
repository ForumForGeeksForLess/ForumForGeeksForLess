using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ForumForGeeksForLess.Models.DBModel
{
    public class DataLevelDbInitializer : CreateDatabaseIfNotExists<ForumForGeeksForLessBD>
    {
        //DropCreateDatabaseAlways
        protected override void Seed(ForumForGeeksForLessBD context)
        {
            context.sectionForum.Add(new sectionForum { Name = "Раздел 1" });
            context.sectionForum.Add(new sectionForum { Name = "Раздел 2" });


            //context.ConstHoursReport.Add(new ConstHoursReport { starth = new TimeSpan(9, 0, 0), endh = new TimeSpan(18, 0, 0), ten = new TimeSpan(22, 0, 0), min = 50, max = 100, LunchT = new TimeSpan(1, 0, 0) });

            //context.MainMail.Add(new MainMail { mail = "HoursReport@outlook.com", password = "GdcjTgs7hh!b766" });

            //context.ActionM.Add(new ActionM { ActionName = "action" });
            //context.ActionM.Add(new ActionM { ActionName = "placement" });
            //context.ActionM.Add(new ActionM { ActionName = "breakout" });
            //context.ActionM.Add(new ActionM { ActionName = "input rules" });
            //context.ActionM.Add(new ActionM { ActionName = "silk" });
            //context.ActionM.Add(new ActionM { ActionName = "final check" });
            //context.ActionM.Add(new ActionM { ActionName = "holiday" });
            //context.ActionM.Add(new ActionM { ActionName = "practice" });

            //context.DesignNumber.Add(new DesignNumber { DesignName = "no design" });
            //context.DesignNumber.Add(new DesignNumber { DesignName = "Allegro" });
            //context.DesignNumber.Add(new DesignNumber { DesignName = "MANTA_EVB" });
            //context.DesignNumber.Add(new DesignNumber { DesignName = "s130610" });
            //context.DesignNumber.Add(new DesignNumber { DesignName = "s130812" });

            context.SaveChanges();

            //если нужно что-то добавить при инициализаии

            base.Seed(context);
        }

    }
}