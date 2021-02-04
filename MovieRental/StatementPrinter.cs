namespace MovieRental
{
    public class StatementPrinter
    {
        public string GenerateStatement(Customer customer)
        {
            
            string result = $"Rental Record for {customer.Name}\n";
            
            foreach (var rental in customer.Rentals.Items)
                result += $"\t{rental.Movie.Title}\t{rental.AmountOwed}\n";

            double totalAmount = customer.Rentals.TotalAmountOwed;
            int frequentRenterPoints = customer.Rentals.TotalFrequentRenterPoints;

            result += $"Amount owed is {totalAmount}\n";
            
            result += $"You earned {frequentRenterPoints} frequent renter points";

            return result;
        }
    }
}