using OnlineBuy.Domain.Validate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBuy.Domain.Models
{
    public sealed class Product
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public string CodErp { get; private set; }

        #region VirtualClass
        public ICollection<Purchase> Purchases { get; set; }
        #endregion

        public Product(string name, string codErp, decimal price)
        {
            Validation(name, codErp, price);
            Purchases = new List<Purchase>(); 
        }
        public Product(int id, string name, string codErp, decimal price)
        {
            DomainValidationException.When(id < 0, "ID must be greater than 0");
            Id = id;
            Validation(name, codErp, price);
            Purchases = new List<Purchase>();
        }

        private void Validation(string name, string codErp, decimal price)
        {
            DomainValidationException.When(string.IsNullOrEmpty(name), "Name must be informed");
            DomainValidationException.When(string.IsNullOrEmpty(codErp), "Erp must be informed");
            DomainValidationException.When(price < 0, "Price must be informed");

            Name = name;
            CodErp = codErp;
            Price = price;
        }
    }
}
