using System.Collections.Generic;

namespace jf_web.Application {
    public class MemberReq {
        public string Cpr { get; set; }
        public string Name { get; set; }
        public List<string> Memberships { get; set; }
        public string PaymentMethod { get; set; }

        public override string ToString() {
            return
                $"{nameof(Cpr)}: {Cpr}, {nameof(Name)}: {Name}, {nameof(Memberships)}: {Memberships}, {nameof(PaymentMethod)}: {PaymentMethod}";
        }
    }
}