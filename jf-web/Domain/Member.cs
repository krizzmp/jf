using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace jf_web.Domain {
    public class Member {
        public Member(string cpr, string name) {
            Cpr = cpr;
            Name = name;
        }

        public Member() {
        }

        [Key] public string Cpr { get; private set; }
        public string Name { get; private set; }
        public List<Membership> Memberships { get; set; } = new List<Membership>();

        public void AddMembership(PaymentMethod paymentMethod) {
            Memberships.Add(new Membership(this, paymentMethod));
        }
    }
}