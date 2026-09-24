namespace classeBanco;

public partial class Banco{

    public void guardarDinheiro()
    {
        
        ajustarLinhas("Selecione a quantidade de dinheiro que você deseja guardar");

        var _quantGuardar = Console.ReadLine();
        if (int.TryParse(_quantGuardar, out int quantGuardar))
        {
            if (quantGuardar<= 0)
            {
                ajustarLinhas("ERRO: Você não pode guardar valores negativos ou inválidos.");
            } 
            else if (quantGuardar > dinheiro)
            {
                ajustarLinhas("ERRO: Você não pode guardar um valor superior ao seu saldo atual.");
            }
            
            else
            {
                
            Console.WriteLine($"Você guardou o valor de R$ {quantGuardar} \nDeseja manter esta escolha?");
            Console.WriteLine("1. Sim \n2. Não");

            string entrada = Console.ReadLine();
            string escolha = entrada.ToLower().Trim();

            switch (escolha)
            {
                case "sim":
                dinheiroGuardado += quantGuardar;
                this.dinheiro -= quantGuardar;
                break;

                case "não":
                quantGuardar = 0;
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