using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Birdie : MonoBehaviour
{
    public bool isDead;

    public float velocity = 1f;
    public float eulerAngles = 1f;
    public Rigidbody2D rb2D;


    private void Start()
    {
        rb2D.isKinematic = true;
    }

    void Update()
    {
        //Tıklamayı al
        if (Input.GetMouseButtonDown(0) && GameManager.Instance.isGameStarted && !GameManager.Instance.isGameEnded)
        {
            //Havada kuşu sıçrat
            SoundManager.Instance.PlaySound(SoundManager.Instance.jumpSound, 0.1f);

            rb2D.velocity = Vector2.up * velocity;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "ScoreArea")
        {
            GameManager.Instance.UpdateScore();

            SoundManager.Instance.PlaySound(SoundManager.Instance.scoreAreaSound, 1f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DeathArea"))
        {
            isDead = true;
            GameManager.Instance.isGameEnded = true;

            GameManager.Instance.DeathScreen.SetActive(true);

            SoundManager.Instance.PlaySound(SoundManager.Instance.loseGameSound, 1f);
            
            GameManager.Instance.ScoreText.gameObject.SetActive(false);
        }
    }
}