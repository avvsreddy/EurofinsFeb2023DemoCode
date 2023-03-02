using ContactManagers.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;

namespace ContactManagers.DataAccess
{
    public class ContactsDBRepository : IContactsRepository
    {
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(int id, Contact contactToEdit)
        {
            throw new NotImplementedException();
        }

        public List<Contact> GetAll()
        {
            throw new NotImplementedException();
        }

        public Contact GetContact(int id)
        {
            throw new NotImplementedException();
        }

        public List<Contact> GetContactsByLocation(string location)
        {
            throw new NotImplementedException();
        }

        public void Save(Contact c)
        {
            // Step 1: connect with db
            IDbConnection conn = GetConnection();
            //conn.Open();

            // Step 2: Prepare sql insert cmd and send
            string insertSql = $"insert into contacts values ({c.ContactID},'{c.Name}','{c.Email}','{c.Phone}','{c.Location}')";

            string betterway = "insert into contacts values (@id,@name,@email,@phone,@loc)";
            IDbCommand cmd = conn.CreateCommand();
            cmd.Connection = conn;
            cmd.CommandText = betterway;
            IDbDataParameter p1 = cmd.CreateParameter();
            p1.ParameterName = "@id";
            p1.Value = c.ContactID;
            cmd.Parameters.Add(p1);

            IDbDataParameter p2 = cmd.CreateParameter();
            p2.ParameterName = "@name";
            p2.Value = c.Name;
            cmd.Parameters.Add(p2);

            IDbDataParameter p3 = cmd.CreateParameter();
            p3.ParameterName = "@email";
            p3.Value = c.Email;
            cmd.Parameters.Add(p3);

            IDbDataParameter p4 = cmd.CreateParameter();
            p4.ParameterName = "@phone";
            p4.Value = c.Phone;
            cmd.Parameters.Add(p4);


            //cmd.Parameters.AddWithValue("@id", c.ContactID);
            //cmd.Parameters.AddWithValue("@name", c.Name);
            //cmd.Parameters.AddWithValue("@email", c.Email);
            //cmd.Parameters.AddWithValue("@phone", c.Phone);
            //cmd.Parameters.AddWithValue("@loc", c.Location);
            IDataParameter p5 = cmd.CreateParameter();
            p5.ParameterName = "@loc";
            p5.Value = c.Location;
            cmd.Parameters.Add(p5);
            using (conn)
            {
                //try
                //{
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            //}
            // Step 3: close the db connection
            //finally
            //{
            //conn.Close();
            //}


        }

        private static IDbConnection GetConnection()
        {
            //SqlConnection conn = new SqlConnection();
            string provider = ConfigurationManager.ConnectionStrings["appconfig"].ProviderName;
            DbProviderFactory factory = DbProviderFactories.GetFactory(provider);
            IDbConnection conn = factory.CreateConnection();
            string constr = ConfigurationManager.ConnectionStrings["appconfig"].ConnectionString;
            conn.ConnectionString = constr;
            return conn;
        }
    }
}
