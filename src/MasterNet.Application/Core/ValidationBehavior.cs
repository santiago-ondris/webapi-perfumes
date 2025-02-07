using System.ComponentModel.DataAnnotations;
using FluentValidation;
using MediatR;

namespace MasterNet.Application.Core
{
    public sealed class ValidationBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse> where TRequest : ICommandBase
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(
            TRequest request, 
            RequestHandlerDelegate<TResponse> next, 
            CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);

            var validationFailures = await Task.WhenAll(
                _validators.Select(validator => validator.ValidateAsync(context))
            );

            var errors = validationFailures
            .Where(validationResult => !validationResult.IsValid)
            .SelectMany(validationResult => validationResult.Errors)
            .Select(validationFailures => new ValidationError(
                validationFailures.PropertyName, 
                validationFailures.ErrorMessage)).ToList();

            if(errors.Any())
            {
                throw new ValidationException(errors);
            }

            return await next();
        }
    }
}