using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace itemdetails
{
    public partial class ShowDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["webformConnectionString"].ConnectionString);

            fetchitemdata();

        }
        void fetchitemdata()
        { 
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["webformConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("fetchitemdetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            con.Open();
            sda.Fill(ds);
            savedataID.DataSource = ds;
            savedataID.DataBind();
            con.Close();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["webformConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("deleteitemrecords", con);
            cmd.CommandType = CommandType.StoredProcedure;
            string idd = (((sender as LinkButton).NamingContainer.FindControl("Label1") as Label).Text);
            cmd.Parameters.AddWithValue("Id", idd);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            fetchitemdata();

        }
        
    }
}