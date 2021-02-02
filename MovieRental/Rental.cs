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

        public int CalculateFrequentRenterPoints()
        {
            int frequentRenterPoints = 1;

            // add bonus for a two day new release rental
            if (this.Movie.PriceCode == Movie.NewRelease && this.DaysRented > 1)
                frequentRenterPoints++;
            
            return frequentRenterPoints;
        }

        public double CalculateAmount()
        {
            double thisAmount = 0.00;
            
            //determine amounts for each line
            switch (this.Movie.PriceCode)
            {
                case Movie.Regular:
                    thisAmount += 2;
                    if (this.DaysRented > 2)
                        thisAmount += (this.DaysRented - 2) * 1.5;
                    break;
                case Movie.NewRelease:
                    thisAmount += this.DaysRented * 3;
                    break;
                case Movie.Childrens:
                    thisAmount += 1.5;
                    if (this.DaysRented > 3)
                        thisAmount += (this.DaysRented - 3) * 1.5;
                    break;
            }

            return thisAmount;
        }
    }
}
