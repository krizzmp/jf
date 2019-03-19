using jf_web.Domain;

namespace jf_web.Application {
    public class CreateMembershipInteractor {
        private readonly ICreateMembershipPresenter _cmPresenter;
        private readonly IMembershipRepo _mRepo;

        public CreateMembershipInteractor(ICreateMembershipPresenter cmPresenter, IMembershipRepo mRepo) {
            _cmPresenter = cmPresenter;
            _mRepo = mRepo;
        }

        public void Perform(CreateMembershipReq value) {
            var primaryMember = CreatePrimaryMember(value.EmployeeMember);
            _mRepo.SaveMember(primaryMember);

            foreach (var spouse in value.Spouses) {
                var m = CreateMember(spouse);
                _mRepo.SaveMember(m);
            }

            _cmPresenter.Ok();
        }

        private Member CreatePrimaryMember(EmployeeReq employeeMember) {
            if (_mRepo.Exists(employeeMember.Cpr)) {
                throw new MemberAlreadyExistsException();
            }

            var member = MemberFactory(employeeMember);
            member.AddMembership(new PaymentMethod());
            return member;
        }

        private static Member MemberFactory(MemberReq memberReq) {
            return memberReq switch {
                EmployeeReq e => new Employee(e.Cpr, e.Name, e.Address),
                MemberReq m => new Member(m.Cpr, m.Name)
                };
        }

        private Member CreateMember(MemberReq employeeMember) {
            if (_mRepo.Exists(employeeMember.Cpr)) {
                throw new MemberAlreadyExistsException();
            }

            var member = new Member(employeeMember.Cpr, employeeMember.Name);
            member.AddMembership(new PaymentMethod());
            return member;
        }
    }
}