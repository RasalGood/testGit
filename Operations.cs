using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NP6.Test.Operations;

namespace NP6.Test.Operations
{
    public abstract class Operation
    {
        public abstract string Code { get;}
        public int NumeroCompte { get; set; }

        public abstract bool OperationBancaire(Banque Infos, string code, int numeroCompte, double montant, int numeroCompte2);

    }
}
