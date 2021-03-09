using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace CivilManagement.UI.Models
{
    public class LoginViewModel
    {

        public string IdentitNum { get; set; }

        [DataType(DataType.Password)]
        public string Phone { get; set; }
    }
}
