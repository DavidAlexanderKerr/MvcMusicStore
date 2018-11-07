using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MvcMusicStore.Infrastructure
{
    public class MaxWordsAttribute:ValidationAttribute,IClientValidatable
    {
        public int WordCount { get; set; }

        public MaxWordsAttribute(int maxWords):base("{0} has too many words")
        {
            WordCount = maxWords;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value!=null)
            {
                var valueAsString = value.ToString();
                if (valueAsString.Split(' ').Length > WordCount)
                {
                    var errorMessage = FormatErrorMessage(validationContext.DisplayName);
                    return new ValidationResult(errorMessage);
                }
            }
            return ValidationResult.Success;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metaData, ControllerContext context)
        {
            var rule = new ModelClientValidationRule();
            rule.ErrorMessage = FormatErrorMessage(metaData.GetDisplayName());
            rule.ValidationParameters.Add("wordcount", WordCount);
            rule.ValidationType = "maxwords";
            yield return rule;
        }
    }
}