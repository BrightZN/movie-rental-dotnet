using System;

namespace MovieRental
{
    public class Movie
    {
        public const int Childrens = 2;
        public const int NewRelease = 1;
        public const int Regular = 0;

        public string Title { get; set; }
        public int PriceCode { get; set; }

        public Movie(string title, int priceCode)
        {
            Title = title;
            PriceCode = priceCode;
        }

    }
}