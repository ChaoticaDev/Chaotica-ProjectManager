﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Chaotica_Dev_Kit
{
    class ChaoticaDBManager
    {
        private String dbuser = "", dbpass = "", dbdbname = "chaoticakit";
        //Connect to database
        public static MySqlConnection connection = new MySql.Data.MySqlClient.MySqlConnection();

        public static MySqlDataReader Query(String stmt)
        {
            MySqlCommand projs = new MySqlCommand(stmt, ChaoticaDBManager.connection);
            MySqlDataReader reader = projs.ExecuteReader();

            return reader;
        }

        public ChaoticaDBManager()
        {
            String err;
            try
            {
                if(connection.State == ConnectionState.Open)
                {
                    return;
                }
                //Connection String
                connection.ConnectionString = "Server=localhost;Uid=" + dbuser + ";Pwd=" + dbpass + ";Database=" + dbdbname + ";SslMode=None;CharSet=utf8;";

                //Open Connection
                connection.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                //Get MySQL Error
                err = (ex.Message);
            }
        }
    }
}
