using ForumForGeeksForLess.Models;
using ForumForGeeksForLess.Models.DBModel;
using ForumForGeeksForLess.Models.ForumWebModel;

namespace ForumForGeeksForLess.BL.interfaceDTO
{
    public interface IRepositoryBL
    {
       IndexWebModel GetAllSectionAndSub();
        viewForumModel GetViewForum(int i);
        viewTopicWEBModel GetMessageForun(int i);
        messageInTheTopicWEB FindMessage(int i);

        void SaveMessage(messageInTheTopicWEB mes);
        void SaveTopic(ForCreateTopic top);
        void EditMessage(messageInTheTopicWEB mes);

        void SetVisirer(in string name);
        void Dispose();
    }
}
