using Generation.Spawner;
using UnityEngine;

class PlayerG2 : MonoBehaviour
{
    public CellG2 parent = null;
    SpawnerG2 spawner;
    public void SetSpawner(SpawnerG2 g) => spawner = g;
    public void OnDestroy()
    {
        spawner.AddPlayerEnemy(0);
        parent.busy = false;
        Destroy(gameObject);
    }
}