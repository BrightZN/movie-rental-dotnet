namespace MovieRental
{
    public class MoviePricing
    {
        public static readonly MoviePricing Childrens = new ChildrensMovie();
        public static readonly MoviePricing NewRelease = new NewReleasePricing();
        public static readonly MoviePricing Regular = new MoviePricing();

        private MoviePricing()
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
            else if (this == Childrens)
            {
                amountOwed += 1.5;
                
                if (daysRented > 3)
                    amountOwed += (daysRented - 3) * 1.5;
            }

            return amountOwed;
        }

        public virtual int CalculateFrequentRenterPoints(int daysRented) => 1;

        private class ChildrensMovie : MoviePricing
        {
            
        }

        private class NewReleasePricing : MoviePricing
        {
            public override double CalculateAmountOwed(int daysRented) => daysRented * 3;

            public override int CalculateFrequentRenterPoints(int daysRented) => daysRented > 1 ? 2 : 1;
        }

    }
}