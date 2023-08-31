using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float initialVelocity = 4f;
    [SerializeField] private float velocityMultiplier = 1.1f;
    [SerializeField] private AudioClip hitball, golSFX;
    private Rigidbody2D ballRb;
    void Start()
    {
        ballRb = GetComponent<Rigidbody2D>();
        Invoke(nameof(Launch), 1f);
    }

    private void Launch()
    {
        // Operadores ternarios
        // condition ? consequent : alternative
        // En este caso random nos va a dar un numero del 0 al 1, si el numero es 0 xVelocity va a ser 1
        // si el numero es 1 el xVelocity va a ser -1
        float xVelocity = Random.Range(0, 2) == 0 ? 1 : -1;
        float yVelocity = Random.Range(0, 2) == 0 ? 1 : -1;
        ballRb.velocity = new Vector2(xVelocity, yVelocity) * initialVelocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioManager.Instance.PlaySound(hitball);
        if (collision.gameObject.CompareTag("Paddle") || collision.gameObject.CompareTag("Ai"))
        {
            ballRb.velocity *= velocityMultiplier;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Goal1"))
        {
            GameManager.Instance.Paddle1Scored();
            AudioManager.Instance.PlaySound(golSFX);
        }
        else
        {
            GameManager.Instance.Paddle2Scored();
            AudioManager.Instance.PlaySound(golSFX);
        }
        StartCoroutine(CheckGame());
    }

    IEnumerator CheckGame()
    {
        GameManager.Instance.VictoryCheck();
        ballRb.velocity = Vector2.zero;
        GameManager.Instance.RestarGame();
        yield return new WaitForSeconds(2f);
        Launch();
    }
}
