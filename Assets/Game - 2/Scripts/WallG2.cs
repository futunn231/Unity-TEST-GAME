using System.Collections.Generic;
using UnityEngine;
namespace Generation
{
    class WallG2 : MonoBehaviour
    {
        public GameObject leftWall;
        public GameObject downWall;
        public Vector3 pos;
        public bool busy = false;
        [SerializeField] List<CellG2> cells;

        public List<CellG2> GetList() => cells;
    }
}