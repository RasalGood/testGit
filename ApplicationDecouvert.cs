using System;

namespace NP6.Test.Operations
{
    public class ApplicationDecouvert : Operation
    {
        public override string Code { get { return "AGIO"; }}
        public int NumeroCompte { get; set; }


        public override bool OperationBancaire(Banque Infos, string code, int numeroCompte, double montant, int numeroCompte2)
        {
            Compte compteDebit = Infos.GetCompteByNumero(numeroCompte);
            Compte compteCredit = Infos._compteBanque;
            montant = (compteDebit.Solde >= 0) ? 0 : (compteDebit.Solde * Infos._tauxAgio / 100D);

            compteDebit.Solde -= montant;
            compteCredit.Solde += montant;
            return true;
        }


        public override string ToString()
        {
            return string.Format("AGIO #{0}", this.NumeroCompte);
        }
    }
}
