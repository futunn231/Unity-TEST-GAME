using System.Collections;
using System.Collections.Generic;
using UnityEngine;
class Spawner : MonoBehaviour
{
    [SerializeField] PlayerClone player;
    [SerializeField] Enemy enemy;

    [SerializeField] List<Cell> points;

    [SerializeField] int countEnemy, countPlayer;

    public delegate void AddIndexPlayer();
    public AddIndexPlayer indexPlayer;

    public delegate void AddIndexEnemy();
    public AddIndexEnemy indexEnemy;

    void Start()
    {
        indexPlayer = IndexPlayer;
        indexEnemy = IndexEnemy;
    }

    public void AddListPoint(List<Cell> g) { foreach (var item in g) points.Add(item); }
    void IndexPlayer() => countPlayer++;
    void IndexEnemy() => countEnemy++;
    public void Play()
    {
        StartCoroutine(SpawnEnemy());
        StartCoroutine(SpawnPlayer());
    }
    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            if (countEnemy > 0)
            {
                yield return new WaitForSeconds(0.1f);
                int i = Random.Range(0, points.Count);
                Enemy p = Instantiate(enemy, points[i].transform.position + Vector3.up * 5, Quaternion.identity);
                p.setSpawn = this;
                countEnemy--;
            }
        }
    }
    IEnumerator SpawnPlayer()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            if (countPlayer > 0)
            {
                yield return new WaitForSeconds(0.5f);
                int i = Random.Range(0, points.Count);
                if (!points[i].busy)
                {
                    PlayerClone p = Instantiate(player, points[i].transform.position, Quaternion.identity);
                    p.setSpawn = this;
                    p.setCell = points[i];
                    p.transform.parent = points[i].transform;
                    points[i].busy = true;
                    countPlayer--;
                }
            }
        }
    }
}