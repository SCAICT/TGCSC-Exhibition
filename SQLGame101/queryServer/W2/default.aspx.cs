using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace W2
{
    public partial class _default : System.Web.UI.Page
    {
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            SqlConnection sqlc = new SqlConnection("Data Source=steal.tyc4d.tw;Persist Security Info=True;Initial Catalog = contact;User ID=user;Password=zxc19201080");
            sqlc.Open();
            string sqltext2 = "SELECT id,username,password,creditNum FROM users";
            SqlDataAdapter ad = new SqlDataAdapter(sqltext2, sqlc);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlc = new SqlConnection("Data Source=steal.tyc4d.tw;Persist Security Info=True;Initial Catalog = contact;User ID=user;Password=zxc19201080");
            sqlc.Open();
            SqlCommand query = new SqlCommand("insert into contact_user(uid,name,address,age) values(@P0,@P1,@P2,@P3)", sqlc);
            query.Parameters.AddWithValue("@P0", System.Guid.NewGuid().ToString());
            query.Parameters.AddWithValue("@P1", "ED");
            query.Parameters.AddWithValue("@P2", "ED");
            query.Parameters.AddWithValue("@P3", "ED");
            query.ExecuteNonQuery();

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "刪除")
            {
                SqlConnection sqlc = new SqlConnection("Data Source=localhost;Persist Security Info=True;Initial Catalog = contact;User ID=sa;Password=ovh1024768@");
                sqlc.Open();
                Button BTN = (Button)e.CommandSource;
                GridViewRow myRow = (GridViewRow)BTN.NamingContainer;
                int pos = myRow.RowIndex;
                string key = (sender as GridView).DataKeys[pos].Value.ToString();
                string sqltext = "delete from contact_user where uid = @P0";
                
                SqlCommand query = new SqlCommand(sqltext, sqlc);
                query.Parameters.AddWithValue("@P0", key);
                query.ExecuteNonQuery();
                Label1.Text = pos.ToString() + key;
            }
        }
    }
}