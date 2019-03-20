using jf_web.Application;
using jf_web.Domain;

namespace jf_web.DataAccess {
    public class MembershipRepo : IMembershipRepo {
        private readonly SchoolContext _repo;

        public MembershipRepo(SchoolContext repo) {
            _repo = repo;
        }

        public void SaveMember(Member member) {
            _repo.Add(member);
            _repo.SaveChanges();
        }

        public bool Exists(string s) {
            return _repo.Members.Find(s) != null;
        }
    }
}