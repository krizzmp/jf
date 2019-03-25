using System.Collections.Generic;
using jf_web.Application.Interfaces;
using jf_web.Domain;

namespace jf_web.DataAccess {
    public class MembershipRepo : IMembershipRepo {
        private readonly ApplicationContext _repo;

        public MembershipRepo(ApplicationContext repo) {
            _repo = repo;
        }

        public void SaveMember(Member member) {
            _repo.Add(member);
            _repo.SaveChanges();
        }

        public bool Exists(string s) {
            return _repo.Members.Find(s) != null;
        }

        public IEnumerable<Member> Search(string q)
        {
            throw new System.NotImplementedException();
        }
    }
}