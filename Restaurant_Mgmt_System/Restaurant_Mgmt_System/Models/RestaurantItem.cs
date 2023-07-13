using System;
using System.ComponentModel.DataAnnotations;

public class RestaurantItem
{
    [Key]
    public int ItemId { get; set; }

    [Required]
    public string ItemName { get; set; }

    [Required]
    public string ItemImage { get; set; }

    [Required]
    public string ItemCategory { get; set; }

    [Required]
    public string CreatedBy { get; set; }

    [DataType(DataType.DateTime)]
    public DateTime CreatedDate { get; set; }
}
