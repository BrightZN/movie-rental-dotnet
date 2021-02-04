namespace MovieRental
{
    public abstract class StatementGenerator
    {
        public virtual string GenerateStatement(Customer customer)
        {
            string result = Header(customer);

            result += LineItems(customer.Rentals);

            result += Footer(customer.Rentals);

            return result;
        }

        protected abstract string Footer(Rentals customerRentals);

        protected virtual string LineItems(Rentals rentals)
        {
            string result = "";
            
            foreach (var rental in rentals.Items)
                result += LineItem(rental);
            
            return result;
        }

        protected abstract string LineItem(Rental rental);
        protected abstract string Header(Customer customer);
    }
}