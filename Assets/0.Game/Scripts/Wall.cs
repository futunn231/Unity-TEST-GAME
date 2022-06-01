using System.Collections.Generic;
using UnityEngine;
class Wall : MonoBehaviour
{
    public GameObject leftWall;
    public GameObject downWall;

    public Vector3 pos;

    public bool busy = false;

    [SerializeField] List<Cell> cells;

    public List<Cell> GetList() => cells;
}