using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] int coin;

    Bank bank;


    public delegate void CoinDelegate(int coin);
    public static CoinDelegate coinD;

    private void Start()
    {
        bank = new Bank();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            bank.Wallet(coin);
            coinD?.Invoke(coin);
            PlayerPrefs.SetInt("Coins", bank.Coins);
            Debug.Log(bank.Coins + " add coin in bank");
        }
    }
}