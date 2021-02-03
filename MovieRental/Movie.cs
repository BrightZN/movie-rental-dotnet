using System;

namespace MovieRental
{
    public class Movie
    {
        public string Title { get; }
        public MoviePricing PriceCode { get; }

        public Movie(string title, MoviePricing priceCode)
        {
            Title = title;
            PriceCode = priceCode;
        }

        public int CalculateFrequentRenterPoints(int daysRented)
        {
            return PriceCode.CalculateFrequentRenterPoints(daysRented);
        }

        public double CalculateAmountOwed(int daysRented)
        {
            return PriceCode.CalculateAmountOwed(daysRented);
        }
    }
}