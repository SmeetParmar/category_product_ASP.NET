using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

//ConnectionString="<%$ ConnectionStrings:DatabaseConnectionString1 %>" 
//DeleteCommand="DELETE FROM [product] WHERE [p_id] = @p_id" 
//InsertCommand="INSERT INTO [product] ([p_c_id], [p_name], [p_price]) VALUES (@p_c_id, @p_name, @p_price)" 
//ProviderName="<%$ ConnectionStrings:DatabaseConnectionString1.ProviderName %>" 
//SelectCommand="SELECT [p_id], [p_c_id], [p_name], [p_price] FROM [product]" 
//UpdateCommand="UPDATE [product] SET [p_c_id] = @p_c_id, [p_name] = @p_name, [p_price] = @p_price WHERE [p_id] = @p_id">

public partial class product : System.Web.UI.Page
{
    SqlConnection c;
    protected void Page_Load(object sender, EventArgs e)
    {
        c = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnectionString1"].ConnectionString);
        if (!IsPostBack)
        {
            Print();
            databind();
        }
    }
    public void databind()
    {
        SqlDataAdapter s = new SqlDataAdapter("SELECT * FROM category",c);
        DataTable dt = new DataTable();
        s.Fill(dt);
        DropDownList1.DataSource = dt;
        DropDownList1.DataValueField = "c_id";
        DropDownList1.DataTextField = "c_name";
        DropDownList1.DataBind();
        DropDownList1.Items.Insert(0, new ListItem("Please select category", ""));
        DropDownList1.Items[0].Selected = true;
        DropDownList1.Items[0].Attributes["disabled"] = "disabled";
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Button1.Text == "Update")
        {
            SqlCommand s = new SqlCommand("UPDATE [product] SET [p_c_id] = @pcid, [p_name] = @pnm, [p_price] = @ppr WHERE [p_id] = @pid", c);
            s.Parameters.AddWithValue("@pnm", TextBox1.Text);
            s.Parameters.AddWithValue("@ppr", TextBox2.Text);
            s.Parameters.AddWithValue("@pid",ViewState["id"]);
            s.Parameters.AddWithValue("@pcid", Convert.ToInt32(DropDownList1.SelectedValue));
            c.Open();
            
            if (s.ExecuteNonQuery() == 1)
            {
                Literal1.Text = "Data Updated Successfully";
                Print();
                Clear();
            }
            else
            {
                Literal1.Text = "Error";
                Print();
                Clear();
            }
            c.Close();
        }
        else
        {
            SqlCommand s = new SqlCommand("INSERT INTO [product] ([p_c_id], [p_name], [p_price]) VALUES (@pcid, @pnm, @ppr)", c);
            s.Parameters.AddWithValue("@pnm", TextBox1.Text);
            s.Parameters.AddWithValue("@ppr", TextBox2.Text);
            s.Parameters.AddWithValue("@pcid",Convert.ToInt32(DropDownList1.SelectedItem.Value));
            c.Open();
            int b = s.ExecuteNonQuery();
            if (b == 1)
            {
                Literal1.Text = "Data Inserted Successfully";
                Print();
                Clear();
            }
            else
            {
                Literal1.Text = "Error";
                Print();
                Clear();
            }
            c.Close();
        }
        Button1.Text = "Submit";
    }
    protected void Button2_Click(object sen, EventArgs e)
    {
        Button b = (Button) sen;
        SqlCommand s = new SqlCommand("DELETE FROM [product] WHERE [p_id] ="+b.CommandArgument, c);
        c.Open();
        if (s.ExecuteNonQuery()== 1)
        {
            Literal1.Text = "Data Deleted Successfully";
            Print();
            Clear();
        }
        else
        {
            Literal1.Text = "Error";
            Print();
            Clear();
        }
        c.Close();
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Button b = (Button)sender;
        SqlDataAdapter a = new SqlDataAdapter("SELECT [p_id], [p_c_id], [p_name], [p_price] FROM [product] WHERE p_id=" + b.CommandArgument, c);
        ViewState["id"] = b.CommandArgument;
        DataTable dt = new DataTable();
        a.Fill(dt);
        TextBox1.Text = dt.Rows[0][2].ToString();
        TextBox2.Text = dt.Rows[0][3].ToString();
        DropDownList1.Text = dt.Rows[0][1].ToString();
        Button1.Text = "Update";
        DropDownList1.Items[0].Attributes["disabled"] = "disabled";
    }

    public void Print()
    {
        SqlDataAdapter a = new SqlDataAdapter("SELECT * FROM product,category WHERE p_c_id=c_id",c);
        DataTable dt = new DataTable();
        a.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

    public void Clear()
    {
        TextBox1.Text = "";
        TextBox2.Text = "";
        DropDownList1.ClearSelection();
    }
  
}
