using System.Collections;
using UnityEngine;

public class PlayerResurrection : MonoBehaviour
{
    [SerializeField] Character player;
    [SerializeField] Transform resurrectionPoint;

    private void Start() => BorderOfTheWorld.resurrect = Resurrect;

    void Resurrect() => StartCoroutine(Resurrection());

    IEnumerator Resurrection()
    {
        yield return new WaitForSeconds(2);
        GameObject _player = Instantiate(player.player, resurrectionPoint.position, Quaternion.identity);
    }
}