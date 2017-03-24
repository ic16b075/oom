using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LatestTask
{
    public interface InterfaceItem
    {
        /*Tipp #3: Interfaces dont have fields (but properties) because they cant hold values!*/
        /*Interface has properties*/
        string Title { get; }
        decimal Release_year { get; }
        double Price { get; }

        /*Interface has function prototypes*/
        void UpdateSoldStatus(bool new_status);


    }
}
