using System.Collections.Generic;

namespace jf_web.Application {
    public class CreateMembershipReq {
        public EmployeeReq EmployeeMember { get; set; }
        public IEnumerable<MemberReq> Spouses { get; set; }

        public override string ToString() {
            return $"{nameof(EmployeeMember)}: {EmployeeMember}, {nameof(Spouses)}: {Spouses}";
        }
    }
}