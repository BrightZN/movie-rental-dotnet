using System.Collections.Generic;
using System.Linq;

namespace MovieRental
{

    public class Customer
    {
        private readonly Rentals _rentals;

        public Customer(string name, Rentals rentals)
        {
            Name = name;

            _rentals = rentals;
        }

        public string Name { get; }

        public string Statement()
        {
            string result = $"Rental Record for {Name}\n";
            
            foreach (var rental in _rentals.Items)
                result += $"\t{rental.Movie.Title}\t{rental.AmountOwed}\n";

            double totalAmount = _rentals.TotalAmountOwed;
            int frequentRenterPoints = _rentals.TotalFrequentRenterPoints;

            result += $"Amount owed is {totalAmount}\n";
            
            result += $"You earned {frequentRenterPoints} frequent renter points";

            return result;
        }
    }
}

