using System.Collections.Generic;
using System.Linq;

namespace MovieRental
{
    public class Rentals
    {
        public IEnumerable<Rental> Items { get; }

        public Rentals(IEnumerable<Rental> rentals)
        {
            Items = rentals;
        }

        public double TotalAmountOwed => Items.Sum(r => r.AmountOwed);
        public int TotalFrequentRenterPoints => Items.Sum(r => r.FrequentRenterPoints);
    }
}