using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Astrology.Models
{
    public class ContactUsViewModel
    {
        #region Constructors

        public ContactUsViewModel()
        {

        }

        #endregion

        #region Properties

        [Required]
        [MaxLength(length: 30, ErrorMessage = "Name cannot be more than 50 characters.")]
        public string Name
        {
            get;
            set;
        }

        [MaxLength(length: 50, ErrorMessage = "Email cannot be more than 50 characters.")]
        public string Email
        {
            get;
            set;
        }

        [MaxLength(length: 100, ErrorMessage = "City cannot be more than 50 characters.")]
        public string City
        {
            get;
            set;
        }

        [MaxLength(length: 10, ErrorMessage = "Invalid Mobile No.")]
        [MinLength(length: 10, ErrorMessage = "Invalid Mobile No.")]
        [Required]
        public string Mobile
        {
            get;
            set;
        }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [MaxLength(length: 100000, ErrorMessage = "Message cannot be more than 200 characters.")]
        public string Message
        {
            get;
            set;
        }



        #endregion
    }
}