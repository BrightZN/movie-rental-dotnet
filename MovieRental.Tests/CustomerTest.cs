using System;
using System.Collections.Generic;
using Xunit;
using MovieRental;

namespace MovieRental.Tests
{
    public class CustomerTest
    {
        [Fact]
        public void Statement_WithRentalList_ReturnsPlainTextStatement()
        {
            var rentals = new Rentals(new List<Rental>
            {
                new Rental(new Movie("Jaws", MoviePricing.Regular), 2),
                new Rental(new Movie("Short New", MoviePricing.NewRelease), 1),
                new Rental(new Movie("Long New", MoviePricing.NewRelease), 2),
                new Rental(new Movie("Toy Story", MoviePricing.Childrens), 4)
            });
            
            var customer = new Customer("Bob", rentals);

            string expected = "" +
                "Rental Record for Bob\n" +
                "\tJaws\t2\n" +
                "\tShort New\t3\n" +
                "\tLong New\t6\n" +
                "\tToy Story\t3\n" +
                "Amount owed is 14\n" +
                "You earned 5 frequent renter points";

            Assert.Equal(expected, customer.Statement());
        }
    }
}
