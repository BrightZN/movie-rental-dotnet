using System;
using Xunit;
using MovieRental;

namespace MovieRental.Tests
{
    public class CustomerTest
    {
        [Fact]
        public void Statement_WithRentalList_ReturnsPlainTextStatement()
        {
            Customer customer = new Customer("Bob");
            customer.AddRental(new Rental(new Movie("Jaws", Movie.Regular), 2));
            customer.AddRental(new Rental(new Movie("Short New", Movie.NewRelease), 1));
            customer.AddRental(new Rental(new Movie("Long New", Movie.NewRelease), 2));
            customer.AddRental(new Rental(new Movie("Toy Story", Movie.Childrens), 4));

            String expected = "" +
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
