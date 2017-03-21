using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LatestTask
{
    class DeserealizedObject
    {

        /* constructor */
        
        public DeserealizedObject(string new_title, decimal new_release_year)
        {

            Title = new_title;
            Release_year = new_release_year;

        }
        
        public string Title { get; set; }

        public decimal Release_year { get; set; }
    }
}

