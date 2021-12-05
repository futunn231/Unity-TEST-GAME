using TMPro;
using UnityEngine;

public class Purse : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] int coins;

    Bank bank;

    private void Awake()
    {
        coins = PlayerPrefs.GetInt("Coins");
        text.text = coins.ToString();
    }

    private void Start() => bank = new Bank();
    private void OnEnable() => Coin.coinD += Coins;
    private void OnDisable() => Coin.coinD -= Coins;


    void Coins(int coin)
    {
        coins += coin;
        text.text = coins.ToString();
    }
}