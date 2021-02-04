using System;

namespace MovieRental
{
    public class HtmlStatementGenerator : StatementGenerator
    {
        protected override string Footer(Rentals customerRentals)
        {
            return  $"<p>Amount owed is <em>{customerRentals.TotalAmountOwed}</em></p>\n" +
                $"<p>You earned <em>{customerRentals.TotalFrequentRenterPoints}</em> frequent renter points</p>";
        }

        protected override string LineItems(Rentals rentals)
        {
            return $"<table>\n{base.LineItems(rentals)}</table>\n";
        }

        protected override string LineItem(Rental rental)
        {
            return $"\t<tr><td>{rental.Movie.Title}</td><td>{rental.AmountOwed}</td></tr>\n";
        }

        protected override string Header(Customer customer)
        {
            return $"<h1>Rental Record for <em>{customer.Name}</em></h1>\n";
        }
    }
}