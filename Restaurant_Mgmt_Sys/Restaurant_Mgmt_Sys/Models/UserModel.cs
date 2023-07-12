using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant_Mgmt_Sys.Models
{
    public class UserModel
    {
        [Key]
        public int user_id { get; set; }

        [Column(TypeName ="nvarchar(50)")]
        public string? username { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? first_name { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? last_name { get; set;}

        [Column(TypeName = "nvarchar(50)")]
        public string? password { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? role { get; set; }
    }
}
