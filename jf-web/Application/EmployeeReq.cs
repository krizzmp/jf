using System.ComponentModel.DataAnnotations;

namespace jf_web.Application {
    public class EmployeeReq : MemberReq {
        [Required][MinLength(3)]
        public string Address { get; set; }
        [Required][MinLength(8)][Phone]
        public string Phone { get; set; }
        [Required]
        public string Company { get; set; }
        [Required][EmailAddress]
        public string Email { get; set; }
        public bool Magazine { get; set; }

    }
}