using jf_web.Domain;

namespace jf_web.Application {
    public interface IMembershipRepo {
        void Save(CreateMembershipReq value);
        void SaveMember(Member member);
        void SaveEmployee(Employee member);
    }
}