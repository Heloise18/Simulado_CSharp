namespace simulado.Entities;

public class ReadList
{
    public Guid ID { get; set; }
    public string Title { get; set; }
    public DateTime LastChange { get; set; }

    public User Owner  { get; set; }

    public ICollection<Fanfic> Fanfics { get; set; } = [];
}