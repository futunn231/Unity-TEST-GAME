using UnityEngine;

public class BorderOfTheWorld : MonoBehaviour
{
    public delegate void Resurrect();
    public static Resurrect resurrect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            resurrect.Invoke();
            Destroy(other.gameObject);
        }
    }
}