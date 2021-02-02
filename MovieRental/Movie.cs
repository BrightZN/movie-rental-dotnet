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

        public double CalculateAmountOwed(int daysRented)
        {
            double thisAmount = 0.00;

            //determine amounts for each line
            switch (PriceCode)
            {
                case MoviePricing.Regular:
                    thisAmount += 2;
                    if (daysRented > 2)
                        thisAmount += (daysRented - 2) * 1.5;
                    break;
                case MoviePricing.NewRelease:
                    thisAmount += daysRented * 3;
                    break;
                case MoviePricing.Childrens:
                    thisAmount += 1.5;
                    if (daysRented > 3)
                        thisAmount += (daysRented - 3) * 1.5;
                    break;
            }

            return thisAmount;
        }
    }
}