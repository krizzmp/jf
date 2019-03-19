namespace jf_web.Domain {
    public class Employee : Member {
        public string Address { get; private set; }

        public Employee(string cpr, string name, string address) : base(cpr, name) {
            Address = address;
        }

        public Employee() {
        }
    }
}