using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Camera")]
    [SerializeField] Camera cam;

    [Header("Speed player")]
    [SerializeField] byte speed;

    [Header("Move")]
    [SerializeField] bool move;

    [Header("Layer Ground")]
    [SerializeField] LayerMask ground;

    Ray ray;
    RaycastHit hit;

    void FixedUpdate() => PlayerMove();
    void PlayerMove()
    {
        if (Input.GetMouseButton(0))
        {
            move = true;
            ray = cam.ScreenPointToRay(Input.mousePosition);
        }
        if (move)
        {
            if (Physics.Raycast(ray, out hit, 999, ground))
            {
                transform.position = Vector3.MoveTowards(transform.position, hit.point, speed * Time.fixedDeltaTime);
            }
            if (transform.position.x == hit.point.x)
            {
                move = false;
            }
        }
    }
}