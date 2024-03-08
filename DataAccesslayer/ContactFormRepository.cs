using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactDetail.DataAccesslayer
{
    public class ContactFormRepository : IContactFormRepository
    {
        private readonly ContactDbContext _CDb;
        public ContactFormRepository(ContactDbContext dbContext)
        {
            _CDb = dbContext;
        }
        public ContactForm GetByNumber(long id)
        {
            try
            {
                var num = _CDb.Contacts.FromSqlRaw<ContactForm>($"select * from Contacts where EmployeeId={id}");
                return num.ToList().FirstOrDefault();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<ContactForm> GetAllContact()
        {
            try
            {
                IEnumerable<ContactForm> result = _CDb.Contacts.FromSqlRaw<ContactForm>($"exec ReadContact");
                return result.ToList();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public void ContactInsert(ContactForm contact)
        {
            try
            {
                _CDb.Database.ExecuteSqlRaw($"exec ContactInsert '{contact.Name}','{contact.Address}','{contact.City}','{contact.State}','{contact.Zip}','{contact.Country}','{contact.MobileNumber}','{contact.Email}',{contact.Comments}'");
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void ContactUpdate(long id, ContactForm con)
        {
            try
            {
                _CDb.Database.ExecuteSqlRaw($"exec ContactUpdate'{id}','{con.Name}','{con.Address}','{con.City}','{con.State}','{con.Zip}','{con.Country}',{con.MobileNumber}','{con.Email}','{con.Comments}'");
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public void ContactDelete(long id)
        {
            try
            {
                var result = _CDb.Database.ExecuteSqlRaw($"exec ContactDelete {id}");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

    


        

