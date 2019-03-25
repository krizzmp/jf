using jf_web.Application.Interfaces;

namespace jf_web.UI {
    class SearchPresenter : ISearchPresenter {
        private readonly SearchView _searchView;

        public SearchPresenter(SearchView searchView) {
            _searchView = searchView;
        }
        public void ReturnObj(object members) {
            _searchView.Result = members;
        }
    }
}