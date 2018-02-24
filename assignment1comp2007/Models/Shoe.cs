namespace assignment1comp2007.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Shoe")]
    public partial class Shoe
    {
        [Key]
        public int ProductId { get; set; }


        [Display(Name = "Brand Name")]
        public int BrandId { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Shoe Name")]
        public string ShoeName { get; set; }

        [Column(TypeName = "numeric")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal Price { get; set; }

        [Column(TypeName = "numeric")]
        [DisplayFormat(DataFormatString = "{0:0.0}")]
        [Display(Name = "Size (US)")]
        public decimal SizeUS { get; set; }

        public virtual Company Company { get; set; }

        public int Quantity { get; set; }

        [StringLength(1024)]
        [Display(Name = "Image")]
        public string ImageUrl { get; set; }
    }
}
