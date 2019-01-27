using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;

namespace ConsoleApplication_Database
{
    class Program
    {
        static OleDbConnection con;
        static OleDbCommand cmd;
        static OleDbDataReader reader;
        public static void GetStudent()
        {
            int counter = 0;
            con = new OleDbConnection();
            //con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=dbSchool.accdb";
            //con.ConnectionString = "Driver ={ Microsoft Access Driver(*.mdb, *.accdb)}; Dbq = dbSchool.accdb; Uid = Admin; Pwd =;";
            //con.ConnectionString = "Provider = Microsoft.ACE.OLEDB.12.0; OledbKey1=someValue;OledbKey2=someValue; Data Source = dbSchool.accdb";
            con.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source =dbSchool.mdb";
            cmd = new OleDbCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM Student";
            con.Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                counter++;
                Console.WriteLine(reader[0] + "-" + reader[1] + " " + reader[2]);
            }
            con.Close();
            Console.WriteLine("====================================");
            Console.WriteLine("Number of Students :" + counter);
            Console.WriteLine("====================================");
        }

        public static void InsertStudent()
        {
            Console.Write("First Name : ");
            string fname = Console.ReadLine();
            Console.Write("Last Name : ");
            string lname = Console.ReadLine();
            con = new OleDbConnection();
            //con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=dbSchool.accdb";
            con.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source =dbSchool.mdb";
            cmd = new OleDbCommand();
            cmd.Connection = con;
            cmd.CommandText = "INSERT INTO Student (FirstName,LastName) VALUES ('" + fname + "','" + lname + "')";
            con.Open();
            int sonuc = cmd.ExecuteNonQuery();
            con.Close();
            if (sonuc > 0)
            {
                Console.WriteLine("Inserted");
            }
            else
            {
                Console.WriteLine("Three are errors. The record was not inserted.");
            }
        }

        public static void UpdateStudent()
        {
            Console.Write("ID : ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("First Name : ");
            string fname = Console.ReadLine();
            Console.Write("Last Name : ");
            string lname = Console.ReadLine();
            con = new OleDbConnection();
            //con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=dbSchool.accdb";
            con.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source =dbSchool.mdb";
            cmd = new OleDbCommand();
            cmd.Connection = con;
            cmd.CommandText = "UPDATE Student SET FirstName='" + fname + "',LastName='" + lname + "' WHERE Id=" + id;

            con.Open();
            int sonuc = cmd.ExecuteNonQuery();
            con.Close();
            if (sonuc > 0)
            {
                Console.WriteLine("Updated");
            }
            else
            {
                Console.WriteLine("Three are errors. The record was not updated");
            }
            //www.csharp-console-example.com
        }

        public static void DeleteStudent()
        {
            Console.Write("Id : ");
            int id = Convert.ToInt32(Console.ReadLine());

            con = new OleDbConnection();
            //con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=dbSchool.accdb";
            con.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source =dbSchool.mdb";
            cmd = new OleDbCommand();
            cmd.Connection = con;
            cmd.CommandText = "DELETE FROM Student WHERE Id=" + id + "";
            //www.csharp-console-example.com
            con.Open();
            int sonuc = cmd.ExecuteNonQuery();
            con.Close();
            if (sonuc > 0)
            {
                Console.WriteLine("Deleted.");
            }
            else
            {
                Console.WriteLine("Three are errors. The record was not deleted.");
            }
        }


        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1.List of Students");
                Console.WriteLine("2.Insert");
                Console.WriteLine("3.Update");
                Console.WriteLine("4.Delete");
                Console.WriteLine("====================================");
                Console.Write("Select : ");
                string selection = Console.ReadLine();
                Console.WriteLine("====================================");
                if (selection == "1")
                {
                    GetStudent();
                }
                else if (selection == "2")
                {
                    InsertStudent();
                    Console.WriteLine("====================================");
                    GetStudent();
                }
                else if (selection == "3")
                {
                    UpdateStudent();
                    Console.WriteLine("====================================");
                    GetStudent();
                }
                else if (selection == "4")
                {
                    DeleteStudent();
                    Console.WriteLine("====================================");
                    GetStudent();
                }
                Console.Write("Continue (y/n) : ");
                string okay = Console.ReadLine();
                if (okay != "y")
                {
                    break;
                }
            }
        }
    }
}
