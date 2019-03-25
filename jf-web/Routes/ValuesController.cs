using System;
using jf_web.Application;
using jf_web.Application.Interfaces;
using jf_web.Domain;
using jf_web.UI;
using Microsoft.AspNetCore.Mvc;

namespace jf_web.Routes {
    [ApiController]
    public class ValuesController : ControllerBase {
        private readonly CreateMembershipController _cmController;

        public ValuesController(CreateMembershipController cmController) {
            _cmController = cmController;
        }


        [HttpPost("createMembers")]
        public string Post([FromBody] CreateMembershipReq value, [FromServices] CreateMembershipView view) {
            _cmController.Perform(value);
            return view.Result;
        }

        [HttpPost("addTournamentPin/{cpr:string}")]
        public string AddTournamentPin(
            [FromRoute] string cpr, [FromBody] TournamentReq tournament, [FromServices] IMembershipRepo repo
        ) {
            var member = repo.GetMember(cpr);
            member.TournamentPin = new TournamentPin(tournament.Date);
            repo.UpdateMember(member);
            return "ok";
        }
        [HttpPost("updateName/{cpr:string}")]
        public string UpdateName(
            [FromRoute] string cpr, [FromBody] NameReq nameReq, [FromServices] IMembershipRepo repo
        ) {
            var member = repo.GetMember(cpr);
            member.Name = nameReq.Name;
            repo.UpdateMember(member);
            return "ok";
        }

        [HttpGet("search")]
        public object Search(
            [FromQuery] string q, [FromServices] SearchView view, [FromServices] SearchController searchController
        ) {
            searchController.Perform(q);
            return view.Result;
        }
    }

    public class NameReq {
        public string Name { get; set; }
    }

    public class TournamentReq {
        public DateTime Date { get; set; }
    }
}