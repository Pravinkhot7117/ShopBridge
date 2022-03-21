using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public class Inventry
{
   //static string cs = ConfigurationManager.ConnectionStrings["Constring"].ConnectionString;
   SqlConnection con=new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

   DataTable dt=new DataTable();
   //SqlTransaction Trans = default(SqlTransaction);
   //SqlCommand cmd = new SqlCommand();

   #region Save
   public string Save(int Id, string Name, string Descreption, decimal Price, int Quantity, string OperationType)
   {
      SqlTransaction Trans = default(SqlTransaction);
      SqlCommand cmd = new SqlCommand();
      string Status = null;
      con.Open();
      //Trans = con.BeginTransaction();
      try
      {
         cmd.Connection = con;
         cmd.CommandType = CommandType.StoredProcedure;
         cmd.CommandText = "SP_InventryMaster";
         cmd.CommandTimeout = 0;
         //if (OperationType == "Update")
         //{
            cmd.Parameters.Add("@ItemID", SqlDbType.Int).Value = Id;
         //}
         //else
         //{
         //   cmd.Parameters.Add("@ItemID", SqlDbType.Int).Value = DBNull.Value;
         //}
         cmd.Parameters.Add("@ItemName", SqlDbType.NVarChar).Value = Name;
         cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = Descreption;
         cmd.Parameters.Add("@ItemPrice", SqlDbType.Decimal).Value = Price;
         cmd.Parameters.Add("@ItemQuantity", SqlDbType.Int).Value = Quantity;
         cmd.Parameters.Add("@OperationType", SqlDbType.NVarChar).Value = OperationType;
         cmd.ExecuteNonQuery();
         //Trans.Commit();
         Status = "Success";
      }
      catch (Exception ex)
      {
         ex.Message.ToString();
         Status = "Failed to "+ OperationType;
         Trans.Rollback();
      }
      finally
      {
         con.Close();
      }
      return Status;
   }
   #endregion

   public DataTable SearchItem(string ItemName, decimal ItemPrice)
   {
      DataTable dt = new DataTable();
      try
      {
         SqlDataAdapter adapt = new SqlDataAdapter();
         SqlCommand cmd = new SqlCommand();
         cmd.Connection = con;
         cmd.CommandType = CommandType.StoredProcedure;
         cmd.CommandText = "SP_GET_InventryDetails";
         cmd.CommandTimeout = 0;
         if (ItemName != "" && ItemName != null)
         {
            cmd.Parameters.Add("@ItemName", SqlDbType.NVarChar).Value = ItemName;
         }
         else
         {
            cmd.Parameters.Add("@ItemName", SqlDbType.NVarChar).Value = DBNull.Value;
         }
         if (ItemPrice != 0)
         {
            cmd.Parameters.Add("@ItemPrice", SqlDbType.Decimal).Value = ItemPrice;
         }
         else
         {
            cmd.Parameters.Add("@ItemPrice", SqlDbType.NVarChar).Value = DBNull.Value;
         }
         adapt.SelectCommand = cmd;
         adapt.Fill(dt);
      }
      catch (Exception ex)
      {
         ex.Message.ToString();
      }
      return dt;
   }
}