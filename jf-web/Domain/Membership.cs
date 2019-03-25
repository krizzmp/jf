namespace jf_web.Domain {
    public class Membership {
        public Membership(Member member, PaymentMethod paymentMethod) {
            Member = member;
            PaymentMethod = paymentMethod;
        }

        private protected Membership() {
        }

        public int Id { get; set; }
        public Member Member { get; private set; }
        public PaymentMethod PaymentMethod { get; private set; }
    }
}