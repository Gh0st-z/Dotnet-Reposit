using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant_Mgmt_Sys.Models
{
    public class MenuItemsModel
    {
        [Key]
        public int item_id { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public int item_name { get; set;}

        [Column(TypeName = "varbinary(MAX)")]
        public int item_img { get; set;}

        [Column(TypeName = "nvarchar(50)")]
        public int item_category { get; set;}

        [Column(TypeName = "nvarchar(50)")]
        public int CreatedBy { get; set;}

        [Column(TypeName = "date")]
        public int CreatedDate { get; set;}
    }
}
