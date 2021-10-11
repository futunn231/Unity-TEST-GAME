using UnityEngine;

public class MovableY : IMovable
{
    public void Move(Transform transform)
    {
        var move = new Vector3(0, Input.GetAxis("Vertical"), 0);
        transform.Translate(move);
    }
}