using UnityEngine;

public class Money : MonoBehaviour
{
    [SerializeField] float cash;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Bank.checkCash?.Invoke(cash);
            Destroy(gameObject);
        }
    }
}