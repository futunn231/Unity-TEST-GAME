using System.Collections;
using System.Collections.Generic;
using UnityEngine;
class Spawner : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject enemy;

    [SerializeField] List<Cell> points;

    [SerializeField] int countEnemy, countPlayer;

    public void AddListPoint(List<Cell> g) { for (int i = 0; i < g.Count; i++) points.Add(g[i]); }
    public void AddCount(int i)
    {
        switch (i)
        {
            case 0: countEnemy++; break;
            case 1: countPlayer++; break;
        }
    }
    public void Play()
    {
        StartCoroutine(SpawnEnemy());
        StartCoroutine(SpawnPlayer());
    }
    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.2f);
            while (countEnemy > 0)
            {
                yield return new WaitForSeconds(0.2f);
                int i = Random.Range(0, points.Count);
                Enemy p = Instantiate(enemy, points[i].transform.position + Vector3.up * 5, Quaternion.identity).GetComponent<Enemy>();
                p.setSpawn = this;
                countEnemy--;
            }
        }
    }
    IEnumerator SpawnPlayer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            while (countPlayer > 0)
            {
                yield return new WaitForSeconds(2);
                int i = Random.Range(0, points.Count);
                if (!points[i].busy)
                {
                    PlayerClone p = Instantiate(player, points[i].transform.position, Quaternion.identity).GetComponent<PlayerClone>();
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