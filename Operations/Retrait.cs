using System;

namespace NP6.Test.Operations
{
    public class Retrait : Operation
    {
        public override string Code { get { return "RETR"; } }
        public int NumeroCompte { get; set; }
        public int Montant { get; set; }


        public override bool OperationBancaire(Banque Infos, string code, int numeroCompte, double montant, int numeroCompte2)
        {
            Compte compteDebit = Infos.GetCompteByNumero(numeroCompte);

            if (compteDebit.Solde + Infos._decouvertMaxi >= montant)
            {
                compteDebit.Solde -= montant;
                return true;
            }
            else
                return false;
        }

        public override string ToString()
        {
            return string.Format("RETR #{0} :{1}", this.NumeroCompte, this.Montant);
        }
    }
}
