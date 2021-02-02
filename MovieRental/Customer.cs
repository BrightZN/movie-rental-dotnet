using System.Collections.Generic;
using System.Linq;

namespace MovieRental
{

    public class Customer
    {
        private readonly Rentals _rentals;

        public Customer(string name, Rentals rentals)
        {
            Name = name;

            _rentals = rentals;
        }

        public string Name { get; }

        public string Statement(StatementPrinter statementPrinter)
        {
            string result = statementPrinter.Header(Name);

            result += _rentals.StatementLines(statementPrinter);

            double totalAmount = _rentals.TotalAmountOwed;
            int frequentRenterPoints = _rentals.TotalFrequentRenterPoints;

            result += statementPrinter.Footer(totalAmount, frequentRenterPoints);

            return result;
        }
    }
}

