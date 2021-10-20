using TMPro;
using UnityEngine;

public class Bank : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] float money;

    public float Money { get => money; set => money = value; }

    public delegate void CheckCash(float cash);
    public static CheckCash checkCash;

    private void Start() => checkCash += Wallet;

    public void Wallet(float cash)
    {
        Money += cash;
        text.text = Money.ToString();
    }
}