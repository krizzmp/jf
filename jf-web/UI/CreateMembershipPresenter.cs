using jf_web.Application.Interfaces;

namespace jf_web.UI {
    public class CreateMembershipPresenter : ICreateMembershipPresenter {
        private readonly CreateMembershipView _cmView;

        public CreateMembershipPresenter(CreateMembershipView cmView) {
            _cmView = cmView;
        }

        public void Ok() {
            _cmView.Result = "ok";
        }
    }
}