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
        protected  override void Seed(ForumForGeeksForLessBD context)
        {
            sectionForum sF1 = new sectionForum { Name = "Раздел 1" };
            sectionForum sF2 = new sectionForum { Name = "Раздел 2" };

            context.sectionForum.Add(sF1);
            context.sectionForum.Add(sF2);
            context.SaveChanges();

            context.subsectionForum.Add(new subsectionForum { idSectionForum = sF1.Id, Name = "Программирование", Notes = "Все вопросы и ответы по языкам программирования и Web-программированию." });
            context.subsectionForum.Add(new subsectionForum { idSectionForum = sF1.Id, Name = "Ошибки", Notes = "Все замеченные вами ошибки. Как можно подробнее опишите ошибку." });
            context.subsectionForum.Add(new subsectionForum { idSectionForum = sF2.Id, Name = "Флуд и оффтоп", Notes = "Флуд и оффтоп только здесь!" });
            context.subsectionForum.Add(new subsectionForum { idSectionForum = sF2.Id, Name = "Интересное", Notes = "Всё интересное, что вы нашли в Интернете." });

            context.SaveChanges();
            base.Seed(context);
        }

    }
}