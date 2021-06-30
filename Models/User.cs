using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace truyum_WebAPIPracticeCheck.Models
{
    public class User
    {
       // [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        //[Required]
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
