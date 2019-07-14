using ChemAnalyst.Models;
using ChemAnalyst.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ChemAnalyst.DAL
{
    public class LeadDAL
    {
        private ChemAnalystContext _context = new ChemAnalystContext();

        public List<Lead_Master> GetLeadList()
        {
            return _context.Lead_Master.ToList();

        }
        internal Lead_Master GetLeadByid(int id)
        {
            var data = _context.Lead_Master.Where(x => x.Id == id).SingleOrDefault();
            if (data != null)
            {
                return data;
            }
            else
            {
                return null;
            }
        }
        public List<Lead_Master> GetLeadListforothers(string id)
        {
            return _context.Lead_Master.Where(x => x.AssignTo == id).ToList();

        }

        public List<SelectListItem> GetUserList()
        {
            return (from p in _context.SA_User.AsEnumerable().Where(x => x.Role == "Sales")
                    select new SelectListItem
                    {
                        Text = p.Fname + " " + p.Lname,
                        Value = p.id.ToString()
                    }).ToList();

        }

        public void AddLeadDetails(Lead_Master Lead)
        {
            _context.Entry(Lead).State = EntityState.Modified;
            //  Role.ModeifiedDate = DateTime.Now;
            int x = _context.SaveChanges();
            // return x == 0 ? false : true;
        }

        public void AddSubscrption(Lead_Master lead)
        {
            var param = new List<SqlParameter>();
            param.Add(new SqlParameter("@p0", lead.Id));
            param.Add(new SqlParameter("@p1", lead.Status));
            param.Add(new SqlParameter("@p2", lead.AssignTo));
            _context.Database.ExecuteSqlCommand("sp_AddDetailsSubscription @p0, @p1,@p2", parameters: param.ToArray());

        }

        public List<CustCompanyVM> GetCompanies(int leadId)
        {
            List<CustCompanyVM> lstCompanies = new List<CustCompanyVM>();
            string cnnString = System.Configuration.ConfigurationManager.ConnectionStrings["ChemAnalystContext"].ConnectionString;
            SqlConnection cnn = new SqlConnection(cnnString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "sp_GetCompanies";
            //add any parameters the stored procedure might require
            cmd.Parameters.Add(new SqlParameter("@LeadId", leadId));
            cnn.Open();
            //object o = cmd.ExecuteScalar();

            using (SqlDataReader rdr = cmd.ExecuteReader())
            {

                while (rdr.Read())
                {
                    CustCompanyVM objCom = new CustCompanyVM();

                    objCom.id = Convert.ToInt32(rdr["id"]);
                    objCom.Name = rdr["Name"] != null ? rdr["Name"].ToString() : "N/A";
                    objCom.EmailId = rdr["EmailId"] != null ? rdr["EmailId"].ToString() : "N/A";
                    objCom.Address = rdr["Address"] != null ? rdr["Address"].ToString() : "N/A";

                    objCom.Description = rdr["Description"] != null ? rdr["Description"].ToString() : "N/A";
                    objCom.Logo = rdr["Logo"] != null ? rdr["Logo"].ToString() : "N/A";
                    objCom.RegDate = rdr["RegDate"] != null ? Convert.ToDateTime(rdr["RegDate"]).ToString("dd/MM/yyyy") : "N/A";
                    objCom.CIN = rdr["CIN"] != null ? rdr["CIN"].ToString() : "N/A";
                    objCom.Category = rdr["Category"] != null ? rdr["Category"].ToString() : "N/A";
                    objCom.NOE = rdr["NOE"] != null ? rdr["NOE"].ToString() : "N/A";
                    objCom.CEO = rdr["CEO"] != null ? rdr["CEO"].ToString() : "N/A";
                    objCom.website = rdr["website"] != null ? rdr["website"].ToString() : "N/A";
                    objCom.phoneNo = rdr["phoneNo"] != null ? rdr["phoneNo"].ToString() : "N/A";
                    objCom.fax = rdr["fax"] != null ? rdr["fax"].ToString() : "N/A";

                    lstCompanies.Add(objCom);

                }

            }
            cnn.Close();
            return lstCompanies;

        }

        public List<SubscriptionViewModel> SubscriptionListforadmin(string loggeduser)
        {

            var query = from sales in _context.SalesPackageSubscription
                        join sub in _context.SubscriptionType on sales.SubscriptionType equals sub.id
                        //join mod in _context.Module on sales.MenuId equals mod.id
                        join lead in _context.Lead_Master on sales.LeadId equals lead.Id
                        //where lead.AssignTo.Trim().Equals(loggeduser)
                        select new SubscriptionViewModel
                        {
                            SId = sales.Id,
                            Status = sales.Status,
                            Name = lead.Name,
                            Organisation = lead.Organisation,
                            Phone = lead.Phone,
                            CorpEmail = lead.CorpEmail,
                            Designation = lead.Designation,
                            Subscribe = sales.MenuId,
                            ExpiryDate = sales.ToDate,
                            Package = sub.Name,
                            LeadId = lead.Id
                        };
            List<SubscriptionViewModel> lst = new List<SubscriptionViewModel>();
            foreach (SubscriptionViewModel sub in query)
            {
                sub.PackageStatus = sub.ExpiryDate.Value.Date <= DateTime.Now.Date ? "Expired" : "";
                sub.Status = sub.ExpiryDate.Value.Date <= DateTime.Now.Date ? "Expired" : "Active";
                lst.Add(sub);

            }
            return lst;
        }
        public List<SubscriptionViewModel> SubscriptionList(string loggeduser)
        {

            var query = from sales in _context.SalesPackageSubscription
                        join sub in _context.SubscriptionType on sales.SubscriptionType equals sub.id
                        //join mod in _context.Module on sales.MenuId equals mod.id
                        join lead in _context.Lead_Master on sales.LeadId equals lead.Id
                        where lead.AssignTo.Equals(loggeduser)
                        select new SubscriptionViewModel
                        {
                            SId = sales.Id,
                            Status = sales.Status,
                            Name = lead.Name,
                            Organisation = lead.Organisation,
                            Phone = lead.Phone,
                            CorpEmail = lead.CorpEmail,
                            Designation = lead.Designation,
                            Subscribe = sales.MenuId,
                            ExpiryDate = sales.ToDate,
                            Package = sub.Name,
                            LeadId = lead.Id,

                        };
            List<SubscriptionViewModel> lst = new List<SubscriptionViewModel>();
            foreach (SubscriptionViewModel sub in query)
            {
                sub.PackageStatus = sub.ExpiryDate.Value.Date <= DateTime.Now.Date ? "Expired" : "";
                sub.Status = sub.ExpiryDate.Value.Date <= DateTime.Now.Date ? "Expired" : "Active";
                lst.Add(sub);

            }
            return lst;
        }
    }
}