using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle;
using Oracle.DataAccess;
using Oracle.DataAccess.Client;

namespace LivePerformance
{
    class Databasehandler
    {
        // Fields

        // connectionstring = "User Id=loginname; Password=password;Data Source=localhost";
        private string connectionstring = "User Id=dbi313595;Password=Q8x0MUoAf4;Data Source=192.168.15.50/fhictora";
        private OracleConnection con;
        private OracleCommand cmd;
        private OracleDataReader dr;


        // Methods

        //Connect() om te zorgen dat er een oracle connection voor aangemaakt met de meegegeven connectionstring.
        public void Connect()
        {
            con = new OracleConnection();
            con.ConnectionString = connectionstring;
            con.Open();
            Console.WriteLine("CONNECTION SUCCESFULL");
        }

        //Disconnect() om te zorgen dat de oracle connection gesloten word.
        public void Disconnect()
        {
            con.Close();
            con.Dispose();
        }

  

        /// <summary>
        /// Safely reads int values from the database if they are null
        /// </summary>
        /// <param name="odr">oracle datareader</param>
        /// <param name="colindex">column index</param>
        /// <returns>-1 if null otherwise value from DB</returns>
        int SafeReadInt(OracleDataReader odr, int colindex)
        {
            if (!odr.IsDBNull(colindex))
                return odr.GetInt32(colindex);
            else
                return -1;
        }

        /// Safely reads decimal values from the database if they are null
        ///<returns>0 if null otherwise value from DB</returns>
        decimal SafeReadDecimal(OracleDataReader odr, int colindex)
        {
            if (!odr.IsDBNull(colindex))
                return odr.GetDecimal(colindex);
            else
                return 0;
        }
        /// Safely reads string values from the database if they are null
        ///<returns>empty string otherwise value from DB</returns>
        string SafeReadString(OracleDataReader odr, int colindex)
        {
            if (!odr.IsDBNull(colindex))
                return odr.GetString(colindex);
            else
                return string.Empty;
        }

        /// Safely reads datetime values from the database if they are null
        ///<returns>datetime minimimvalue if null otherwise value from DB</returns>
        DateTime SafeReadDateTime(OracleDataReader odr, int colindex)
        {
            if (!odr.IsDBNull(colindex))
                return odr.GetDateTime(colindex);
            else
                return DateTime.MinValue;
        }

    }
}
