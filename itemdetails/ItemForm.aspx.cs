using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Collections.Specialized.BitVector32;
using System.Drawing;
using System.Collections;
using System.Globalization;

namespace itemdetails
{
    public partial class ItemForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["webformConnectionString"].ConnectionString);
            
        if(!IsPostBack)
            {
                try
                {
                    get_section();
                    get_counter();
                    get_category();
                    
                    con.Open();
                    String sql = "select isnull(max(Id),0)+1 as Id from item";
                    SqlCommand comm = new SqlCommand(sql, con);                  
                    SqlDataReader nwReader = comm.ExecuteReader();
                    while (nwReader.Read())
                    {
                        int Id = (int)nwReader["Id"];
                        txtitemcode.Text = Id.ToString();
                    }
                    nwReader.Close();
                    
                    con.Close();
                    txtdiscend.Text = "2024-10-10";


                    Button1.Visible=false;
                    btncancel.Visible = true;
                    btnsave.Visible = true;
                    btnshow.Visible = true;
                    if (Request.QueryString["id"] != null)
                    {
                        Button1.Visible = true;
                        btncancel.Visible = false;
                        btnsave.Visible = false;
                        btnshow.Visible = false;
                        Session["ItemId"] = Request.QueryString["id"];
                        SqlCommand cmd1 = new SqlCommand("updateitemdetails", con);
                        cmd1.CommandType = CommandType.StoredProcedure;
                        string idd = Request.QueryString["id"];
                        Session["updateid"] = idd;
                        cmd1.Parameters.AddWithValue("Id", idd);
                        con.Open();
                        SqlDataAdapter sda = new SqlDataAdapter(cmd1);
                        DataSet ds = new DataSet();
                        sda.Fill(ds);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            get_section();
                            ddlsectionname.SelectedItem.Text = ds.Tables[0].Rows[0]["SectionName"].ToString();
                            ddlsectionname.SelectedValue = ds.Tables[0].Rows[0]["SectionId"].ToString();
                            get_counter();
                            ddlcountername.SelectedItem.Text = ds.Tables[0].Rows[0]["CounterName"].ToString();
                            ddlcountername.SelectedValue = ds.Tables[0].Rows[0]["CounterId"].ToString();
                            get_category();
                            ddlcategoryname.SelectedItem.Text = ds.Tables[0].Rows[0]["CategoryName"].ToString();
                            ddlcategoryname.SelectedValue = ds.Tables[0].Rows[0]["CategoryId"].ToString();
                            txtitemcode.Text = ds.Tables[0].Rows[0]["ItemCode"].ToString();
                            txtitemname.Text = ds.Tables[0].Rows[0]["ItemName"].ToString();
                            txtshort.Text = ds.Tables[0].Rows[0]["ItemShortName"].ToString();
                            txtsale.Text = ds.Tables[0].Rows[0]["SaleRate"].ToString();
                            txtdisc.Text = ds.Tables[0].Rows[0]["ItemDiscPerc"].ToString();
                            txtdiscend.Text = ds.Tables[0].Rows[0]["DiscEndDate"].ToString();


                        }
                        con.Close();
                    }
                    
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
              
           
        }
        protected void get_section()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["webformConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("get_section", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            ddlsectionname.DataSource = dt;
            ddlsectionname.DataTextField = "SectionName";
            ddlsectionname.DataValueField = "Id";
            ddlsectionname.DataBind();
            ddlsectionname.Items.Insert(0, new ListItem("--Select--","0"));
        }
        protected void get_counter()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["webformConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("get_counter", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("SectionId", ddlsectionname.SelectedItem.Value);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            ddlcountername.DataSource = dt;
            ddlcountername.DataTextField = "CounterName";
            ddlcountername.DataValueField = "Id";
            ddlcountername.DataBind();
            ddlcountername.Items.Insert(0, new ListItem("--Select--", "0"));
        }
        protected void get_category()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["webformConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("get_category", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("CounterId", ddlcountername.SelectedItem.Value);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            ddlcategoryname.DataSource = dt;
            ddlcategoryname.DataTextField = "CategoryName";
            ddlcategoryname.DataValueField = "Id";
            ddlcategoryname.DataBind();
            ddlcategoryname.Items.Insert(0, new ListItem("--Select--", "0"));
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                ddlsectionname.SelectedValue = "0";
                Label1.Text = "Please Select Section Name";
                ddlcountername.SelectedValue = "0";
                Label2.Text = "Please Select Counter Name";
                ddlcategoryname.SelectedValue = "0";
                Label3.Text = "Please Select Category Name";
                txtitemname.Text = "";
                Label5.Text = "Please Select Item Name";
            }
            else
            {


                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["webformConnectionString"].ConnectionString);
                SqlCommand cmd = new SqlCommand("saveitems", con);
                cmd.CommandType = CommandType.StoredProcedure;
                string checkbox = string.Empty;
                if (chkmostused.Checked)
                {
                    checkbox = "Yes";
                }
                else
                {
                    checkbox = "No";
                }
                //CultureInfo culture = new CultureInfo("en-US");
                //decimal convertdecimal = Convert.ToDecimal(txtsale.Text.ToString(),culture);
                cmd.Parameters.AddWithValue("CategoryId", ddlcategoryname.SelectedItem.Value);
                cmd.Parameters.AddWithValue("ItemCode", txtitemcode.Text);
                cmd.Parameters.AddWithValue("ItemName", txtitemname.Text);
                cmd.Parameters.AddWithValue("ItemShortName", txtshort.Text);
                cmd.Parameters.AddWithValue("SaleRate", txtsale.Text);
                cmd.Parameters.AddWithValue("ItemDiscPerc", txtdisc.Text);
                cmd.Parameters.AddWithValue("DiscEndDate", txtdiscend.Text);
                cmd.Parameters.AddWithValue("IsMostUsed", checkbox);
                con.Open();
                cmd.ExecuteNonQuery();

                con.Close();

                Response.Write("<script>alert('Save Successfully...')</script>");
                cleardata();
            }
        }
        protected void cleardata()
        {
            ddlcategoryname.Items.Clear();
            ddlcountername.Items.Clear();
            ddlsectionname.Items.Clear();
            txtdisc.Text = "";
            txtdiscend.Text = "";
            txtitemcode.Text = "";
            txtitemname.Text = "";
            txtsale.Text = "";
            txtshort.Text = "";
        }
        protected void ddlsectionname_SelectedIndexChanged(object sender, EventArgs e)
        {
            get_counter();
        }

        protected void ddlcountername_SelectedIndexChanged(object sender, EventArgs e)
        {
            get_category();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["webformConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("updateddetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("Id", Session["ItemId"]);
            cmd.Parameters.AddWithValue("CategoryId", ddlcategoryname.SelectedItem.Value);
            cmd.Parameters.AddWithValue("ItemCode", txtitemcode.Text);
            cmd.Parameters.AddWithValue("ItemName", txtitemname.Text);
            cmd.Parameters.AddWithValue("ItemShortName", txtshort.Text);
            cmd.Parameters.AddWithValue("SaleRate", txtsale.Text);
            cmd.Parameters.AddWithValue("ItemDiscPerc", txtdisc.Text);
            cmd.Parameters.AddWithValue("DiscEndRate", txtdiscend.Text);
            //cmd.Parameters.AddWithValue("IsMostUsed", checkbox);
            con.Open();
            cmd.ExecuteNonQuery();
           // con.Close();
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            String sqlc = "";
            sqlc = "update Category set CategoryName='"+ ddlcategoryname.SelectedItem.Text + "' where Id='" + ddlcategoryname.SelectedItem.Value + "'";
            command = new SqlCommand(sqlc, con);
            String sqlcount = "";
            sqlcount = "update Counter set CounterName='" + ddlcountername.SelectedItem.Text + "' where Id='" + ddlcountername.SelectedItem.Value + "'";
            command = new SqlCommand(sqlcount, con);
            String sqlsec = "";
            sqlsec = "update Section set SectionName='" + ddlsectionname.SelectedItem.Text + "' where Id='" + ddlsectionname.SelectedItem.Value + "'";
            command = new SqlCommand(sqlsec, con);
            // adapter.InsertCommand = new SqlCommand(sql, con);
            command.ExecuteNonQuery();
            //command.Dispose(): 
		    con.Close();
            Response.Write("<script>alert('Update Successfully...')</script>");

        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            cleardata();
            get_section();
            get_counter();
            get_category();

        }

        protected void btnshow_Click(object sender, EventArgs e)
        {
            Response.Redirect("ShowDetails.aspx");
        }
    }
}
 