public class Bank
{
    int coin;

    public int Coins { get => coin; }
    public void Wallet(int coins) => coin += coins;
}