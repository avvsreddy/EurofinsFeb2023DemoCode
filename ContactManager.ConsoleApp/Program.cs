using ContactManagers.DataAccess;
using ContactManagers.DataAccess.EFDataAccess;
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace ContactManager.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            IContactsRepository repo = new ContactsEFRepository();
            var c = repo.GetContact(1);
            c.Name = "Modified";

            repo.Edit(1, c);
        }

        public bool TransferFunds(int fromAcc, int toAcc, int amount)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["appconfig"].ConnectionString;

            SqlCommand cmd1 = new SqlCommand($"update accounts set balance = balance - {amount} where accno = {fromAcc}", conn);

            SqlCommand cmd2 = new SqlCommand($"update accounts set balance = balance + {amount} where accno = {toAcc}", conn);

            conn.Open();

            SqlTransaction tx = conn.BeginTransaction();
            cmd1.Transaction = tx;
            cmd2.Transaction = tx;

            try
            {
                cmd1.ExecuteNonQuery();
                throw new System.Exception("Server error");
                cmd2.ExecuteNonQuery();
                tx.Commit();
            }
            catch (Exception ex)
            {
                tx.Rollback();
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return true;
        }
    }
}
