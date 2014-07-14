using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyOpportunity.Models
{
    public class MaxWordsAttribute : ValidationAttribute
    {
        private readonly int _maxWords;

        public MaxWordsAttribute(int MaxWords) :base ("{0} has too many words"){
            _maxWords = MaxWords;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var valueAsString = value.ToString();
                if (valueAsString.Split(' ').Length > _maxWords)
                {
                    var errorMeaage = FormatErrorMessage(validationContext.DisplayName);
                    return new ValidationResult(errorMeaage);
                }
            }

            return ValidationResult.Success;
        }
    }


    public class RestaurantReview:IValidatableObject
    {
        public int Id{ get; set; }
        [Range(1, 10)]
        [Required]
        public int Rating { get; set; }
        
        [Required]
        [MaxLength(1024)]
        
        public string Body { get; set; }
        
        public string ReviewerName { get; set; }
        public int RestaurantId { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Rating < 5 && ReviewerName.ToLower().StartsWith("alex"))
            {
                yield return new ValidationResult("Sorry Alex you cannot do this");
            }
        }
    }
}