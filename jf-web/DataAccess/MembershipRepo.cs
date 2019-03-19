using System;
using jf_web.Application;
using jf_web.Domain;

namespace jf_web.DataAccess {
    public class MembershipRepo : IMembershipRepo {
        private readonly SchoolContext _repo;

        public MembershipRepo(SchoolContext repo) {
            _repo = repo;
        }

        public void Save(CreateMembershipReq value) {
            Console.WriteLine(value);
        }

        public void SaveMember(Member member) {
            _repo.Add(member);
            _repo.SaveChanges();
            Console.WriteLine(member);
        }

        public void SaveEmployee(Employee member) {
            _repo.Add(member);
            _repo.SaveChanges();
            Console.WriteLine(member);
        }
    }
}