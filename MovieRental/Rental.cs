namespace MovieRental
{
    public class Rental
    {
        public Movie Movie { get; }
        public int DaysRented { get; }

        public Rental(Movie movie, int daysRented)
        {
            Movie = movie;
            DaysRented = daysRented;
        }

        public int FrequentRenterPoints => Movie.CalculateFrequentRenterPoints(DaysRented);

        public double AmountOwed
        {
            get
            {
                double thisAmount = 0.00;

                //determine amounts for each line
                switch (Movie.PriceCode)
                {
                    case MoviePricing.Regular:
                        thisAmount += 2;
                        if (DaysRented > 2)
                            thisAmount += (DaysRented - 2) * 1.5;
                        break;
                    case MoviePricing.NewRelease:
                        thisAmount += DaysRented * 3;
                        break;
                    case MoviePricing.Childrens:
                        thisAmount += 1.5;
                        if (DaysRented > 3)
                            thisAmount += (DaysRented - 3) * 1.5;
                        break;
                }

                return thisAmount;
            }
        }
    }
}
