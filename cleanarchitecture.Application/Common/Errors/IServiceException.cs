
using System.Net;

namespace cleanarchitecture.Application.Common.Errors;
public interface IServiceException
{
    public HttpStatusCode StatusCode { get;}
    public string ErrorMessage { get;}
}