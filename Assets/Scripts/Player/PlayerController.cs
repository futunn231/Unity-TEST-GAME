using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private IMovable movable;

    private void Start()
    {
        movable = new MovableX();
    }

    private void Update()
    {
        Move();
        movable.Move(transform);
    }

    void ChangeMovable(IMovable movable)
    {
        this.movable = movable;
    }

    void Move()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            ChangeMovable(new MovableX());
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            ChangeMovable(new MovableY());
        }
    }
}