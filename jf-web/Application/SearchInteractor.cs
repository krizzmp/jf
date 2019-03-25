using jf_web.Application.Interfaces;

namespace jf_web.Application
{
    public class SearchInteractor
    {
        private readonly IMembershipRepo _repo;
        private readonly ISearchPresenter _presenter;

        public SearchInteractor(IMembershipRepo repo, ISearchPresenter presenter) {
            _repo = repo;
            _presenter = presenter;
        }
        internal void Perform(string q)
        {
            var members = _repo.Search(q);
            _presenter.ReturnObj(members);
        }
    }
}