using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAndShoot : MonoBehaviour
{
   //Variables for shooting
    public GameObject crosshairs;
    public GameObject player;
    public GameObject bulletPrefab;
    public GameObject bulletStart;

    //for collision
    private Rigidbody2D rb;
    private Vector2 screenBounds;

    public float bulletSpeed = 60.0f;

    public float coolDown = 1;
    public float coolDownTimer;

    private Vector3 target;

    // Use this for initialization
    void Start()
    {
        Cursor.visible = false;
       screenBounds = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        crosshairs.transform.position = new Vector2(target.x, target.y);

        Vector3 difference = target - player.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        player.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);

        if (coolDownTimer > 0)
        {
            coolDownTimer -= Time.deltaTime;
        }
        if (coolDownTimer < 0)
        {
            coolDownTimer = 0;
        }

        //Shoot bullet from end of barrel if mouse down
        if (Input.GetMouseButtonDown(0) && coolDownTimer == 0)
        {
            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            direction.Normalize();
            shootBullet(direction, rotationZ);
            coolDownTimer = coolDown;
        }

        //Remove bullet if off screen
        
    }

    public void shootBullet(Vector2 direction, float rotationZ)
    {
        AudioSource audioData;
        audioData = GetComponent<AudioSource>();
        audioData.Play(0);

        GameObject b = Instantiate(bulletPrefab) as GameObject;
        b.transform.position = bulletStart.transform.position;
        b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);

        b.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
    }

    // Fires bullet from "bulletStart" location which I put at the tip of the barrel.
    //void fireBullet()
    //{
    //    GameObject b = Instantiate(bulletPrefab) as GameObject;
    //    
    //    b.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;

    //    //if (b.transform.position.x > screenBounds.x * 2 )
    //    //{
    //    //    Destroy(b);
    //    //}
    //}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "squirrel")
        {
            //GameObject e = Instantiate(explosion) as GameObject;
            //e.transform.position = transform.position;
            //Destroy(other.gameObject);
            //Destroy(this.gameObject);
        }
    }
}
