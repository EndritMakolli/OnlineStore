using MediatR;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]  // Each controller has a route, so our API or our projects or application knows where to redirect this
    public class BaseApiController : ControllerBase // every controller is going to derive from controller base.
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??=
            HttpContext.RequestServices.GetService<IMediator>();
    }
}
 // this means other controller will aready have the API attributes and root  when they inherit this  