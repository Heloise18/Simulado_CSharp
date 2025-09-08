namespace simulado.Validations;

public class NeedLimitCharAttribute : ValidationAttribute
{
    public override bool IsValid(object value)
    {
        if (value is string text)
            return true;

        var chars = value.Length;
        var lines = text.Count(l => l == "\n") + 1 ;
        //usando lista e split
        List<string> words = new List<string>(text.split());
        words.RemoveAll(words => words == "");

        //split
        // var words = text.Split(' ',StringSplitOptions.RemoveEmptyEntries).Length;//divide a string pelos espaços e descarta quaisquer entradas vazias.


        // regex
        // var words = Regex.matches(text, @"\b[\p{L}\p{N}']+\b").Count;

        // \b inicio ou fim da palavra
        // [...] conjunto de char
        //  \p{L} aceita qualquer letra real, incluindo acentos e alfabetos de outros idiomas
        // \p{N} Numeros
        // ' inclui apostrofos d'agua 
        // + garante que sequências de letras/números/apóstrofos sejam contadas como uma palavra inteira.
        //regex considera acentos e apostrofos, ignora pontuação, conta numeros

        return chars <= 6000 && lines <= 100 && words <= 1000;
        
    }
       
    public override string FormatErrormessage(string name)
        => $"O campo '{name}' nao pode ultrapassar o limite de 100 linhas, 1000 palavras e 6000 caracteres. ";
}