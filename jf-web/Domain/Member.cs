using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace jf_web.Domain {
    public class Member {
        public Member(string cpr, string name) {
            if (cpr.Length != 10) {
                throw new InvalidCprException();
            }
            Cpr = cpr;
            Name = name;
        }

        protected Member() {
        }

        [Key] public string Cpr { get; private set; }
        public string Name { get; private set; }
        public List<Membership> Memberships { get; set; } = new List<Membership>();

        public void AddMembership(PaymentMethod paymentMethod) {
            Memberships.Add(new Membership(this, paymentMethod));
        }
    }
}