using System;
using System.IO;
using System.Configuration;
using System.Diagnostics;
using System.Windows.Forms;
using NP6.Test.Operations;

namespace NP6.Test
{
    static class Program
    {
        #region

        /********************************************************************************************************************************
         * 
         * Cette application est une simulation d'opération bancaire inachevée.
         * 
         * Le but de cette exercice est d'arriver à un développement fonctionelle et maintenable.
         * 
         * 1) Pour commencer, il faut arriver a compiler ce projet
         * 
         * 2) Certaines valeurs numériques définissant les comptes et la banque sont encore en dur...
         *    Profitons-en pour les placer dans le fichier de config, en suivant l'exemple de la clé "Banque.SoldeDepart"
         * 
         * 3) Ensuite, restons dans la classe Program :
         *    - Assurons nous que tous les ordres du fichier Ordres.txt sont bien executés.
         *    - Profitons pour remettre le code au propre afin que cette envie qui vous anime d'étrangler l'auteur
         *      ne soit pas partagée par le développeur suivant, puis vérifier qu'il fonctionne toujours.
         *    * Il n'est pas interdit de renommer les variables, de placer des commentaires et d'éclater le code si besoin.
         *    
         * 4) La conception des classes Banque et des opérations est a revoir... 
         *    Choisissons les bons types et n'hésitez pas à utiliser l'héritage et l'implémentation d'interface
         *     
         * 5) Le plus difficile est fait ! 
         *    De retour dans la classe Program, il manque un log de l'exécution des opérations :
         *    - Type d'opération (logger directement la ligne d'ordre du fichier)
         *    - Succès ou échec de l'execution de l'opération
         *    - Numéro et Solde du / des comptes avant et après opération.
         *    - Bien évidement, date et heure de la transaction.
         *    L'utilisation de System.Diagnostique.Debug suffit pour cette première version
         *    
         * *) Quelques petits conseils
         *    - Ne restez pas bloqué : 
         *        Google et vos voisins sont la pour vous faire gagner du temps.
         *    - La correction des fautes d'orthographes dans l'ennoncé n'apporte aucun point ( positif... )
         *    - Toute forme de calculatrice est interdite
         * 
         ********************************************************************************************************************************/

        #endregion

        [STAThread]
        static void Main()
        {
            //Application.Run();

            /// <summary>
            /// Lecture des données dans App.config (tout n'est pas mis).
            /// </summary>
            double dbSoldeDepart = double.Parse(ConfigurationManager.AppSettings["Banque.SoldeDepart"]);
            double dbTauxAgio = double.Parse(ConfigurationManager.AppSettings["Banque.TauxAgio"]);
            double dbDecouvert = double.Parse(ConfigurationManager.AppSettings["Banque.DecouvertMaxi"]);

            Compte C00654650 = new Compte("Banque", 0, dbSoldeDepart);
            Banque C58468455 = new Banque(C00654650, dbTauxAgio, dbDecouvert);
            Compte C68468444 = new Compte("Pigeon", 0.2D);
            Compte C44884484 = new Compte("Riche", 8.9D);

            C58468455.AddCompte(C68468444);
            C58468455.AddCompte(C44884484);

            int i = 1;
            ///ouverture de la connection.
            ///création de la chaine de connexion
            //Connection sqlConnect = new Connection();

            ///Information dans App.Config
            //sqlConnect.database = ConfigurationManager.AppSettings["sql.Database"];
            //sqlConnect.user = ConfigurationManager.AppSettings["sql.User"];
            //sqlConnect.password = ConfigurationManager.AppSettings["sql.Password"];
            //sqlConnect.Server = ConfigurationManager.AppSettings["sql.Server"];

            //bool sqlResult = sqlConnect.connectionSql();

            /// <summary>
            /// Lecture du fichier ordre.txt en boucle 
            /// la première ligne n'est pas lue.
            /// </summary>
            bool isFirstLine = true;
            StreamReader FichierOrdres = new StreamReader("Ordres.txt");
            while (!FichierOrdres.EndOfStream)
            {
                string[] c = FichierOrdres.ReadLine().Split(';');
                if (isFirstLine)
                {
                    isFirstLine = false; continue;
                }

                Operation vOperationByCode = (Operation)Banque.GetOperationByCode(c[0], int.Parse(c[1]), int.Parse(c[2]), int.Parse(c[3]));

                //mise en mémoire du solde avant opération
                double soldeavantoperation = C58468455.GetCompteByNumero(int.Parse(c[1])).Solde;

                ///Operation des mouvements Bancaire dans Operations.cs
                bool OperationBancaire = vOperationByCode.OperationBancaire(C58468455, c[0], int.Parse(c[1]), double.Parse(c[2]), int.Parse(c[3]));

                ///Log sur les comptes clients.
                Logger(string.Format("\nDate : {0}\nSuccés de l'opération {1} \nOpération effectué {2} \nNuméro du compte {3}\nPropriétaire du compte {4}\nSolde du compte avant {5} euro\nSoldes du compte après {6} euro\n", DateTime.Now, OperationBancaire.ToString(), c[0].ToString(), C58468455.GetCompteByNumero(int.Parse(c[1])).Numero, C58468455.GetCompteByNumero(int.Parse(c[1])).Proprietaire, soldeavantoperation.ToString(), C58468455.GetCompteByNumero(int.Parse(c[1])).Solde));

                ///Log sur la Banque.
                Logger(string.Format("Solde Banque {0}\n", C58468455._compteBanque.Solde));

               //bool sqlResultQuery = sqlConnect.ExecuteProcedure("InsertDataBanque", i++, c[0].ToString(), DateTime.Now.ToString("yyyy-MM-dd H:mm:ss"), C58468455.GetCompteByNumero(int.Parse(c[1])).Proprietaire, soldeavantoperation.ToString(), C58468455.GetCompteByNumero(int.Parse(c[1])).Solde.ToString());
            }

            //bool sqlResultCLose = sqlConnect.EtatConnection();
        }

        /// <summary>
        /// Classe pour le log dans la console
        /// </summary>
        /// <param name="texte">texte à logger</param>
        private static void Logger(string texte)  
        {
            Debug.Write(texte);
            Debug.Flush();
        }  


    }
}
