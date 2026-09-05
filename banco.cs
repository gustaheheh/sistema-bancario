using System.Collections;
using System.ComponentModel;
using System.Reflection.Metadata;

public class Banco
{
    
    private int dinheiro;
    private int dinheiroGuardado;
    private int id;
    public int _id;
    string nome;

    public List<string> nomePixFeitos = new List<string>();

    public List<int> valorPixFeitos = new List<int>();

    public Banco(string nome, int dinheiro)
    {
        _id ++;
        id = _id;

        this.nome = nome;
        this.dinheiro = dinheiro;

        if (dinheiro < 0)
        {
            Console.WriteLine("ERRO: Seu dinheiro não pode ser negativo, tente novamente.");
        }
    }
    
    public void ajustarLinhas(string mensagem)
    {
        string totalLinhas = new string('-', mensagem.Length);
        
        Console.WriteLine(totalLinhas);
        Console.WriteLine(mensagem);
    }
    
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

    public void detalhesConta()
    {
        Console.WriteLine($"Detalhes da conta: \nNome de usuário: {nome} \nSaldo atual: R$ {dinheiro} \nDinheiro guardado: R$ {dinheiroGuardado} \nID de conta: {id}");
        Console.WriteLine("");
    }

    public void Depositar()
    {
        
        ajustarLinhas("Selecione a quantidade de dinheiro que você deseja depositar");

        var _quantDinheiro = Console.ReadLine();
        if (int.TryParse(_quantDinheiro, out int quantDinheiro))
        {
            if (quantDinheiro <= 0)
            {
                ajustarLinhas("ERRO: Você não pode depositar valores negativos ou inválidos.");
            } 
            else if (quantDinheiro > dinheiro)
            {
                ajustarLinhas("ERRO: Você não pode guardar um valor superior ao seu saldo atual.");
            }
            
            else
            {
                
            Console.WriteLine($"Você depositou o valor de R$ {quantDinheiro} \nDeseja manter esta escolha?");
            Console.WriteLine("1. Sim \n2. Não");

            string entrada = Console.ReadLine();
            string escolha = entrada.ToLower().Trim();

            switch (escolha)
            {
                case "sim":
                dinheiroGuardado += quantDinheiro;
                this.dinheiro -= quantDinheiro;
                break;

                case "não":
                quantDinheiro = 0;
                ajustarLinhas("Ação desfeita.");
                Console.WriteLine("");
                break;

                default:
                Console.WriteLine("Digite um valor válido para escolha.");
                break;
            }

            }
            
        }
        
    }
    
    public void Sacar()
    {

        ajustarLinhas("Selecine a quantidade de dinheiro que você deseja sacar:");
        
        var _quantSacar = Console.ReadLine();
        if (int.TryParse(_quantSacar, out int quantSacar))
        {
           
            if (quantSacar > dinheiroGuardado)
            {
                ajustarLinhas("ERRO: Você não tem saldo suficiente para sacar.");
            }
            else if (quantSacar <= 0)
            {
                Console.WriteLine("ERRO: Você não pode depositar valores negativos ou inválidos.");
            }
            
            else
            {
                
                ajustarLinhas($"Você está prestes a sacar R$ {quantSacar} \nDeseja manter esta escolha?");
                Console.WriteLine("1. Sim \n2. Não");

                string entrada = Console.ReadLine();
                string escolha = entrada.ToLower().Trim();

                switch (escolha)
                {
                    case "sim":
                    dinheiro += quantSacar;
                    dinheiroGuardado -= quantSacar;
                    break;

                    case "não":
                    quantSacar = 0;
                    ajustarLinhas("Ação desfeita.");
                    Console.WriteLine("");
                    break;

                    default:
                    Console.WriteLine("Digite um valor válido para escolha.");
                    break;
            }

            }
        
        }
    }

    public void Pix()
    {
        
        ajustarLinhas("Quem irá receber o valor? (Nome)");
        string destinatarioPix = Console.ReadLine();

        ajustarLinhas($"Qual será o valor transferido para {destinatarioPix}?");
        var _valorPix = Console.ReadLine();
        
        if (int.TryParse(_valorPix, out int valorPix))
        {
            if (valorPix > this.dinheiro)
            {
                Console.WriteLine("ERRO: Você não pode transferir um valor maior que o seu saldo atual.");
            }
            else
            {
                Console.WriteLine($"Você está prestes a transferir R$ {valorPix} para a conta {destinatarioPix} \nDeseja manter esta escolha?");
                Console.WriteLine("1. Sim \n2. Não");

                string entrada = Console.ReadLine();
                string escolha = entrada.ToLower().Trim();

                switch (escolha)
                {
                    case "sim":
                    valorPixFeitos.Add(valorPix);
                    nomePixFeitos.Add(destinatarioPix);
                    dinheiro -= valorPix;
                    break;

                    case "não":
                    valorPix = 0;
                    ajustarLinhas("Ação desfeita.");
                    Console.WriteLine("");
                    break;

                    default:
                    Console.WriteLine("Digite um valor válido para escolha.");
                    break;
            }
            }
        }

    }
}

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
                usuario.Depositar();
                break;

                case 2:
                Console.Clear();
                usuario.Sacar();
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
