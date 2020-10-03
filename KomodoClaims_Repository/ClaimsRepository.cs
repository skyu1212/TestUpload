using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.IO;

namespace KomodoClaims_Repository
{
    public class ClaimsRepository
    {
        public List<string> queue = new List<string>();
        public string[] queuearray = new string[3];
        OleDbConnection connect = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\\..\\ClaimTable.accdb;");

        public bool ValueFound(string parm)
        {
            bool Check = false;

            if (queue.IndexOf(parm) >-1)
            {
                Check = true;
            }

            return Check;
        }

        public void AddToQueu(string parm)
        {
            queue.Add(parm);
        }

        public void ClearConsole()
        {
            Console.Clear();
        }

        public void CreateDataBase(string CID, string CType, string CDescription, string CAmount, string CdateIncident, string CdateClaim, string CIsValid)
        {
            connect.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=ClaimTable.accdb;";

            if ((File.Exists("ClaimTable.accdb")))//update database
            {
                connect.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connect;
                command.CommandText = "INSERT INTO Table1 (Claim_ID, Claim_Type, Description, Claim_Amount, Date_Of_Incident, Date_Of_Claim, Is_Valid_Claim) values('" + CID + "','" + CType + "','" + CDescription + "','" + CAmount + "','" + CdateIncident + "','" + CdateClaim + "','" + CIsValid + "')";
                command.ExecuteNonQuery();
                connect.Close();
            }
            else //Create the database.
            {
                var create = new ADOX.Catalog();
                create.Create(connect.ConnectionString);
                connect.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connect;
                command.CommandText = "CREATE TABLE Table1 (" +
                   "[Claim_ID] VARCHAR( 50 ) ," +
                    "[Claim_Type] VARCHAR( 50 ) ," +
                    "[Description] VARCHAR( 50 )," +
                    "[Claim_Amount] VARCHAR( 50 )," +
                    "[Date_Of_Incident] VARCHAR( 50 )," +
                    "[Date_Of_Claim] VARCHAR( 50 )," +
                    "[Is_Valid_Claim] VARCHAR( 50 ))";
                command.ExecuteNonQuery();
                command.CommandText = "INSERT INTO Table1 (Claim_ID, Claim_Type, Description, Claim_Amount, Date_Of_Incident, Date_Of_Claim, Is_Valid_Claim) values('" + CID + "','" + CType + "','" + CDescription + "','" + CAmount + "','" + CdateIncident + "','" + CdateClaim + "','" + CIsValid + "')";
                command.ExecuteNonQuery();
                connect.Close();


            }

        }

        public void ReadFromDataBase()
        {
            if ((File.Exists("ClaimTable.accdb")))//update database
            {
                Console.WriteLine("Text from database:\n");
                string SelectString = "SELECT * FROM Table1";
                string Connection = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=ClaimTable.accdb;";
                using (OleDbConnection connect = new OleDbConnection(Connection))
                {
                    OleDbCommand com = new OleDbCommand(SelectString, connect);
                    connect.Open();
                    using (OleDbDataReader read = com.ExecuteReader())
                    {

                        while (read.Read())
                        {
                            Console.WriteLine("Claim_ID: {0},\nClaim_Type: {1},\nDescription: {2}\nClaim_Amount: {3}\nDate_Of_Incident: {4}\nDate_Of_Claim: {5}\nIs_Valid_Claim: {6}\n\n", read["Claim_ID"].ToString(), read["Claim_Type"].ToString(), read["Description"].ToString(), read["Claim_Amount"].ToString(), read["Date_Of_Incident"].ToString(), read["Date_Of_Claim"].ToString(), read["Is_Valid_Claim"].ToString());

                        }
                    }
                }
            }
        }

        public void DeleteDataBase()
        {
           /* if ((File.Exists("ClaimTable.accdb")))//update database
            {
                Console.WriteLine("Do you want to delete the database?(y/n)");
                string response = Console.ReadLine();
                if (response == "y")
                {*/
                    File.Delete("ClaimTable.accdb");
              /*  }
            }*/
        }
    }
}
