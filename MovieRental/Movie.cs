using System;

namespace MovieRental
{
    public class Movie
    {
        public string Title { get; }
        public int PriceCode { get; }

        public Movie(string title, int priceCode)
        {
            Title = title;
            PriceCode = priceCode;
        }

        public int CalculateFrequentRenterPoints(int daysRented)
        {
            int frequentRenterPoints = 1;

            // add bonus for a two day new release rental
            if (PriceCode == MoviePricing.NewRelease && daysRented > 1)
                frequentRenterPoints++;

            return frequentRenterPoints;
        }
    }
}