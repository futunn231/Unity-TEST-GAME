using UnityEngine;

class PlayerClone : MonoBehaviour
{
    [SerializeField] int hp;

    Spawner spawner;
    public Spawner setSpawn { set => spawner = value; }

    public int HP
    {
        get => hp;
        set
        {
            hp -= value;
            if (hp <= 0)
            {
                spawner.AddCount(1);
                Destroy(gameObject);
            }
        }
    }
    public void Damage(int d) => HP = d;
}