namespace simulado.Entities;

public class User
{
    public Guid ID { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
    public string? Description { get; set; }
    public DateTime AccountDate { get; set; }

    public ICollection<Fanfic> Fanfics { get; set; } = [];
    public ICollection<ReadList> Lists { get; set; } = [];

}