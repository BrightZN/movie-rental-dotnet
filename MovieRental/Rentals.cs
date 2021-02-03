using System.Collections.Generic;
using System.Linq;

namespace MovieRental
{
    public class Rentals
    {
        private readonly IEnumerable<Rental> _rentals;

        public IEnumerable<Rental> Items => _rentals;

        public Rentals(IEnumerable<Rental> rentals)
        {
            _rentals = rentals;
        }

        public double TotalAmountOwed => _rentals.Sum(r => r.AmountOwed);
        public int TotalFrequentRenterPoints => _rentals.Sum(r => r.FrequentRenterPoints);
    }
}