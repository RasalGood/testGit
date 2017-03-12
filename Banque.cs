using System;
using System.Collections;
using NP6.Test;
using NP6.Test.Operations;

namespace NP6.Test
{
    public class Banque
    {
        #region PROPERTIES

        public Compte _compteBanque;
        public ArrayList _comptes;
        public double _tauxAgio;
        public double _decouvertMaxi;

        #endregion

        #region CONSTRUCTORS

        public Banque(Compte compteBanque, double tauxAgio, double decouvertMaxi)
        {
            if (compteBanque == null)
                throw new Exception("Le compte de la banque doit etre défini");

            if (tauxAgio <= 0)
                throw new Exception("Le taux d'agio doit etre strictement positif");

            this._compteBanque = compteBanque;
            this._tauxAgio = tauxAgio;
            this._decouvertMaxi = decouvertMaxi;
            this._comptes = new ArrayList();

        }

        #endregion

        #region METHODS

        public static object GetOperationByCode(string code, int numeroCompte, int montant, int numeroCompte2)
        {
            switch (code)
            {
                case "DEPT": return new Depot { NumeroCompteBeneficiare = numeroCompte, Montant = montant };

                case "RETR": return new Retrait { NumeroCompte = numeroCompte, Montant = montant };

                case "VRMT": return new Virement { NumeroCompte1 = numeroCompte, Montant = montant, NumeroCompte2 = numeroCompte2 };

                case "REMN": return new ApplicationRemuneration { NumeroCompte = numeroCompte };

                case "AGIO": return new ApplicationDecouvert { NumeroCompte = numeroCompte };

                default: throw new Exception("Code non reconnu");
            }
        }

        public void AddCompte(Compte compte)
        {
            if (this._comptes.Contains(compte))
                throw new Exception("Le compte est déja déclaré");

            this._comptes.Add(compte);
        }

        public Compte GetCompteByNumero(int numeroCompte)
        {
            for (int i = 0; i < this._comptes.Count; i++)
                if (numeroCompte == ((Compte)this._comptes[i]).Numero)
                    return (Compte)this._comptes[i];
            throw new Exception("Le compte demandé n'existe pas");
        }

        #endregion

    }
}
