using UnityEngine;

class PlayerClone : MonoBehaviour
{
    [SerializeField] int hp;

    Spawner spawner;
    public Spawner setSpawn { set => spawner = value; }

    Cell cel;
    public Cell setCell { set => cel = value; }

    public int HP
    {
        get => hp;
        set
        {
            hp -= value;
            if (hp <= 0)
            {
                cel.busy = false;
                spawner.AddCount(1);
                Destroy(gameObject);
            }
        }
    }
    public void Damage(int d) => HP = d;
}