using System.Collections.Generic;
using Xunit;

namespace MovieRental.Tests
{
    public class CustomerTest
    {
        private readonly Customer _customer;

        public CustomerTest()
        {
            var rentals = new Rentals(
                new List<Rental>
                {
                    new Rental(new Movie("Jaws", MoviePricing.Regular), 2),
                    new Rental(new Movie("Short New", MoviePricing.NewRelease), 1),
                    new Rental(new Movie("Long New", MoviePricing.NewRelease), 2),
                    new Rental(new Movie("Toy Story", MoviePricing.Childrens), 4)
                });
            
            _customer = new Customer("Bob", rentals);
        }

        [Fact]
        public void Statement_WithRentalListAndPlainTextGenerator_ReturnsPlainTextStatement()
        {
            const string expected = 
                "Rental Record for Bob\n" + 
                "\tJaws\t2\n" +
                "\tShort New\t3\n" +
                "\tLong New\t6\n" +
                "\tToy Story\t3\n" +
                "Amount owed is 14\n" +
                "You earned 5 frequent renter points";

            var statementGenerator = new PlainTextStatementGenerator();

            var actual = _customer.Statement(statementGenerator);
            
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Statement_WithRentalListAndHtmlGenerator_ReturnsHtmlStatement()
        {
            const string expected = 
                "<h1>Rental Record for <em>Bob</em></h1>\n" +
                "<table>\n" +
                "\t<tr><td>Jaws</td><td>2</td></tr>\n" +
                "\t<tr><td>Short New</td><td>3</td></tr>\n" +
                "\t<tr><td>Long New</td><td>6</td></tr>\n" +
                "\t<tr><td>Toy Story</td><td>3</td></tr>\n" +
                "</table>\n" +
                "<p>Amount owed is <em>14</em></p>\n" +
                "<p>You earned <em>5</em> frequent renter points</p>";

            var statementGenerator = new HtmlStatementGenerator();

            var actual = _customer.Statement(statementGenerator);
            
            Assert.Equal(expected, actual);
        }
    }
}
