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
            string result = Header(Name);

            foreach (var rental in _rentals)
                result += LineItem(rental);

            double totalAmount = _rentals.Sum(r => r.AmountOwed);
            int frequentRenterPoints = _rentals.Sum(r => r.FrequentRenterPoints);

            result += Footer(totalAmount, frequentRenterPoints);

            return result;
        }

        private string Footer(double totalAmount, int frequentRenterPoints)
        {
            string result = "Amount owed is " + totalAmount + "\n";
            result += "You earned " + frequentRenterPoints + " frequent renter points";
            return result;
        }

        private static string Header(string name)
        {
            return "Rental Record for " + name + "\n";
        }

        private string LineItem(Rental rental)
        {
            return "\t" + rental.Movie.Title + "\t" + rental.AmountOwed + "\n";
        }
    }
}

