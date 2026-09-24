namespace classeBanco;

public partial class Banco{
    
    public void retirarDinheiro()
    {

        ajustarLinhas("Selecine a quantidade de dinheiro que você deseja resgatar:");
        
        var _quantResgate = Console.ReadLine();
        if (int.TryParse(_quantResgate, out int quantResgate))
        {
           
            if (quantResgate > dinheiroGuardado)
            {
                ajustarLinhas("ERRO: Você não tem dinheiro guardado o suficiente para resgatar.");
            }
            else if (quantResgate <= 0)
            {
                Console.WriteLine("ERRO: Você não pode resgatar valores negativos ou inválidos.");
            }
            
            else
            {
                
                ajustarLinhas($"Você está prestes a resgatar R$ {quantResgate} \nDeseja manter esta escolha?");
                Console.WriteLine("1. Sim \n2. Não");

                string entrada = Console.ReadLine();
                string escolha = entrada.ToLower().Trim();

                switch (escolha)
                {
                    case "sim":
                    dinheiro += quantResgate;
                    dinheiroGuardado -= quantResgate;
                    break;

                    case "não":
                    quantResgate = 0;
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