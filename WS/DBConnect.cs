using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WS.Models;
using Xceed.Wpf.Toolkit;

namespace WS
{
    class DBConnect
    {
        private MySqlConnection connection;
        private string server;
        private string port;
        private string database;
        private string uid;
        private string password;

        //Constructor
        public DBConnect()
        {
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {
            server = "localhost";
            database = "frontaccouting";
            uid = "root";
            password = "root";
            port = "3308";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "PORT=" + port + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        //open connection to database
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        Console.WriteLine("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }


        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        //Insert statement
        public void Insert(string t, DimensionTag v)
        {
            string query = "INSERT INTO " + t + " (type, name, description, inactive) VALUES(" + v.type + ",'" + v.name + "','" + v.description + "'," + v.inactive + ")";
           
            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }
        public void Insert(string t, SalesType v)
        {
            string query = "INSERT INTO " + t + " (sales_type, tax_included, factor, inactive) VALUES('" + v.sales_type + "'," + v.tax_included + "," + v.factor + "," + v.inactive + ")";

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        //Update statement
        public void Update()
        {
            string query = "UPDATE tableinfo SET name='Joe', age='22' WHERE name='John Smith'";

            //Open connection
            if (this.OpenConnection() == true)
            {
                //create mysql command
                MySqlCommand cmd = new MySqlCommand();
                //Assign the query using CommandText
                cmd.CommandText = query;
                //Assign the connection using Connection
                cmd.Connection = connection;

                //Execute query
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        //Delete statement
        public void Delete()
        {
            string query = "DELETE FROM tableinfo WHERE name='John Smith'";

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }

        //Select statement
        //Select statement
        public List<SalesAreas> SelectA()
        {
            string query = "SELECT * FROM 0_areas";
             
            List<SalesAreas> sArs = new List<SalesAreas>();

            //Open connection
            if (this.OpenConnection() == true)
            {

                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                DataSet ds = new DataSet();


                adapter.Fill(ds, "0_areas");

                this.CloseConnection();

                //return list to be displayed
                
                foreach (DataRow pRow in ds.Tables["0_areas"].Rows)
                {
                    SalesAreas s = new SalesAreas();
                    s.area_code = (int)pRow["area_code"];
                    s.description = pRow["description"].ToString();
                    s.inactive = (bool)pRow["inactive"];
                    sArs.Add(s);

                }
                return sArs;

            }
            return null;
        }

        public List<SalesGroups> SelectG()
        {
            string query = "SELECT * FROM 0_groups";

            List<SalesGroups> sGps = new List<SalesGroups>();

            //Open connection
            if (this.OpenConnection() == true)
            {

                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                DataSet ds = new DataSet();


                adapter.Fill(ds, "0_groups");

                this.CloseConnection();

                //return list to be displayed
                
                foreach (DataRow pRow in ds.Tables["0_groups"].Rows)
                {
                    SalesGroups s = new SalesGroups();
                    s.id = Convert.ToInt32(pRow["id"]);
                    s.description = pRow["description"].ToString();
                    s.inactive = (bool)pRow["inactive"];
                    sGps.Add(s);

                }
                return sGps;

            }
            return null;
        }
     

    }
}