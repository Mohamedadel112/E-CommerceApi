using Microsoft.AspNetCore.Mvc;
using Shared.ErrorsModel;
using System.Net;

namespace E_CommerceProjectApi.Factories
{
    public class ApiResponseFactory
    {

        public static IActionResult GetValidateErrors(ActionContext context)
        {
            var Errors = context.ModelState.Where(e => e.Value.Errors.Any()).Select(

                error => new ValidationErrors
                {
                    Field = error.Key,
                    Errors = error.Value.Errors.Select(e => e.ErrorMessage)

                }

               );

            var response = new ValidationErrorsResponse() 
            {
                Errors = Errors,
                MsgErrors = "Validation Errors",
                StatusCcode = (int)HttpStatusCode.BadRequest

            };
            return new BadRequestObjectResult(response);

        }
    }
}
