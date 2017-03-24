using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LatestTask
{
    class Season : InterfaceItem
    {
        /* private fields */

        private bool status;

        /* constructor */
        public Season(string new_title, decimal new_season_number, double new_price, decimal new_release_year, bool new_status)
        {
            /*Exception Handling*/
            if (string.IsNullOrWhiteSpace(new_title)) throw new ArgumentException("Title must not be empty!", nameof(new_title));
            if (new_season_number <= 0) throw new ArgumentOutOfRangeException("Enter a positive value for season number!");
            if (new_release_year < 1888) throw new ArgumentOutOfRangeException("Enter valid release year!");

            Title = new_title;
            Season_number = new_season_number;
            Price = new_price;
            Release_year = new_release_year;
            UpdateSoldStatus(new_status);
        }
        [JsonConstructor]
        public Season(string title, decimal season_number, double price, decimal release_year)
        {
            /*Exception Handling*/
            if (string.IsNullOrWhiteSpace(title)) throw new ArgumentException("Title must not be empty!", nameof(title));
            if (season_number <= 0) throw new ArgumentOutOfRangeException("Enter a positive value for season number!");
            if (release_year < 1888) throw new ArgumentOutOfRangeException("Enter valid release year!");

            Title = title;
            Season_number = season_number;
            Price = price;
            Release_year = release_year;
            //UpdateSoldStatus(new_status);
        }

        /* public properties */
        public string Title { get; set; }
        public decimal Season_number { get; set; }
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
