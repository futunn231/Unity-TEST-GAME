using TMPro;
using UnityEngine;

public class UICounter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMoney;

    private void Start() => Bank.addWallet += Counter;

    void Counter(float money) => textMoney.text = money.ToString();

}