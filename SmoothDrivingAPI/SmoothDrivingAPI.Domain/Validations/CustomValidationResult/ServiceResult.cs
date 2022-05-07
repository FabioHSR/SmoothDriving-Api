using System;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothDrivingAPI.Domain.Validation.CustomValidationResult
{
    public class ServiceResult<TEntity>
    {
        public ServiceResult(ValidationResult validationResult)
        {
            ValidationResult = validationResult;
        }
        public ServiceResult(ValidationResult validationResult, TEntity entity)
        {
            ValidationResult = validationResult;
            Entity = entity;
        }
        public ValidationResult ValidationResult { get; set; }
        public TEntity Entity { get; set; }
    }
}
