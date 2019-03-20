using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace jf_web.Application {
    public class MemberReq {
        
        [Required, MinLength(10), MaxLength(10)] 
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