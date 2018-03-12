using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taikymasis : MonoBehaviour {


    public float turnSpeed = 10f;       //bokštelio vamzdžio sukimosi greitis

    public GameObject projectilePrefab; //Skriptui priskirtas sviedinio prefab  
    public GameObject exit_Point;       //Iš kur išskrenda sviedinys
    public float speed;                 //Sviedinio greitis. Žiauriai priklauso ir nuo sviedinio masės Prefabs >> Projectile >> Rigidbody2D >> Mass
    private Rigidbody2D rb;

    

    void Update()
    {
        Rotate();

        Vector2 target = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        Vector2 exitPoint = new Vector2(exit_Point.transform.position.x, exit_Point.transform.position.y);
        Vector2 direction = target - exitPoint;
        direction.Normalize();

        Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
        transform.rotation = rotation;

        if (Input.GetButtonDown("Fire1")) //Viršuje unity lango   Edit >> Project settings >> Input >> Axes >> Fire1
        {
            GameObject shot = (GameObject)Instantiate(projectilePrefab, exitPoint, rotation);
            rb = shot.GetComponent<Rigidbody2D>();
            rb.AddForce(direction * speed);
        }
    }

    //Bokštelio vamzdis sukasi pelės kryptimi
    void Rotate()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, turnSpeed * Time.deltaTime);
    }  
}
