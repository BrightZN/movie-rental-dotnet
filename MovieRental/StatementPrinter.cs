namespace MovieRental
{
    public class StatementPrinter
    {
        public string Footer(double totalAmount, int frequentRenterPoints)
        {
            string result = $"Amount owed is {totalAmount}\n";
            
            result += $"You earned {frequentRenterPoints} frequent renter points";
            
            return result;
        }

        public string Header(string name)
        {
            return $"Rental Record for {name}\n";
        }

        public string LineItem(Rental rental)
        {
            return $"\t{rental.Movie.Title}\t{rental.AmountOwed}\n";
        }
    }
}