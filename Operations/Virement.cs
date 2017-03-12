using System;

namespace NP6.Test.Operations
{
    public class Virement : Operation
    {
        public override string Code { get { return "VRMT"; } }
        public int NumeroCompte1 { get; set; }
        public int NumeroCompte2 { get; set; }
        public int Montant { get; set; }


        public override bool OperationBancaire(Banque Infos, string code, int numeroCompte, double montant, int numeroCompte2)
        {
            Compte compteDebit = Infos.GetCompteByNumero(numeroCompte);
            Compte compteCredit = Infos.GetCompteByNumero(numeroCompte2);

            if (compteDebit.Solde + Infos._decouvertMaxi >= montant)
            {
                compteDebit.Solde -= montant;
                compteCredit.Solde += montant;
                return true;
            }
            else
                return false;
        }


        public override string ToString()
        {
            return string.Format("VRMT #{0} :{1} #{2}", this.NumeroCompte1, this.Montant, this.NumeroCompte2);
        }
    }
}
