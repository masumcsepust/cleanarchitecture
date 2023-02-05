
using cleanarchitecture.Application.Authentication.Commands;
using cleanarchitecture.Application.Services.Authentication.Common;
using ErrorOr;
using FluentValidation;
using MediatR;

namespace cleanarchitecture.Application.Common.Behaviors;

public class ValidationBehavior<TRequest, TResponse> : 
    IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : IErrorOr
{
    private readonly IValidator<TRequest>? _validator;

    public ValidationBehavior(IValidator<TRequest>? validator)
    {
        _validator = validator;
    }

    public async Task<TResponse> Handle(
        TRequest request, 
        RequestHandlerDelegate<TResponse> next, 
        CancellationToken cancellationToken)
    {
        // before the handler
        if(_validator is null) 
            return await next();

        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if(validationResult.IsValid) 
        {
            return await next();
        }

        var errors = validationResult.Errors.ConvertAll(validationFailure => Error.Validation(
            validationFailure.PropertyName,
            validationFailure.ErrorMessage
        ));

        //var result = await next();

        // after the handler

        return (dynamic)errors;
    }
}