using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CivilManagement.Entities.Concrete
{
    public class User
    {
        public string FirstLastName { get; set; }
        public string IdentityNum { get; set; }
        public string WorkPlaceCode { get; set; }
        public string WorkPlaceDescription { get; set; }

        [DataType(DataType.Password)]
        public string PersonalMobile { get; set; }

    }
}
