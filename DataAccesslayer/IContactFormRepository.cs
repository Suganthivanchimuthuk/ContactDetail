using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactDetail.DataAccesslayer
{
    public interface IContactFormRepository
    {
        public void ContactInsert(ContactForm contact);
        public IEnumerable<ContactForm> GetAllContact();
        public ContactForm GetByNumber(long id);
        public void ContactUpdate(long id, ContactForm em);
        public void ContactDelete(long id);
    }
}
