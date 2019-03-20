using System.Collections.Generic;
using jf_web.Application;
using jf_web.Core;
using jf_web.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace TestProject1 {
    [TestClass]
    public class CreateMemberInteractor {
        private CreateMembershipController _controller;
        private Mock<IMembershipRepo> _mock;
        private CreateMembershipView _createMembershipView;

        [TestInitialize]
        public void Setup() {
            _mock = new Mock<IMembershipRepo>();
            _createMembershipView = new CreateMembershipView();
            _controller = new CreateMembershipController(
                new CreateMembershipInteractor(
                    new CreateMembershipPresenter(
                        _createMembershipView
                    ),
                    _mock.Object
                )
            );
        }
        [TestMethod]
        public void CprMustBeTenDigits() {
            var t = new CreateMembershipReq {
                EmployeeMember = new EmployeeReq {
                    Cpr = "1234",
                    Name = "kmp",
                    Address = "addr",
                    Memberships = new List<string> {"JernbaneFritid"},
                    PaymentMethod = "Salary"
                },
                Spouses = new List<MemberReq>()
            };
            Assert.ThrowsException<InvalidCprException>(() => { _controller.Perform(t); });
        }
    }
}