using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace IDAL
{
    public interface relativeDal
    {
        int RelativeAdd(Model.tab_relatives relative);
        DataTable RelativeSelect(Model.tab_relatives rel);
        Model.tab_relatives getRelative(Model.tab_relatives rel);
        DataTable RelativeSelectAll();
        int Delete(int relativeID);
        int update(Model.tab_relatives rel);
        DataTable RelativeSelect(string ss);
    }
}
