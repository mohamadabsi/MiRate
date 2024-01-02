using FluentValidation.Results;

namespace Framework.Core.Ddd.Application
{
    public interface IDomainVaidator<T>
    {
         ValidationResult Validate(T instance); 
    }
}