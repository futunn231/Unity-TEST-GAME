using UnityEngine;

public class Bank : MonoBehaviour
{
    private float money;

    public delegate void AddWallet(float cash);
    public static AddWallet addWallet;

    private void Start()
    {
        Money.addMoney += Wallet;
    }
    void Wallet(float cash)
    {
        money += cash;
        addWallet.Invoke(money);
    }
}