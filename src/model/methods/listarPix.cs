namespace classeBanco;

public partial class Banco{
    
    public void ListaPix()
    {
        
        Console.WriteLine("Você realizou transações para os seguintes usuários:");
        Console.WriteLine("");
        
        for (int i = 0; i < nomePixFeitos.Count; i++)
        {
            string destinatario = nomePixFeitos[i];

            int valor = valorPixFeitos[i];

            Console.WriteLine($"Nome: {destinatario} \nValor: R$ {valor}");
            Console.WriteLine(""); 
        }

        Console.WriteLine("");
    }
}