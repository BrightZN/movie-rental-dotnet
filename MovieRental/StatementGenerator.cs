namespace MovieRental
{
    public class StatementGenerator
    {
        public string GenerateStatement(Customer customer)
        {
            string result = Header(customer);

            var customerRentals = customer.Rentals;
            
            result += LineItems(customerRentals);

            int frequentRenterPoints = customerRentals.TotalFrequentRenterPoints;

            result += $"Amount owed is {customerRentals.TotalAmountOwed}\n";
            
            result += $"You earned {frequentRenterPoints} frequent renter points";

            return result;
        }

        private string LineItems(Rentals rentals)
        {
            string result = "";
            
            foreach (var rental in rentals.Items)
                result += LineItem(rental);
            
            return result;
        }

        private string LineItem(Rental rental)
        {
            return $"\t{rental.Movie.Title}\t{rental.AmountOwed}\n";
        }

        private string Header(Customer customer)
        {
            return $"Rental Record for {customer.Name}\n";
        }
    }
}