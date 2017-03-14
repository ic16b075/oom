using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Season : InterfaceItem
    {
        /* private fields */

        private double price;

        /* constructor */
        public Season(string new_title, decimal new_season_number, double new_price, decimal new_release_year)
        {
            /*Exception Handling*/
            if (string.IsNullOrWhiteSpace(new_title)) throw new ArgumentException("Title must not be empty!", nameof(new_title));
            if (new_season_number < 0) throw new ArgumentOutOfRangeException("Enter a positive value for season number!");
            if (new_release_year < 1888) throw new ArgumentOutOfRangeException("Enter valid release year!");

            Title = new_title;
            Season_number = new_season_number;
            UpdatePrice(new_price);
            Release_year = new_release_year;
        }

        /* public properties */
        public string Title { get; }
        public decimal Season_number { get; }
        //public double Price { get;  }
        public decimal Release_year { get; }

        public double GetPrice()
        {
            return price;
        }

        /* public method */
        public void UpdatePrice(double updated_new_pice)
        { /* update price with exception price < 0 */
            if (updated_new_pice < 0) throw new ArgumentException("Enter non-negative price!", nameof(updated_new_pice));
            price = updated_new_pice;
        }
    }
}
