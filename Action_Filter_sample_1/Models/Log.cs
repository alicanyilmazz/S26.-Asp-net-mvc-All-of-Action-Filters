using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Action_Filter_sample_1.Models
{
    [Table("Logs")]
    public class Log
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Log_Id { get; set; }

        [Required(),DisplayName("Process Date")]
        public DateTime Log_Date { get; set; }

        [Required,StringLength(25),DisplayName("User name")]
        public string Log_username { get; set; }

        [StringLength(100),DisplayName("Action")]
        public string Log_Actionname { get; set; }

        [StringLength(100),DisplayName("Controller")]
        public string Log_Controllername { get; set; }

        [StringLength(250),DisplayName("Information")]
        public string Log_Information { get; set; }
    }
}