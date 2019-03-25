using jf_web.Application;
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

        [HttpGet("search")]
        public string Search([FromQuery] string q, [FromServices] SearchView view, [FromServices] SearchController searchController)
        {
            searchController.Perform(q);
            return view.Result;
        }

    }
}