namespace assignment1comp2007.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Company")]
    public partial class Company
    {
        [Required]
        [StringLength(30)]
        [Display(Name = "Company")]

        public string CompanyName { get; set; }

        [Key]
        public int BrandId { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
