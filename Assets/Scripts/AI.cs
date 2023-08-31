using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AI : MonoBehaviour
{
    [SerializeField] private float aiSpeed = 5f;
    [SerializeField] private Transform ballTransform;
    private float aivelocity = 1.05f;

    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (transform.position.y > ballTransform.position.y)
        {
            transform.position += new Vector3(0, -aiSpeed * Time.deltaTime);
        }
        else if (transform.position.y < ballTransform.position.y)
        {
            transform.position += new Vector3(0, aiSpeed * Time.deltaTime);
        }
    }

    public void VelocityAI()
    {
        aiSpeed *= aivelocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            VelocityAI();
        }
    }
}
