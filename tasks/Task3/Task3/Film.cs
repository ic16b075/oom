using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Film : InterfaceItem
    {
        /* private fields */

        private double price;


        /* constructor */
        public Film(string new_title, double new_price, decimal new_release_year)
        {
            if (string.IsNullOrWhiteSpace(new_title)) throw new ArgumentException("Title must not be empty!", nameof(new_title));

            if (new_release_year < 1888) throw new ArgumentOutOfRangeException("Enter valid release year!");

            Title = new_title;
            UpdatePrice(new_price);
            Release_year = new_release_year;
        }

        /* public properties */
        public string Title { get; }
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
