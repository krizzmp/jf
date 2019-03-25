using jf_web.Application.Interfaces;
using jf_web.Domain;
using System;
using System.Collections.Generic;

namespace jf_web.Routes
{
    public class SearchInteractor
    {
        private readonly IMembershipRepo _repo;

        public SearchInteractor(IMembershipRepo repo, ISearchPresenter presenter)
        {
            _repo = repo;
        }
        internal void Perform(string q)
        {
            IEnumerable<Member> members = _repo.Search(q);
            _presenter.ReturnObj(members);
        }
    }
}