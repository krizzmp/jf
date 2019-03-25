using System.Collections.Generic;
using jf_web.Domain;

namespace jf_web.Application.Interfaces {
    public interface IMembershipRepo {
        void SaveMember(Member member);
        bool Exists(string s);
        IEnumerable<Member> Search(string q);
    }
}