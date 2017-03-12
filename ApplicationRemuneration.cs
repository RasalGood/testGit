using System;

namespace NP6.Test.Operations
{
    public class ApplicationRemuneration : Operation
    {
        public override string Code { get { return "REMN"; } }
        public int NumeroCompte { get; set; }


        public override bool OperationBancaire(Banque Infos, string code, int numeroCompte, double montant, int numeroCompte2)
        {
            Compte compteDebit = Infos._compteBanque;
            Compte compteCredit = Infos.GetCompteByNumero(numeroCompte);
            montant = (compteCredit.Solde < 0) ? 0 : (compteCredit.Solde * compteCredit.TauxRemunerateur / 100D);

            if (compteDebit.Solde >= montant)
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
            return string.Format("REMN #{0}", this.NumeroCompte);
        }
    }
}
