using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LatestTask
{
    class Film : InterfaceItem
    {
        /* private fields */
        /*true = storing, false = sold out*/
        private bool status;


        /* constructor */
        public Film(string new_title, double new_price, decimal new_release_year, bool new_status)
        {
            if (string.IsNullOrWhiteSpace(new_title)) throw new ArgumentException("Title must not be empty!", nameof(new_title));

            if (new_release_year < 1888) throw new ArgumentOutOfRangeException("Enter valid release year!");
            if (new_price < 0) throw new ArgumentOutOfRangeException("Enter valid price!");


            Title = new_title;
            Price = new_price;
            Release_year = new_release_year;
            UpdateSoldStatus(new_status);
        }
        
        [JsonConstructor]
        public Film(string title, double price, decimal release_year)
        {
            if (string.IsNullOrWhiteSpace(title)) throw new ArgumentException("Title must not be empty!", nameof(title));

            if (release_year < 1888) throw new ArgumentOutOfRangeException("Enter valid release year!");
            if (price < 0) throw new ArgumentOutOfRangeException("Enter valid price!");


            Title = title;
            Price = price;
            Release_year = release_year;
            //UpdateSoldStatus(new_status);
        }
        

        /* public properties */
        public string Title { get; set; }
        //public double Price { get;  }
        public decimal Release_year { get; set; }
        // TODO: mit Set und Exception Handling -> UpdatePrice
        public double Price { get; set; }

        public bool GetStatus()
        {
            return status;
        }

        /* public method */
        public void UpdateSoldStatus(bool new_status)
        { /* update price with exception price < 0 */
            status = new_status;
        }
    }
}
