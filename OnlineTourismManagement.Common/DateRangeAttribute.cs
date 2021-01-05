using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace OnlineTourismManagement.Common
{
    //    public class DateRangeAttribute : RangeAttribute, IClientModelValidator
    //    {
    //        public DateRangeAttribute() :base (typeof(DateTime), DateTime.Now.Date.AddYears(-100).ToShortDateString(),DateTime.Now.ToString())
    //        {

    //        }
    //        
    //        }
    //    }
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class ValidateAgeAttribute : ValidationAttribute, IClientValidatable
    {
        private const string DefaultErrorMessage = "Your age is invalid, your age should fall between 15 and 70";

        public DateTime MinimumDateProperty { get; private set; }
        public DateTime MaximumDateProperty { get; private set; }

        public ValidateAgeAttribute(
            int minimumAgeProperty,
            int maximumAgeProperty)
            : base(DefaultErrorMessage)
        {
            MaximumDateProperty = DateTime.Now.AddYears(minimumAgeProperty * -1);
            MinimumDateProperty = DateTime.Now.AddYears(maximumAgeProperty * -1);
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime parsedValue = (DateTime)value;

                if (parsedValue <= MinimumDateProperty || parsedValue >= MaximumDateProperty)
                {
                    return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
                }
            }
            return ValidationResult.Success;

        }
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule()
            {
                ValidationType = "validateage",
                ErrorMessage = FormatErrorMessage(metadata.GetDisplayName()),
            };

            rule.ValidationParameters.Add("minumumdate", MinimumDateProperty.ToShortDateString());
            rule.ValidationParameters.Add("maximumdate", MaximumDateProperty.ToShortDateString());

            yield return rule;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(ErrorMessageString, name, MinimumDateProperty.ToShortDateString(), MaximumDateProperty.ToShortDateString());
        }
    }
}

