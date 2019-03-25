namespace jf_web.Domain {
    public class Employee : Member {
        public string Address { get; private set; }
        public string Phone { get; private set; }
        public string Company { get; private set; }
        public string Email { get; private set; }
        public bool Magazine { get; private set; }

        public Employee(
            string cpr, string name, string address, string phone, string company, string email, bool magazine
        ) : base(cpr, name) {
            Address = address;
            Phone = phone;
            Company = company;
            Email = email;
            Magazine = magazine;
        }

        private protected Employee() {
        }
    }
}