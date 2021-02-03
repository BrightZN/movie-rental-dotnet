namespace MovieRental
{
    public abstract class MoviePricing
    {
        public static readonly MoviePricing Childrens = new ChildrensMovie();
        public static readonly MoviePricing NewRelease = new NewReleasePricing();
        public static readonly MoviePricing Regular = new RegularMoviePricing();

        private class ChildrensMovie : MoviePricing
        {
            
        }

        private class NewReleasePricing : MoviePricing
        {
            
        }

        private class RegularMoviePricing : MoviePricing
        {
            
        }

        public virtual double CalculateAmountOwed(int daysRented)
        {
            double amountOwed = 0.00;

            //determine amounts for each line
            if (this == Regular)
            {
                amountOwed += 2;
                
                if (daysRented > 2)
                    amountOwed += (daysRented - 2) * 1.5;
            }
            else if (this == NewRelease)
            {
                amountOwed += daysRented * 3;
            }
            else if (this == Childrens)
            {
                amountOwed += 1.5;
                
                if (daysRented > 3)
                    amountOwed += (daysRented - 3) * 1.5;
            }

            return amountOwed;
        }

        public virtual int CalculateFrequentRenterPoints(int daysRented)
        {
            int frequentRenterPoints = 1;

            // add bonus for a two day new release rental
            if (this == NewRelease && daysRented > 1)
                frequentRenterPoints++;

            return frequentRenterPoints;
        }
    }
}