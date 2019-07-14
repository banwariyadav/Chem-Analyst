using ChemAnalyst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ChemAnalyst.DAL
{
    public class ContactDataStore
    {
        private ChemAnalystContext _context = new ChemAnalystContext();

        public List<SA_Contact> GetContactList()
        {
            return _context.SA_Contact.ToList();

        }
        public async Task<bool> AddContact(SA_Contact News)
        {
            //  News.CreatedDate = DateTime.Now;
            _context.SA_Contact.Add(News);
            int x = await _context.SaveChangesAsync();
            return x == 0 ? false : true;
        }
    }
}