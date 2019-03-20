using System.ComponentModel.DataAnnotations;

namespace jf_web.Application {
    public class EmployeeReq : MemberReq {
        [Required, MinLength(1)]
        public string Address { get; set; }
    }
}