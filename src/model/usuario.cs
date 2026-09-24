namespace classeBanco;

public partial class Banco
{
    
    private int dinheiro;
    private int dinheiroGuardado;
    private int id;
    public int _id;
    string nome;

    public List<string> nomePixFeitos = new List<string>();

    public List<int> valorPixFeitos = new List<int>();

    public void ajustarLinhas(string mensagem)
    {
        string totalLinhas = new string('-', mensagem.Length);
        
        Console.WriteLine(totalLinhas);
        Console.WriteLine(mensagem);
    }
    
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
}