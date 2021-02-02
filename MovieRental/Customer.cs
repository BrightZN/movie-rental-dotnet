using System.Collections.Generic;
using System.Linq;

namespace MovieRental
{

    public class Customer
    {
        private readonly List<Rental> _rentals = new List<Rental>();

        public Customer(string name)
        {
            Name = name;
        }

        public void AddRental(Rental rental)
        {
            _rentals.Add(rental);
        }

        public string Name { get; }

        public string Statement()
        {
            string result = "Rental Record for " + Name + "\n";

            foreach (var rental in _rentals)
            {
                double thisAmount = rental.CalculateAmount();

                // show figures for this rental
                result += "\t" + rental.Movie.Title + "\t" + thisAmount + "\n";
            }

            double totalAmount = _rentals.Sum(r => r.CalculateAmount());
            int frequentRenterPoints = _rentals.Sum(r => r.CalculateFrequentRenterPoints());

            // add footer lines
            result += "Amount owed is " + totalAmount + "\n";
            result += "You earned " + frequentRenterPoints + " frequent renter points";

            return result;
        }
    }
}

