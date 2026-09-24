namespace classeBanco;

public partial class Banco{
    
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
