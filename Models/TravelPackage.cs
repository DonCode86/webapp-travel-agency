using System.ComponentModel.DataAnnotations;

public class TravelPackage
{
    public TravelPackage()
    {
    }

    public TravelPackage(string name, string description, int durationInNights, double price)
    {
        Name = name;
        Description = description;
        DurationInNights = durationInNights;
        Price = price;
    }

    public int Id { get; set; }

    [Required(ErrorMessage = "Il campo è obbligatorio")]
    [StringLength(25, ErrorMessage = "Il nome è troppo lungo")]
    public string Name { get; set; }

    public string? Image { get; set; }

    [Required(ErrorMessage = "Il campo è obbligatorio")]
    [StringLength(300, ErrorMessage = "La descrizione non puo' contenere più di 300 caratteri")]
    public string Description { get; set; }

    [Required(ErrorMessage = "Il campo è obbligatorio")]
    [Range(0, 30, ErrorMessage = "Non puoi prenotare per più di 30 giorni")]
    public int DurationInNights { get; set; }

    [Required(ErrorMessage = "Il campo è obbligatorio")]
    [Range(1, 20000, ErrorMessage = "Il prezzo non è valido")]
    public double Price { get; set; }
}