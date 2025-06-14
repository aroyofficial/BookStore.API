using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Shuru.API.Exceptions;
using Shuru.API.Common;
using Shuru.API.Enumerations;
using System.Net;

namespace Shuru.API.Attributes
{
    /// <summary>
    /// Exception filter attribute to handle custom application exceptions and return standardized API responses.
    /// </summary>
    public class APIExceptionFilterAttribute : ExceptionFilterAttribute
    {
        /// <summary>
        /// Called when an exception occurs during the execution of an action.
        /// </summary>
        /// <param name="context">The exception context.</param>
        public override void OnException(ExceptionContext context)
        {
            APIResponse<string> response;
            HttpStatusCode statusCode;

            if (context.Exception is BaseException baseException)
            {
                statusCode = MapErrorCodeToHttpStatus(baseException.ErrorCode);
                response = new APIResponse<string>
                {
                    Success = false,
                    Message = baseException.Message,
                    ErrorCode = baseException.ErrorCode
                };
            }
            else
            {
                statusCode = HttpStatusCode.InternalServerError;
                response = new APIResponse<string>
                {
                    Success = false,
                    Message = "An unexpected error occurred.",
                    ErrorCode = ErrorCode.InternalServerError
                };
            }

            context.Result = new ObjectResult(response)
            {
                StatusCode = (int)statusCode
            };

            context.ExceptionHandled = true;
        }

        /// <summary>
        /// Maps custom <see cref="ErrorCode"/> values to corresponding HTTP status codes.
        /// </summary>
        /// <param name="errorCode">The application-defined error code.</param>
        /// <returns>The corresponding HTTP status code.</returns>
        private HttpStatusCode MapErrorCodeToHttpStatus(ErrorCode errorCode)
        {
            return errorCode switch
            {
                ErrorCode.InvalidRequest => HttpStatusCode.BadRequest,
                
                // User-related error codes
                ErrorCode.InvalidEmail => HttpStatusCode.BadRequest,
                ErrorCode.InvalidPassword => HttpStatusCode.BadRequest,
                ErrorCode.InvalidUserCreation => HttpStatusCode.BadRequest,
                ErrorCode.InvalidUserName => HttpStatusCode.BadRequest,
                ErrorCode.MissingCredentials => HttpStatusCode.BadRequest,
                ErrorCode.WeakPassword => HttpStatusCode.BadRequest,
                ErrorCode.UserAlreadyExists => HttpStatusCode.Conflict,
                ErrorCode.UserNotFound => HttpStatusCode.NotFound,

                // Book-related error codes
                ErrorCode.BookTitleRequired => HttpStatusCode.BadRequest,
                ErrorCode.BookAuthorRequired => HttpStatusCode.BadRequest,
                ErrorCode.BookInvalidPrice => HttpStatusCode.BadRequest,
                ErrorCode.BookInvalidPublishedDate => HttpStatusCode.BadRequest,
                ErrorCode.BookInvalidStockCount => HttpStatusCode.BadRequest,
                ErrorCode.InvalidPublishedStartDate => HttpStatusCode.BadRequest,
                ErrorCode.InvalidPublishedEndDate => HttpStatusCode.BadRequest,
                ErrorCode.InvalidPublishedDateRange => HttpStatusCode.BadRequest,

                _ => HttpStatusCode.InternalServerError
            };
        }
    }
}
