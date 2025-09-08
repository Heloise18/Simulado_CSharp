namespace simulado.Entities;

public class Fanfics_list
{
    public Guid ReadListID { get; set; }
    public ReadList Lists { get; set; }
    public Guid FanficID { get; set; }
    public Fanfic Fics { get; set; }

}