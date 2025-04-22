using Microsoft.AspNetCore.Mvc;
using Presentation.Controllers.Basket;
using Shared.DTOs;
using Shared.ErrorsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    [ApiController]
    [Route("api/[controller]")]
    [ProducesResponseType(typeof(ErrorsDetails), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(ErrorsDetails), (int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ValidationErrorsResponse), (int)HttpStatusCode.BadRequest)]
    public class ApiController: ControllerBase
    {
    }
}
