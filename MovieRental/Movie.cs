using System;

namespace MovieRental
{
    public class Movie
    {
        public string Title { get; }
        
        private readonly MoviePricing _priceCode;

        public Movie(string title, MoviePricing priceCode)
        {
            Title = title;
            _priceCode = priceCode;
        }

        public int CalculateFrequentRenterPoints(int daysRented)
        {
            return _priceCode.CalculateFrequentRenterPoints(daysRented);
        }

        public double CalculateAmountOwed(int daysRented)
        {
            return _priceCode.CalculateAmountOwed(daysRented);
        }
    }
}