using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ViewModel
{
    public class LoginViewModel
    {
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required,DataType(DataType.Password),Display(Name ="Password")]
        public string PasswordHash { get; set; }
    }
}
