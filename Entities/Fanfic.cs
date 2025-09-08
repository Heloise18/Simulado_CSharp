namespace simulado.Entities;

public class Fanfic
{
    public Guid ID { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }

    public Guid OwnerID { get; set; }
    public User Owner { get; set; }

    public ICollection<ReadList> Lists { get; set; } = [];

    
    
}