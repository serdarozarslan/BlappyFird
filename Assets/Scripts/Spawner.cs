using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    public Birdie BirdScript;

    public GameObject Borular;

    public float height;

    public float time;

    public float spawnPointX;


    private void Start()
    {
        StartCoroutine(SpawnObject(time));
    }

    public IEnumerator SpawnObject(float time)
    {
        while (true)
        {
            if (GameManager.Instance.isGameStarted && !BirdScript.isDead)
            {
                Instantiate(Borular, new Vector3(spawnPointX, Random.Range(-height, height), 0), Quaternion.identity);

                yield return new WaitForSeconds(time);
            }
            else
            {
                yield return null;
            }

            yield return null;
        }
    }
}