namespace MoveIT.Application.DTOs;

public class ProposalDto
{
    public int Id { get; set; }
    public string FromAddress { get; set; }
    public string ToAddress { get; set; }
    public int Distance { get; set; }
    public int LivingArea { get; set; }
    public int AtticArea { get; set; }
    public int NumberOfCars { get; set; }
    public bool HasPiano { get; set; }
    public int CalculatedPrice { get; set; }

}