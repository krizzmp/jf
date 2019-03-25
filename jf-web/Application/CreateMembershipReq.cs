using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace jf_web.Application {
    public class CreateMembershipReq {
        public EmployeeReq Member { get; set; }
        public IEnumerable<MemberReq> Spouses { get; set; }

        public override string ToString() {
            return $"{nameof(Member)}: {Member}, {nameof(Spouses)}: {Spouses}";
        }
    }
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
    public class EmployeeReq : MemberReq {
        [Required] [MinLength(3)] public string Address { get; set; }
        [Required] [MinLength(8)] [Phone] public string Phone { get; set; }
        [Required] public string Company { get; set; }
        [Required] [EmailAddress] public string Email { get; set; }
        public bool Magazine { get; set; }
    }
}