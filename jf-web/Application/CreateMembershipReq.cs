using System.Collections.Generic;

namespace jf_web.Application {
    public class CreateMembershipReq {
        public EmployeeReq Member { get; set; }
        public IEnumerable<MemberReq> Spouses { get; set; }

        public override string ToString() {
            return $"{nameof(Member)}: {Member}, {nameof(Spouses)}: {Spouses}";
        }
    }
}