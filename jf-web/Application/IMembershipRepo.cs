using jf_web.Domain;

namespace jf_web.Application {
    public interface IMembershipRepo {
        void SaveMember(Member member);
        bool Exists(string s);
    }
}