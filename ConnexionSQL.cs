using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;

namespace NP6.Test
{
    public class Connection
    {
        #region PROPRIETE

        public string user { get; set; }
        public string password { get; set; }
        public string chaineConnexion { get; set; }
        public string database { get; set; }
        public string Server { get; set; }
        private SqlConnection oConnection;

        #endregion 

        /// <summary>
        /// Conection à la base de données via des paramètres
        /// </summary>
        /// <returns>bool</returns>
        public bool connectionSql()
		{
			 try
             {

                 string ConnectionString = "database=" + this.database + ";server=" + this.Server + ";User ID=" + this.user + ";Password=" + this.password + ";Integrated Security=SSPI;";
                 oConnection = new SqlConnection(ConnectionString);
                 oConnection.Open();

				return true;
			}
			catch(Exception ex)
			{

                System.Diagnostics.Debug.WriteLine(ex.ToString());
                return false;
			}
        }

        public bool ExecuteRequete(int key, string NomOp, string DatOp, string NomProprio, string SoldeAvant, string Solde)
        {
            try
            {
                string Query = "INSERT TRACELOG VALUES (@ID, @NomOp, @DateOp, @NomProprio, @SoldeAvant, @Solde)";

                SqlCommand command = new SqlCommand(Query, oConnection);
                command.Parameters.Add("@ID", SqlDbType.NChar);
                //command.Parameters.AddWithValue("@ID", key.ToString());
                command.Parameters["@ID"].Value = key.ToString();

                command.Parameters.Add("@NomOp", SqlDbType.NChar);
                command.Parameters["@NomOp"].Value = NomOp;

                command.Parameters.Add("@DateOp", SqlDbType.NChar);
                command.Parameters["@DateOp"].Value = DatOp;

                command.Parameters.Add("@NomProprio", SqlDbType.NChar);
                command.Parameters["@NomProprio"].Value = NomProprio;

                command.Parameters.Add("@SoldeAvant", SqlDbType.NChar);
                command.Parameters["@SoldeAvant"].Value = SoldeAvant;

                command.Parameters.Add("@Solde", SqlDbType.NChar);
                command.Parameters["@Solde"].Value = Solde;

                // Execution
                int affectedrows = command.ExecuteNonQuery();
                Console.WriteLine("Nombre de lignes affectées {0}", affectedrows);

                return true;
            }
            catch (Exception ex)
            {

                System.Diagnostics.Debug.WriteLine(ex.ToString());
                return false;
            }

        }

        public bool ExecuteProcedure(string Proc, int key, string NomOp, string DatOp, string NomProprio, string SoldeAvant, string Solde)
        {
           try
            {
                SqlCommand command = new SqlCommand(Proc, oConnection);
                command.CommandText = "InsertDataBanque";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@ID", SqlDbType.NChar);
                command.Parameters["@ID"].Value = key.ToString();

                command.Parameters.Add("@NomOperation", SqlDbType.NChar);
                command.Parameters["@NomOperation"].Value = NomOp;

                command.Parameters.Add("@DateOperation", SqlDbType.NChar);
                command.Parameters["@DateOperation"].Value = DatOp;

                command.Parameters.Add("@Proprietaire", SqlDbType.NChar);
                command.Parameters["@Proprietaire"].Value = NomProprio;

                command.Parameters.Add("@SoldeAvantOp", SqlDbType.NChar);
                command.Parameters["@SoldeAvantOp"].Value = SoldeAvant;

                command.Parameters.Add("@SoldeApresOp", SqlDbType.NChar);
                command.Parameters["@SoldeApresOp"].Value = Solde;

                int affectedrows = command.ExecuteNonQuery();
                Console.WriteLine("Nombre de lignes affectées {0}", affectedrows);

                return true;
            }
            catch (Exception ex)
            {

                System.Diagnostics.Debug.WriteLine(ex.ToString());
                return false;
            }


        }

        public bool EtatConnection()
        {
            ///Close de la connection à la base.
            try
            {
                if (oConnection.State == ConnectionState.Connecting) { oConnection.Close(); }
                return true;
            }
            catch (Exception ex)
            {

                System.Diagnostics.Debug.WriteLine(ex.ToString());
                return false;
            }
    

        }

        public enum DBConnectionState
        {
            Connected,
            Connecting,
            Closed
        };
    }

}
