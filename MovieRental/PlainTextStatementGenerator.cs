namespace MovieRental
{
    public class PlainTextStatementGenerator : StatementGenerator
    {
        protected override string Footer(Rentals customerRentals)
        {
            string result = $"Amount owed is {customerRentals.TotalAmountOwed}\n";

            result += $"You earned {customerRentals.TotalFrequentRenterPoints} frequent renter points";
            
            return result;
        }

        protected override string LineItem(Rental rental)
        {
            return $"\t{rental.Movie.Title}\t{rental.AmountOwed}\n";
        }

        protected override string Header(Customer customer)
        {
            return $"Rental Record for {customer.Name}\n";
        }
    }
}