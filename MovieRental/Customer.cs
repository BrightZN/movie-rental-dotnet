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
            string result = Header(Name);

            result += _rentals.StatementLines();

            double totalAmount = _rentals.TotalAmountOwed;
            int frequentRenterPoints = _rentals.TotalFrequentRenterPoints;

            result += Footer(totalAmount, frequentRenterPoints);

            return result;
        }

        private string Footer(double totalAmount, int frequentRenterPoints)
        {
            string result = $"Amount owed is {totalAmount}\n";
            
            result += $"You earned {frequentRenterPoints} frequent renter points";
            
            return result;
        }

        private static string Header(string name)
        {
            return $"Rental Record for {name}\n";
        }
    }
}

