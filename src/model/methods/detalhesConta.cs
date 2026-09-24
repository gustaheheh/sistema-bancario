namespace classeBanco;

public partial class Banco{
    
    public void detalhesConta()
    {
        Console.WriteLine($"Detalhes da conta: \nNome de usuário: {nome} \nSaldo atual: R$ {dinheiro} \nDinheiro guardado: R$ {dinheiroGuardado} \nID de conta: {id}");
        Console.WriteLine("");
    }
}