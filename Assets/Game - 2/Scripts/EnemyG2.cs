using Generation.Spawner;
using UnityEngine;
enum Weapon
{
    rocket,
    bomb
}
class EnemyG2 : MonoBehaviour
{
    byte speed = 3;

    Weapon weapon;

    SpawnerG2 spawner;
    public void SetSpawner(SpawnerG2 g) => spawner = g;
    void Start()
    {
        byte i = (byte)Random.Range(0, 2);
        switch (i)
        {
            case 0: weapon = Weapon.rocket; break;
            case 1: weapon = Weapon.bomb; break;
        }
    }
    void Update() => transform.Translate(Vector3.down * speed * Time.deltaTime);
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 0)
        {
            spawner.AddPlayerEnemy(1);
            Destroy(gameObject);
        }
        else if (other.gameObject.layer == 6)
        {
            if (weapon == Weapon.rocket) other.GetComponent<HeathG2>().Damage(1);
            else if (weapon == Weapon.bomb) other.GetComponent<HeathG2>().Damage(2);
            spawner.AddPlayerEnemy(1);
            Destroy(gameObject);
        }
    }
}