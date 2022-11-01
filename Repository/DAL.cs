using Microsoft.Data.SqlClient;
using System.Data;
using WebApplication1.Models;



namespace WebApplication1.Repository
{
    public class DAL
    {
        //public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ConnectionString);
        public SqlConnection con = new SqlConnection();
        public List<UserRegModel>GetDataList()
        {
            List<UserRegModel> lst = new List<UserRegModel>();
            SqlCommand cmd = new SqlCommand("sp_select", con);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                lst.Add(new UserRegModel
                {
                    id = Convert.ToInt32(dr[0]),
                    emailid = Convert.ToString(dr[1]),
                    password = Convert.ToString(dr[2]),
                    name = Convert.ToString(dr[3]),
                });
            }
            return lst;
        }

        public bool InsertData(UserRegModel ur)
        {
            int i;
            SqlCommand cmd = new SqlCommand("sp_insert", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", ur.id);
            cmd.Parameters.AddWithValue("@email", ur.emailid);
            cmd.Parameters.AddWithValue("@pwd", ur.password);
            cmd.Parameters.AddWithValue("@nm", ur.name);
            con.Open();
            i = cmd.ExecuteNonQuery();
            con.Close();
            if(i>=1)
            {
                return true;
            }
            else
            {
                return false; 
            }

        }

        public bool UpdateData(UserRegModel ur)
        {
            int i;
            SqlCommand cmd = new SqlCommand("sp_update", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", ur.id);
            cmd.Parameters.AddWithValue("@email", ur.emailid);
            cmd.Parameters.AddWithValue("@pwd", ur.password);
            cmd.Parameters.AddWithValue("@nm", ur.name);
            con.Open();
            i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool DeleteData(UserRegModel ur)
        {
            int i;
            SqlCommand cmd = new SqlCommand("sp_delete", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", ur.id);
            con.Open();
            i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}
