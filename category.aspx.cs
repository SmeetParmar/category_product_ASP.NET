using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

//ConnectionString="<%$ ConnectionStrings:DatabaseConnectionString1 %>" 
//DeleteCommand="DELETE FROM [category] WHERE [c_id] = @c_id" 
//InsertCommand="INSERT INTO [category] ([c_name]) VALUES (@c_name)" 
//ProviderName="<%$ ConnectionStrings:DatabaseConnectionString1.ProviderName %>" 
//SelectCommand="SELECT [c_id], [c_name] FROM [category]" 
//UpdateCommand="UPDATE [category] SET [c_name] = @c_name WHERE [c_id] = @c_id">
public partial class Default2 : System.Web.UI.Page
{
    SqlConnection c;
    protected void Page_Load(object sender, EventArgs e)
    {
       c=new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnectionString1"].ConnectionString);
       Print();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Button1.Text == "Update")
        {
            SqlCommand s = new SqlCommand("UPDATE [category] SET [c_name] = @nm WHERE [c_id] = @id", c);
            s.Parameters.AddWithValue("@nm", TextBox1.Text);
            s.Parameters.AddWithValue("@id",ViewState["id"]);
            c.Open();
            if (s.ExecuteNonQuery() == 1)
            {
                Literal1.Text = "Data Updated Successfully";
                Print();
            }
            else
            {
                Literal1.Text = "Error";
            }
            c.Close();
            Clear();
            Button1.Text = "Submit";
        }
        else
        {
            SqlCommand s = new SqlCommand("INSERT INTO [category] ([c_name]) VALUES (@nm)", c);
            s.Parameters.AddWithValue("@nm", TextBox1.Text);
            c.Open();
            if (s.ExecuteNonQuery() == 1)
            {
                Literal1.Text = "Data  Inserted Successfully";
                Print();
            }
            else
            {
                Literal1.Text = "Error";
            }
            c.Close();
            Clear();
        }
        Button1.Text = "Submit";
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Button b=(Button)sender;
        SqlCommand s = new SqlCommand("DELETE FROM [category] WHERE [c_id] = @c_id", c);
        s.Parameters.AddWithValue("@c_id", b.CommandArgument);
        c.Open();
        if (s.ExecuteNonQuery() == 1)
        {
            Literal1.Text = "Data Deleted Successfully";
            Print();
        }
        else
        {
            Literal1.Text = "Error";
        }
        c.Close();
        Clear();
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Button b = (Button)sender;
        SqlDataAdapter a = new SqlDataAdapter("SELECT * FROM category WHERE [c_id]="+b.CommandArgument,c);
        DataTable dt = new DataTable();
        a.Fill(dt);
        TextBox1.Text = dt.Rows[0][1].ToString();
        ViewState["id"] = b.CommandArgument;
        Button1.Text = "Update";
    }
    public void Clear()
    {
        TextBox1.Text = "";
    }
    public void Print()
    {
        SqlDataAdapter a = new SqlDataAdapter("SELECT * FROM category", c);
        DataTable dt = new DataTable();
        a.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
}