using UnityEngine;
enum Weapon
{
    rocket,
    bomb
}
class Enemy : MonoBehaviour
{
    int speed = 3;
    int damage;
    Weapon weapon;

    Spawner spawner;
    public Spawner setSpawn { set => spawner = value; }


    void Start()
    {
        int i = Random.Range(0, 2);
        switch (i)
        {
            case 0: weapon = Weapon.rocket; damage = 1; break;
            case 1: weapon = Weapon.bomb; damage = 2; break;
        }
    }
    void Update() => transform.Translate(Vector3.down * speed * Time.deltaTime);
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 0)
        {
            spawner.indexEnemy?.Invoke();
            Destroy(gameObject);
        }
        else if (other.gameObject.layer == 6)
        {
            switch (weapon)
            {
                case Weapon.rocket: other.GetComponent<PlayerClone>().Damage(damage); break;
                case Weapon.bomb: other.GetComponent<PlayerClone>().Damage(damage); break;
            }
            spawner.indexEnemy?.Invoke();
            Destroy(gameObject);
        }
    }
}