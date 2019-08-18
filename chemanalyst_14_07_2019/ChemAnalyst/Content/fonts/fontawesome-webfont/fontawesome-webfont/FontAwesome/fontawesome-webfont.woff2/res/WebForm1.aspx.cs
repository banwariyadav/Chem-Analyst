using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Configuration;
using System.Data.SqlClient;
namespace MVCWithWEBAPI.Scripts.fonts.fonts.modernizser.res
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindGrid();
            }
        }

        private void BindGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["ChemAnalystContext"].ConnectionString;
            string query = "SELECT * FROM SalesPackageSubscriptions";
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(query, con))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                }
            }


            string constr1 = ConfigurationManager.ConnectionStrings["ChemAnalystContext"].ConnectionString;
            string query1 = "SELECT * FROM SA_User";
            using (SqlConnection con = new SqlConnection(constr1))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(query1, con))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        GridView11.DataSource = dt;
                        GridView11.DataBind();
                    }
                }
            }

        }

      

        protected void Insert(object sender, EventArgs e)
        {
            string ProductId = txtProductId.Text;
            string MenuId = txtMenuId.Text;
            string LeadId = txtLeadId.Text;
            string UserId = txtUserId.Text;
            string SubscriptionType = txtSubscriptionType.Text;
            string Status = txtStatus.Text;
            string Description = txtDescription.Text;

          
            string query = "INSERT INTO SalesPackageSubscriptions VALUES(@ProductId, @MenuId, @LeadId, @UserId, @SubscriptionType, @CreatedDate, @Status, @Description, @FromDate, @ToDate)";
            string constr = ConfigurationManager.ConnectionStrings["ChemAnalystContext"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@ProductId", ProductId);
                    cmd.Parameters.AddWithValue("@MenuId", MenuId);
                    cmd.Parameters.AddWithValue("@LeadId", LeadId);
                    cmd.Parameters.AddWithValue("@UserId", UserId);
                    cmd.Parameters.AddWithValue("@SubscriptionType", SubscriptionType);
                    cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Status", Status);
                    cmd.Parameters.AddWithValue("@Description", Description);
                    cmd.Parameters.AddWithValue("@FromDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@ToDate", DateTime.Now);

                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            this.BindGrid();
        }

        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            this.BindGrid();
        }

        protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            int Id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            string ProductId = (row.FindControl("txtProductId") as TextBox).Text;
            string MenuId = (row.FindControl("txtMenuId") as TextBox).Text;
            string LeadId = (row.FindControl("txtLeadId") as TextBox).Text;
            string UserId = (row.FindControl("txtUserId") as TextBox).Text;
            string SubscriptionType = (row.FindControl("txtSubscriptionType") as TextBox).Text;
            string Status = (row.FindControl("txtStatus") as TextBox).Text;
            string Description = (row.FindControl("txtDescription") as TextBox).Text;
            string FromDate = (row.FindControl("txtFromDate") as TextBox).Text;
            string ToDate = (row.FindControl("txtToDate") as TextBox).Text;

            //string query = "UPDATE Customers SET Name=@Name, Country=@Country WHERE CustomerId=@CustomerId";
            string query = "UPDATE SalesPackageSubscriptions SET ProductId=@ProductId, MenuId=@MenuId, LeadId=@LeadId, UserId=@UserId, SubscriptionType=@SubscriptionType, Status=@Status,Description=@Description, FromDate=@FromDate, ToDate=@ToDate  WHERE Id=@Id";
            string constr = ConfigurationManager.ConnectionStrings["ChemAnalystContext"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@Id", Id);
                    cmd.Parameters.AddWithValue("@ProductId", ProductId);
                    cmd.Parameters.AddWithValue("@MenuId", MenuId);
                    cmd.Parameters.AddWithValue("@LeadId", LeadId);
                    cmd.Parameters.AddWithValue("@UserId", UserId);
                    cmd.Parameters.AddWithValue("@SubscriptionType", SubscriptionType);
                    cmd.Parameters.AddWithValue("@Status", Status);
                    cmd.Parameters.AddWithValue("@Description", Description);
                    cmd.Parameters.AddWithValue("@FromDate", FromDate);
                    cmd.Parameters.AddWithValue("@ToDate", ToDate);

                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            GridView1.EditIndex = -1;
            this.BindGrid();
        }

        protected void OnRowCancelingEdit(object sender, EventArgs e)
        {
            GridView1.EditIndex = -1;
            this.BindGrid();
        }

        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int Id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            string query = "DELETE FROM SalesPackageSubscriptions WHERE Id=@Id";
            string constr = ConfigurationManager.ConnectionStrings["ChemAnalystContext"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@Id", Id);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

            this.BindGrid();
        }

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != GridView1.EditIndex)
            {
                (e.Row.Cells[9].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";
            }
        }

        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            this.BindGrid();
        }
    }
}