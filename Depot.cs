using System;
using NP6.Test;
using NP6.Test.Operations;

namespace NP6.Test.Operations
{
    public class Depot : Operation
    {
        public override string Code { get { return "DEPT"; } }
        public int NumeroCompteBeneficiare { get; set; }
        public int Montant { get; set; }


        public override bool OperationBancaire(Banque Infos, string code, int numeroCompte, double montant, int numeroCompte2)
        {
            Compte compteCredit = Infos.GetCompteByNumero(NumeroCompteBeneficiare);
            compteCredit.Solde += montant;
            return true;
        }


        public override string ToString()
        {
            return string.Format("DEPT #{0} :{1}", this.NumeroCompteBeneficiare, this.Montant);
        }


    }
}
