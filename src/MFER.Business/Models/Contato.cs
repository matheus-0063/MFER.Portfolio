namespace MFER.Business.Models;

public class Contato : Entity
{
    
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Telefone { get; private set; }
    public string? Mensagem { get; private set; }
    
    public Contato(){ }
    
    public Contato(Guid id, string name, string email, string telefone, string? mensagem)
    {
        Id = id;
        Name = name;
        Email = email;
        Telefone = telefone;
        Mensagem = mensagem; 
    }

}