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
       void SetVisirer(in string name);
       void Dispose();
    }
}
