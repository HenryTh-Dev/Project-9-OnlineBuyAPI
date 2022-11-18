using OnlineBuy.Domain.Validate;

namespace OnlineBuy.Domain.Models
{
    public sealed class Person
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Ssn { get; private set; }
        public string Phone { get; private set; }

        #region VirtualClass
        public ICollection<Purchase> Purchases { get; set; }
        #endregion

        public Person(string ssn, string name, string phone)
        {
            Validation(ssn, name, phone);
            Purchases = new List<Purchase>();
        }
        public Person(int id, string name, string ssn, string phone)
        {
            DomainValidationException.When(id < 0, "ID must be greater than 0");
            Id = id;
            Validation(ssn, name, phone);
            Purchases = new List<Purchase>();
        }
        private void Validation(string ssn, string name, string phone)
        {
            DomainValidationException.When(string.IsNullOrEmpty(name), "Name must be informed");
            DomainValidationException.When(string.IsNullOrEmpty(ssn), "Social Security Number must be informed");
            DomainValidationException.When(string.IsNullOrEmpty(phone), "Phone must be informed");

            Ssn = ssn;
            Name = name;
            Phone = phone; 
        }
    }
}
