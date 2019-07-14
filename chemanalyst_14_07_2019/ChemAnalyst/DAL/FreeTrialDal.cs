using ChemAnalyst.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ChemAnalyst.DAL
{

    public class FreeTrialDal
    {
        private ChemAnalystContext _context = new ChemAnalystContext();

        public async Task<bool> AddFreeTrial(Lead_Master lead)
        {            
            int x = 0;
            try
            {
                _context.Lead_Master.Add(lead);
                x = await _context.SaveChangesAsync();                
            }
            catch (Exception ex)
            {
            }
            return x == 0 ? false : true;
        }
    }
}