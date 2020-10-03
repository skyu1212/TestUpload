using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.IO;

namespace KomodoBadges_Repository
{
    public class BadgesRepository
    {
        public Dictionary<int, List<string>> Badges = new Dictionary<int, List<string>>();
         
        public int Key = 1000;
        List<string> m = new List<string>();

        public bool CheckKey(int param)
        {
            Badges.Add(param, m);
            bool value = false;
            if (Badges.ContainsKey(param))
            {
                value = true;
            }
            return value;
        }

        OleDbConnection connect = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\\..\\BadgesTable.accdb;");
        public void CreateDataBase(string CID, string CType)
        {
            connect.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=BadgesTable.accdb;";

            if ((File.Exists("BadgesTable.accdb")))//update database
            {
                connect.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connect;
                command.CommandText = "INSERT INTO Table1 (Badge_Number, Door_Access) values('" + CID + "','" + CType + "')";
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
                   "[Badge_Number] VARCHAR( 50 ) ," +
                    "[Door_Access] VARCHAR( 50 ))";
                command.ExecuteNonQuery();
                command.CommandText = "INSERT INTO Table1 (Badge_Number, Door_Access) values('" + CID + "','" + CType +"')";
                command.ExecuteNonQuery();
                connect.Close();


            }

        }

        public void ReadFromDataBase()
        {
            if ((File.Exists("BadgesTable.accdb")))//update database
            {
                Console.WriteLine("Text from database:\n");
                string SelectString = "SELECT * FROM Table1";
                string Connection = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=BadgesTable.accdb;";
                using (OleDbConnection connect = new OleDbConnection(Connection))
                {
                    OleDbCommand com = new OleDbCommand(SelectString, connect);
                    connect.Open();
                    using (OleDbDataReader read = com.ExecuteReader())
                    {

                        while (read.Read())
                        {
                            Console.WriteLine("Badge: {0},\nDoor Access: {1}\n\n", read["Meal_Number"].ToString(), read["Meal_Name"].ToString());

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
            File.Delete("BadgesTable.accdb");
            /*  }
          }*/
        }
    }
}
