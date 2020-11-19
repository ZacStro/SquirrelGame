using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject acorn;

    float moveSpeed = 20;
    public Rigidbody2D rb;
    public Animator animator;
    Vector2 movement;
    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * (moveSpeed / 2) * Time.fixedDeltaTime);
    }

    private void SpawnAcorn()
    {
        bool spawned = false;
        while (!spawned)
        {
            Vector3 acornPosition = new Vector3(Random.Range(-20f, 20f), Random.Range(-20f, 20f), 0f);
            if ((acornPosition - transform.position).magnitude < 3)
            {
                continue;
            }
            else
            {
                Instantiate(acorn, acornPosition, Quaternion.identity);
                spawned = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Acorn")
        {
            ScoreScript.scoreValue += 1;
            Destroy(other.gameObject);
            SpawnAcorn();
            AudioSource audioData;
            audioData = GetComponent<AudioSource>();
            audioData.Play(0);
        }




    }
}
