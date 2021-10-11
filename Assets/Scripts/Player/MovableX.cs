using UnityEngine;

public class MovableX : IMovable
{
    public void Move(Transform transform)
    {
        var move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        transform.Translate(move);
    }
}