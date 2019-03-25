using System;
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<Member> Search(string q) {
            Console.WriteLine(q);
            return _repo.Members.Where(m => m.Cpr.StartsWith(q) || m.Name.Contains(q)).ToList();
        }

        public void UpdateMember(Member member) {
            _repo.SaveChanges();
        }

        public Member GetMember(string cpr) {
            return _repo.Members.Find(cpr);
        }
    }
}