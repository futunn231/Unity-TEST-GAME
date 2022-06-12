using UnityEngine;

class PlayerClone : MonoBehaviour
{
    [SerializeField] int hp;

    Spawner spawner;
    Cell cel;

    public Spawner setSpawn { set => spawner = value; }
    public Cell setCell { set => cel = value; }

    int HP
    {
        get => hp;
        set
        {
            hp -= value;
            if (hp <= 0)
            {
                cel.busy = false;
                spawner.indexPlayer?.Invoke();
                Destroy(gameObject);
            }
        }
    }
    public void Damage(int d) => HP = d;
}