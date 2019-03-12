using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class Survey
    {
        [Required(ErrorMessage = "*")]
        public string ParkCode { get; set; }

        public int SurveyID { get; set; }

        [Required(ErrorMessage = "*")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "*")]
        public string State { get; set; }

        [Required(ErrorMessage = "*")]
        public string ActivityLevel { get; set; }
    }
}
