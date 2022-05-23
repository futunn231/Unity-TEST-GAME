using TMPro;
using UnityEngine;

class WalletG1 : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textCoin;

    int coin;

    void OnEnable() => CoinG1.addCoin += LoadCoin;
    void OnDisable() => CoinG1.addCoin -= LoadCoin;
    void LoadCoin(int c)
    {
        coin += c;
        textCoin.text = coin.ToString();
    }
}