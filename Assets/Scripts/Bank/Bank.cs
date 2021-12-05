public class Bank
{
    int coin { get; set; }

    public int Coins { get => coin; }

    public void Wallet(int coins)
    {
        coin += coins;
        
    }
}