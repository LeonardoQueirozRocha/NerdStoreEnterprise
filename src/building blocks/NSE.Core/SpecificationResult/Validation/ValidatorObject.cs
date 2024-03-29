﻿using FluentValidation.Results;

namespace NSE.Core.SpecificationResult.Validation
{
    public abstract class ValidatorObject<T>
    {
        protected readonly ObjectAbstractValidator<T> Validator = new ObjectAbstractValidator<T>();
        private ValidationResult ValidationResult { get; set; }

        protected bool Validate(T obj, ValidationResult validationResult)
        {
            ValidationResult = Validator.Validate(obj);

            ValidationResult.Errors.ForEach(error => validationResult.Errors.Add(error));

            return ValidationResult.IsValid;
        }
    }
}
