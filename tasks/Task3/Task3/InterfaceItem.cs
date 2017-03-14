using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public interface InterfaceItem
    {
        /*Tipp #3: Interfaces dont have fields (but properties) because they cant hold values!*/

        /*Interface has properties*/
        string Title { get; }
        decimal Release_year { get; }
        /*Interface has function prototypes*/
        double GetPrice();
        void UpdatePrice(double updated_new_pice);


    }
}
