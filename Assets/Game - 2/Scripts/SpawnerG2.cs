using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Generation.Spawner
{
    class SpawnerG2 : MonoBehaviour
    {
        [SerializeField] GameObject player;
        [SerializeField] GameObject enemy;

        [SerializeField] List<CellG2> points;

        [SerializeField] int countEnemy, countPlayer;

        public void AddListPoint(List<CellG2> g) { for (int i = 0; i < g.Count; i++) points.Add(g[i]); }
        public void AddPlayerEnemy(int number)
        {
            switch (number)
            {
                case 0: countPlayer++; break;
                case 1: countEnemy++; break;
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
                    EnemyG2 p = Instantiate(enemy, points[i].transform.position + Vector3.up * 5, Quaternion.identity).GetComponent<EnemyG2>();
                    p.SetSpawner(this);
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
                        PlayerG2 p = Instantiate(player, points[i].transform.position, Quaternion.identity).GetComponent<PlayerG2>();
                        p.SetSpawner(this);
                        p.parent = points[i];
                        points[i].busy = true;
                        countPlayer--;
                    }
                }
            }
        }
    }
}