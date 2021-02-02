using System.Collections.Generic;

namespace MovieRental
{

    public class Customer
    {
        private readonly List<Rental> _rentals = new List<Rental>();

        public Customer(string name)
        {
            Name = name;
        }

        public void AddRental(Rental rental)
        {
            _rentals.Add(rental);
        }

        public string Name { get; }

        public string Statement()
        {
            double totalAmount = 0;
            int frequentRenterPoints = 0;
            
            string result = "Rental Record for " + Name + "\n";

            foreach (var rental in _rentals)
            {
                double thisAmount = CalculateAmount(rental);

                frequentRenterPoints += CalculateFrequentRenterPoints(rental);

                // show figures for this rental
                result += "\t" + rental.Movie.Title + "\t" + thisAmount + "\n";
                
                totalAmount += thisAmount;
            }

            // add footer lines
            result += "Amount owed is " + totalAmount + "\n";
            result += "You earned " + frequentRenterPoints + " frequent renter points";

            return result;
        }

        private int CalculateFrequentRenterPoints(Rental rental)
        {
            int frequentRenterPoints = 1;

            // add bonus for a two day new release rental
            if (rental.Movie.PriceCode == Movie.NewRelease && rental.DaysRented > 1)
                frequentRenterPoints++;
            
            return frequentRenterPoints;
        }

        private double CalculateAmount(Rental rental)
        {
            double thisAmount = 0.00;
            
            //determine amounts for each line
            switch (rental.Movie.PriceCode)
            {
                case Movie.Regular:
                    thisAmount += 2;
                    if (rental.DaysRented > 2)
                        thisAmount += (rental.DaysRented - 2) * 1.5;
                    break;
                case Movie.NewRelease:
                    thisAmount += rental.DaysRented * 3;
                    break;
                case Movie.Childrens:
                    thisAmount += 1.5;
                    if (rental.DaysRented > 3)
                        thisAmount += (rental.DaysRented - 3) * 1.5;
                    break;
            }

            return thisAmount;
        }
    }
}

