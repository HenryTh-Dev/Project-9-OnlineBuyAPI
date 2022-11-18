using OnlineBuy.Domain.Validate;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OnlineBuy.Domain.Models
{
    public class Purchase
    {
        public int Id { get; private set; }
        public int ProductId { get; private set; }
        public int PersonId { get; private set; }
        public DateTime CreatedOn { get; private set; }

        #region VirtualClass
        public Person Person { get; set; }
        public Product Product { get; set; }
        #endregion

        public Purchase(int productId, int personId)
        {
            Validation(productId, personId);
        }
        public Purchase(int id, int productId, int personId)
        {
            DomainValidationException.When(id < 0, "ID must be informed");
            Id = id;
            Validation(productId, personId);
        }

        private void Validation(int productId, int personId)
        {
            
            DomainValidationException.When(personId < 0, "ID Person must be informed");
            DomainValidationException.When(productId < 0, "ID Product must be informed");

            ProductId = productId;
            PersonId = personId;
            CreatedOn = DateTime.Now;
        }
    }
}
