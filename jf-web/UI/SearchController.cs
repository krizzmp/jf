using System;

namespace jf_web.Routes
{
    public class SearchController
    {
        private readonly SearchInteractor _interactor;

        public SearchController(SearchInteractor interactor)
        {
            _interactor = interactor;
        }
        internal void Perform(string q)
        {
            _interactor.Perform(q);
        }
        
    }
}