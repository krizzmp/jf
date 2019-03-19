using jf_web.Application;
using jf_web.UI;
using Microsoft.AspNetCore.Mvc;

namespace jf_web.Routes {
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase {
        private readonly CreateMembershipController _cmController;

        public ValuesController(CreateMembershipController cmController) {
            _cmController = cmController;
        }

        [HttpPost]
        public object Post([FromBody] CreateMembershipReq value, [FromServices] CreateMembershipView view) {
            _cmController.Perform(value);
            return view.Result;
        }
    }
}