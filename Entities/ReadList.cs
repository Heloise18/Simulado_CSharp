namespace simulado.Entities;

public class ReadList
{
    public string Title { get; set; }
    public DateTime LastChange { get; set; }
    public ICollection<Fanfic> Fanfics { get; set; } = [];
}