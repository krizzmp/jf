using jf_web.Domain;

namespace jf_web.Application {
    public class CreateMembershipInteractor {
        private readonly ICreateMembershipPresenter _cmPresenter;
        private readonly IMembershipRepo _mRepo;

        public CreateMembershipInteractor(
            ICreateMembershipPresenter cmPresenter,
            IMembershipRepo mRepo
        ) {
            _cmPresenter = cmPresenter;
            _mRepo = mRepo;
        }

        public void Perform(CreateMembershipReq value) {
            var primaryMember = CreatePrimaryMember(value.EmployeeMember);
            primaryMember.AddMembership(new PaymentMethod());
            _mRepo.SaveMember(primaryMember);

            foreach (var spouse in value.Spouses) {
                var m = new Member(spouse.Cpr, spouse.Name);
                m.AddMembership(new PaymentMethod());
                _mRepo.SaveMember(m);
            }

            _cmPresenter.Ok();
        }

        private Employee CreatePrimaryMember(EmployeeReq employeeMember) {
            return new Employee(employeeMember.Cpr, employeeMember.Name, employeeMember.Address);
        }
    }
}