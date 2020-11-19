using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterMovement : MonoBehaviour
{
    float moveSpeed2 = 3;
    public Rigidbody2D rb2;
    public Camera cam;

    Vector2 mousPos;
    Vector2 movement2;

    // Update is called once per frame
    void Update()
    {
        movement2.x = Input.GetAxisRaw("Horizontal");
        movement2.y = Input.GetAxisRaw("Vertical");

        mousPos = cam.ScreenToWorldPoint(Input.mousePosition);
    }
    private void FixedUpdate()
    {
        rb2.MovePosition(rb2.position + movement2 * (moveSpeed2 / 2) * Time.fixedDeltaTime);

        Vector2 lookDir = mousPos - rb2.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb2.rotation = angle;

    }
}
