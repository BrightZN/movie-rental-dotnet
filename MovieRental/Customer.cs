using System.Collections.Generic;
using System.Linq;

namespace MovieRental
{

    public class Customer
    {
        public Customer(string name, Rentals rentals)
        {
            Name = name;
            Rentals = rentals;
        }

        public string Name { get; }
        public Rentals Rentals { get; }

        public string Statement(StatementGenerator statementGenerator) => statementGenerator.GenerateStatement(this);
    }
}

