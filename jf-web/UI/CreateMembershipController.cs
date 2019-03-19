using jf_web.Application;

namespace jf_web.UI {
    public class CreateMembershipController {
        private readonly CreateMembershipInteractor _cmInteractor;

        public CreateMembershipController(CreateMembershipInteractor cmInteractor) {
            _cmInteractor = cmInteractor;
        }

        public void Perform(CreateMembershipReq value) {
            _cmInteractor.Perform(value);
        }
    }
}