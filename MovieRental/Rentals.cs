using System.Collections.Generic;
using System.Linq;

namespace MovieRental
{
    public class Rentals
    {
        private readonly IEnumerable<Rental> _rentals;

        public Rentals(IEnumerable<Rental> rentals)
        {
            _rentals = rentals;
        }

        public double TotalAmountOwed => _rentals.Sum(r => r.AmountOwed);
        public int TotalFrequentRenterPoints => _rentals.Sum(r => r.FrequentRenterPoints);

        public string StatementLines()
        {
            string result = "";
            
            foreach (var rental in _rentals)
                result += LineItem(rental);

            return result;
        }

        private string LineItem(Rental rental)
        {
            return $"\t{rental.Movie.Title}\t{rental.AmountOwed}\n";
        }
    }
}