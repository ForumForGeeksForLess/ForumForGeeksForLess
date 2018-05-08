using ForumForGeeksForLess.Models;
using ForumForGeeksForLess.Models.DBModel;
using ForumForGeeksForLess.Models.ForumWebModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumForGeeksForLess.BL.interfaceDTO
{
    public interface IRepositoryBL
    {
       IndexWebModel GetAllSectionAndSub();
        viewForumModel GetViewForum(int i);
        viewTopicWEBModel GetMessageForun(int i);
        void saveMessage(messageInTheTopicWEB mes);
        void saveTopic(ForCreateTopic top);
        void SetVisirer(in string name);
        void Dispose();
    }
}
