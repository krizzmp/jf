namespace jf_web.Domain {
    public class Employee : Member {
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }
        public bool Magazine { get; set; }

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