using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient; 
using System.Data;

namespace StudentManages.Sql
{
    public class BaseOperate
    {
        SqlConnection connection;

        public BaseOperate()
        {
            string connectionString =
           "Data Source=10.60.43.9;Initial Catalog=SSE;User ID=sse_basicinfo;Password=abcd";
            connection = new SqlConnection(connectionString);
        }

        public void Update(string commandStr)
        {
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.CommandText = commandStr;
                command.Connection = connection;
                command.ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
            }
        }

        public DataSet Select(string commandStr)
        {
            DataSet dataSet = new DataSet();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.CommandText = commandStr;
                command.Connection = connection;
                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = command;
                dataAdapter.Fill(dataSet);
            }
            finally
            {
                connection.Close();
            }
            return dataSet;

        }

        //检验一列中是否有空值
        public bool HasNull(string commandStr)
        {
            SqlCommand command = new SqlCommand(commandStr);
            bool hasNull = false;
            try
            {
                connection.Open();
                command.Connection = connection;

                SqlDataReader reader =
                    command.ExecuteReader(CommandBehavior.CloseConnection);

                while (reader.Read())
                {
                    if ( reader[0].ToString()=="" )
                    {
                        hasNull = true;
                        break;
                    }
                }
            }
            finally
            {
                connection.Close();   // make sure the connection closes
            }
            return hasNull;

        }
    }
}
