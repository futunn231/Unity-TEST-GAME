using UnityEngine;

public class Money : Bank
{
    [SerializeField] float cash;

    public delegate void AddMoney(float money);
    public static AddMoney addMoney;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("+cash");
            addMoney.Invoke(cash);
            Destroy(gameObject);
        }
    }
}