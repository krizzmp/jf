using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using jf_web.Core;

namespace jf_web.Domain {
    public class Member {
        public Member(string cpr, string name) {
            if (cpr.Length != 10) {
                throw new InvalidCprException();
            }
            Cpr = cpr;
            Name = name;
        }

        private protected Member() {
        }

        [Key] public string Cpr { get; private set; }
        public string Name { get; set; }
        public List<Membership> Memberships { get; } = new List<Membership>();
        public TournamentPin? TournamentPin { get; set; }

        public void AddMembership(PaymentMethod paymentMethod) {
            Memberships.Add(new Membership(this, paymentMethod));
        }
    }

    public struct TournamentPin {
        public TournamentPin(DateTime achieved) {
            Achieved = achieved;
        }

        public DateTime Achieved { get; set; }
    }
}