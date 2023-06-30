using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NSE.Core.Communication;

namespace NSE.WebApi.Core.Controllers
{
    [ApiController]
    public abstract class MainController : Controller
    {
        protected ICollection<string> Errors = new List<string>();

        protected ActionResult CustomResponse(object result = null)
        {
            if (IsValid()) return Ok(result);

            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                { "Messages", Errors.ToArray() }
            }));
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            var errors = modelState.Values.SelectMany(erro => erro.Errors);

            foreach (var error in errors) AddProcessingError(error.ErrorMessage);

            return CustomResponse();
        }

        protected ActionResult CustomResponse(ValidationResult validationResult)
        {
            validationResult.Errors.ForEach(erro => AddProcessingError(erro.ErrorMessage));

            return CustomResponse();
        }

        protected ActionResult CustomResponse(ResponseResult response)
        {
            HasResponseErrors(response);

            return CustomResponse();
        }

        protected bool HasResponseErrors(ResponseResult response)
        {
            if (response == null || !response.Errors.Messages.Any()) return false;

            response.Errors.Messages.ForEach(message => AddProcessingError(message));

            return true;
        }

        protected bool IsValid() => !Errors.Any();

        protected void AddProcessingError(string error) => Errors.Add(error);

        protected void CleanProcessingErrors() => Errors.Clear();
    }
}
