using System;

namespace NP6.Test
{
    public sealed class Compte
    {
        #region PROPERTIES
        private static int _compteurNumero = 0;

        private int _numero;
        private string _proprietaire;
        private double _tauxRemunerateur;
        private double _solde;
        #endregion
        
        #region CONSTRUCTOR

        public Compte(string proprietaire, double tauxRemunerateur, double soldedepart = 0)
        {
            this._numero = ++_compteurNumero;
            this._proprietaire = proprietaire;
            this._tauxRemunerateur = tauxRemunerateur;
            this._solde = soldedepart;
        }

        #endregion

        #region METHODS
        public int Numero
        {
            get { return this._numero; }
        }

        public string Proprietaire 
        {
            get { return this._proprietaire; } 
        }

        public double TauxRemunerateur
        {
            get { return this._tauxRemunerateur; }
        }

        public double Solde 
        {
            get { return this._solde; }
            internal set { this._solde = value; }
        }
               
        public override string ToString()
        {
            return string.Format("Compte #{0} {1} Solde={2}", this._numero, this._proprietaire, this._solde);
        }
        #endregion

    }
}
