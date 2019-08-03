using System;
using jf_web.Application;
using jf_web.Application.Interfaces;
using jf_web.Domain;
using jf_web.UI;
using Microsoft.AspNetCore.Mvc;

namespace jf_web.Routes
{
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly CreateMembershipController _cmController;

        public ValuesController(CreateMembershipController cmController)
        {
            _cmController = cmController;
        }


        [HttpPost("createMembers")]
        public string Post([FromBody] CreateMembershipReq value, [FromServices] CreateMembershipView view)
        {
            _cmController.Perform(value);
            return view.Result;
        }
        //[HttpPost("createMembers2")]
        // public string Post2([FromBody] CreateMembershipReq value, [FromServices] CreateMembershipView view) {
        //return _cmPresenter(_cmInteractor(_cmController(value)));
        // }
        [HttpPost("addTournamentPin/{cpr}")]
        public string AddTournamentPin(
            [FromRoute] string cpr, [FromBody] TournamentReq tournament, [FromServices] IMembershipRepo repo
        )
        {
            var member = repo.GetMember(cpr);
            member.TournamentPin = new TournamentPin(tournament.Date);
            repo.UpdateMember(member);
            return "ok";
        }

        [HttpPost("updateName/{cpr}")]
        public string UpdateName(
            [FromRoute] string cpr, [FromBody] NameReq nameReq, [FromServices] IMembershipRepo repo
        )
        {
            var member = repo.GetMember(cpr);
            member.Name = nameReq.Name;
            repo.UpdateMember(member);
            return "ok";
        }

        [HttpPost("updateAddress/{cpr}")]
        public string UpdateAddress(
            [FromRoute] string cpr, [FromBody] AddressReq addressReq, [FromServices] IMembershipRepo repo
        )
        {
            var member = repo.GetMember(cpr);
            if (member is Employee e)
            {
                e.Address = addressReq.Address;
                repo.UpdateMember(e);
            }

            return "ok";
        }

        [HttpPost("updateCompany/{cpr}")]
        public string UpdateCompany(
            [FromRoute] string cpr, [FromBody] CompanyReq companyReq, [FromServices] IMembershipRepo repo
        )
        {
            var member = repo.GetMember(cpr);
            if (member is Employee e)
            {
                e.Company = companyReq.Company;
                repo.UpdateMember(e);
            }

            return "ok";
        }

        [HttpPost("updatePhone/{cpr}")]
        public string UpdatePhone(
            [FromRoute] string cpr, [FromBody] PhoneReq phoneReq, [FromServices] IMembershipRepo repo
        )
        {
            var member = repo.GetMember(cpr);
            if (member is Employee e)
            {
                e.Phone = phoneReq.Phone;
                repo.UpdateMember(e);
            }

            return "ok";
        }
        [HttpPost("updateEmail/{cpr}")]
        public string UpdateEmail(
            [FromRoute] string cpr, [FromBody] EmailReq emailReq, [FromServices] IMembershipRepo repo
        )
        {
            var member = repo.GetMember(cpr);
            if (member is Employee e)
            {
                e.Email = emailReq.Email;
                repo.UpdateMember(e);
            }

            return "ok";
        }

        [HttpPost("updateMagazine/{cpr}")]
        public string UpdateMagazine(
            [FromRoute] string cpr, [FromBody] MagazineReq magazineReq, [FromServices] IMembershipRepo repo
        )
        {
            var member = repo.GetMember(cpr);
            if (member is Employee e)
            {
                e.Magazine = magazineReq.Magazine;
                repo.UpdateMember(e);
            }

            return "ok";
        }

        [HttpGet("search")]
        public object Search(
            [FromQuery] string q, [FromServices] SearchView view, [FromServices] SearchController searchController
        )
        {
            searchController.Perform(q);
            return view.Result;
        }
    }

    public class NameReq
    {
        public string Name { get; set; }
    }

    public class AddressReq
    {
        public string Address { get; set; }
    }

    public class CompanyReq
    {
        public string Company { get; set; }
    }

    public class PhoneReq
    {
        public string Phone { get; set; }
    }

    public class MagazineReq
    {
        public bool Magazine { get; set; }
    }
    public class EmailReq
    {
        public string Email { get; set; }
    }

    public class TournamentReq
    {
        public DateTime Date { get; set; }
    }
}