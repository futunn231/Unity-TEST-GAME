using UnityEngine;

class PlayerControllerG1 : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] byte speed;
    [SerializeField] bool move;
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
            if (Physics.Raycast(ray, out hit, 100f, ground))
            {
                transform.position = Vector3.MoveTowards(transform.position, hit.point, speed * Time.fixedDeltaTime);
                if (Vector2.Distance(transform.position, hit.transform.position) <= 0.1f) move = false;
            }
        }
    }
}