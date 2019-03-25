using System.Collections.Generic;
using System.Linq;
using jf_web.Application;
using jf_web.Application.Interfaces;
using jf_web.Core;
using jf_web.Domain;
using jf_web.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace TestProject1 {
    [TestClass]
    public class CreateMembershipTest {
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
        public void SaveSingleEmployeeView() {
            //arrange
            var t = new CreateMembershipReq {
                Member = new EmployeeReq {
                    Cpr = "2805922031",
                    Name = "kmp",
                    Address = "addr",
                    Memberships = new List<string> {"JernbaneFritid"},
                    PaymentMethod = "Salary"
                },
                Spouses = new List<MemberReq>()
            };
            // act
            _controller.Perform(t);
            var result = _createMembershipView.Result;
            Assert.AreEqual("ok", result);
        }

        [TestMethod]
        public void SaveSingleEmployee() {
            //arrange
            var t = new CreateMembershipReq {
                Member = new EmployeeReq {
                    Cpr = "2805922031",
                    Name = "kmp",
                    Address = "addr",
                    Memberships = new List<string> {"JernbaneFritid"},
                    PaymentMethod = "Salary"
                },
                Spouses = new List<MemberReq>()
            };
            // act
            _controller.Perform(t);

            //assert
            _mock.Verify(r => r.SaveMember(
                It.Is<Employee>(m =>
                    m.Cpr == "2805922031" &&
                    m.Name == "kmp" &&
                    m.Address == "addr" &&
                    m.Memberships.Count == 1 &&
                    m.Memberships.First().PaymentMethod != null &&
                    m.Memberships.First().Member == m
                )
            ), Times.Once);
        }

        [TestMethod]
        public void CreateExistingEmployeeShouldFail() {
            //arrange
            var t = new CreateMembershipReq {
                Member = new EmployeeReq {
                    Cpr = "0000000000",
                    Name = "kmp",
                    Address = "addr",
                    Memberships = new List<string> {"JernbaneFritid"},
                    PaymentMethod = "Salary"
                },
                Spouses = new List<MemberReq>()
            };
            _mock.Setup(r => r.Exists("0000000000")).Returns(true);
            // act & assert
            Assert.ThrowsException<MemberAlreadyExistsException>(() => { _controller.Perform(t); });
        }

        [TestMethod]
        public void SaveEmployeeAndOneSpouse() {
            //arrange
            var t = new CreateMembershipReq {
                Member = new EmployeeReq {
                    Cpr = "2805922031",
                    Name = "kmp",
                    Address = "addr",
                    Memberships = new List<string> {"JernbaneFritid"},
                    PaymentMethod = "Salary"
                },
                Spouses = new List<MemberReq> {
                    new MemberReq {
                        Cpr = "2805922032",
                        Name = "kmp2",
                        Memberships = new List<string> {"JernbaneFritid"},
                        PaymentMethod = "Salary"
                    }
                }
            };
            // act
            _controller.Perform(t);

            //assert
            _mock.Verify(r => r.SaveMember(
                It.Is<Employee>(m =>
                    m.Cpr == "2805922031" &&
                    m.Name == "kmp" &&
                    m.Address == "addr" &&
                    m.Memberships.Count == 1 &&
                    m.Memberships.First().PaymentMethod != null &&
                    m.Memberships.First().Member == m
                )
            ), Times.Once);
            _mock.Verify(r => r.SaveMember(
                It.Is<Member>(m =>
                    m.Cpr == "2805922032" &&
                    m.Name == "kmp2" &&
                    m.Memberships.Count == 1 &&
                    m.Memberships.First().PaymentMethod != null &&
                    m.Memberships.First().Member == m
                )
            ), Times.Once);
        }
    }
}