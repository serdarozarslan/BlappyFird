using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Borular : MonoBehaviour
{
    public float speed;


    private void Start()
    {
        Destroy(gameObject, 10);
    }

    void Update()
    {
        if (!GameManager.Instance.isGameEnded)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        else
        {
            foreach (var child in gameObject.GetComponentsInChildren<Transform>())
            {
                child.gameObject.tag = "Untagged";
            }
        }
    }
}