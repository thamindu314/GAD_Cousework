using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;    //ADO.NET class library
using System.Data;

namespace GAD_Cousework._01
{
    class DBConnection
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;

        public DBConnection()
        {
            con = new SqlConnection("Data Source=DESKTOP-3ALHV2P;Initial Catalog=MotorSpa;Integrated Security=True");
        }
        public int AutoIDNumber(string q)
        {
            con.Open();
            cmd = new SqlCommand(q, con);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            count = count + 1;
            con.Close();
            return count;
        }
        public int Save_Update_Delete(string q)
        {
            con.Open();
            cmd = new SqlCommand(q, con);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public DataTable Display(string q)
        {
            con.Open();
            da = new SqlDataAdapter(q, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
    }
}
