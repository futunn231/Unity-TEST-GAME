using UnityEngine;

class CoinG1 : MonoBehaviour
{
    [SerializeField] int coin;

    public static event System.Action<int> addCoin;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            addCoin?.Invoke(coin);
            Destroy(gameObject);
        }
    }
}