namespace classeBanco;
public class Program
{
     
    public static void ajustarLinhas(string mensagem)
    {
        string totalLinhas = new string('-', mensagem.Length);
        
        Console.WriteLine(totalLinhas);
        Console.WriteLine(mensagem);
    }
    
    static void Main()
    {

        Console.Clear();
        ajustarLinhas("Bem vindo ao sistema do banco! \nCadastre uma nova conta para continuar:");
        Console.Write("Nome da conta: ");
        string nomeConta = Console.ReadLine();
        
        Console.Write("Qual é a quantidade de dinheiro que você tem atualmente? ");
        int dinheiroConta = int.Parse(Console.ReadLine());
        
        Banco usuario = new Banco(nomeConta, dinheiroConta);
        
        Console.Clear();
        
        bool rodando = true;

        while (rodando)
        {
            ajustarLinhas($"Olá, {nomeConta}! \nO que você deseja fazer agora?");
            Console.WriteLine("1. Depositar dinheiro \n2. Sacar dinheiro \n3. Fazer um Pix \n4. Ver lista de Pix feitos \n5. Ver detalhes da conta \n6. Sair");

            var escolha = int.Parse(Console.ReadLine());

            switch (escolha)
            {
               
                case 1:
                Console.Clear();
                usuario.guardarDinheiro();
                break;

                case 2:
                Console.Clear();
                usuario.retirarDinheiro();
                break;

                case 3:
                Console.Clear();
                usuario.Pix();
                break;

                case 4:
                Console.Clear();
                usuario.ListaPix();
                break;

                case 5:
                Console.Clear();
                usuario.detalhesConta();
                break;

                case 6:
                Console.WriteLine("\nCerto, até mais!");
                rodando = false;
                break;

                default:
                Console.WriteLine("\nERRO: Digite um argumento válido para escolha.");
                break;

            }
        }
    }
}