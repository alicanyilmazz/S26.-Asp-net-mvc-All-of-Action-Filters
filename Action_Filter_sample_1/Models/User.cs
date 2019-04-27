using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Action_Filter_sample_1.Models
{
    [Table("Users")]
    public class User
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int User_Id { get; set; }

        [Required,StringLength(20),DisplayName("name")]
        public string User_name { get; set; }
        
        [Required,StringLength(20),DisplayName("surname")]
        public string User_surname { get; set; }

        [Required,StringLength(20),DisplayName("username")]
        public string User_username { get; set; }

        [Required,StringLength(16),DisplayName("password"),DataType(DataType.Password)]
        public string User_password { get; set; }
    }
}