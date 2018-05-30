using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FamousHumidors.Models
{
    public class NewsletterModel : IValidatableObject
    {
        [Required]
        [StringLength(256)]
        [Display(Name = "Email")]
        [DisplayFormat(NullDisplayText = "you@email.com")]
        public string Email { get; set; }
        public string Hack { get; set; }

        public NewsletterModel()
        {
            Hack = "safe";
        }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!Valid() || Email == "" || Email == null)
            {
                yield return new ValidationResult("Email address invalid.");
            }
        }

        public bool Valid()
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(Email);
                if (addr.Address == Email && addr.Address.IndexOf('.') >= 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}