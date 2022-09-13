using System.ComponentModel.DataAnnotations;

namespace MoveIT.Web.Models;

public class ProposalViewModel
{
    public int Id { get; set; }

    [Display(Name = "From address")]
    [Required]
    public string FromAddress { get; set; }

    [Display(Name = "To address")]
    [Required]
    public string ToAddress { get; set; }

    [Display(Name = "Distance(km)")]
    [Range(1, int.MaxValue, ErrorMessage = "Please specify distance greater then 0")]
    public int Distance { get; set; }

    [Display(Name = "Living area(m2)")]
    [Range(0, int.MaxValue, ErrorMessage = "Negative values are not allowed")]
    public int LivingArea { get; set; }

    [Display(Name = "Attic area(m2)")]
    [Range(0, int.MaxValue, ErrorMessage = "Negative values are not allowed")]
    public int AtticArea { get; set; }

    public int NumberOfCars { get; set; }

    [Display(Name = "Has Piano")]
    public bool HasPiano { get; set; }

    [Display(Name = "Calculated price")]
    public int CalculatedPrice { get; set; }

}