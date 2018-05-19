using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taikymasis : MonoBehaviour {

    public GameObject basicShotParticle;
    public GameObject cannonShotParticle;
    public GameObject shotgunShotParticle;

    private AudioSource audioSource;
    public AudioClip ShotSound;
    private float volLowRange = .2f;
    private float volHighRange = 1.5f;

    public float turnSpeed = 10f;       //bokštelio vamzdžio sukimosi greitis

    public GameObject projectilePrefab; //Skriptui priskirtas sviedinio prefab  
    public GameObject exit_Point;       //Iš kur išskrenda sviedinys
    public static float speed = 50;     //Sviedinio greitis. Žiauriai priklauso ir nuo sviedinio masės Prefabs >> Projectile >> Rigidbody2D >> Mass
    public static int weaponType = 1;   //1 - pradinis ginklas, 2 - shotgun'as, 3 - didelė patranka
    private Rigidbody2D rb;
	public bool readyToShoot = true;
	public int shot = 0;
    public static float fireRate = 0.5f;
    float nextFire;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {       
        Rotate();
        audioSource.pitch = Random.Range(volLowRange, volHighRange);

        Vector2 exitPoint = new Vector2(exit_Point.transform.position.x, exit_Point.transform.position.y);
        Vector2 particleExitPoint = new Vector2(exit_Point.transform.position.x - 1, exit_Point.transform.position.y);
		if (shot == 1) {
			shot = 0;
		}

        if (Input.GetButtonDown("Fire1") && Player.magazineEmpty == false && Time.time > nextFire) //Viršuje unity lango   Edit >> Project settings >> Input >> Axes >> Fire1
        {
            audioSource.PlayOneShot(ShotSound);

            nextFire = Time.time + fireRate;
            switch (weaponType)
            {
                case 1:

                    Vector2 target = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));

                    Vector2 direction = target - exitPoint;
                    Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
                    transform.rotation = rotation;

                    direction.Normalize();

                    GameObject shot = (GameObject)Instantiate(projectilePrefab, exitPoint, rotation);
                    rb = shot.GetComponent<Rigidbody2D>();
                    rb.AddForce(direction * speed);
                    Instantiate(basicShotParticle, particleExitPoint, rotation);               
                    Player.bulletCount -= 1;
                    break;
           
                case 2:

                    Vector2 target1 = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
                    Vector2 target2 = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y + 140));
                    Vector2 target3 = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y - 140));

                    Vector2 direction1 = target1 - exitPoint;
                    Vector2 direction2 = target2 - exitPoint;
                    Vector2 direction3 = target3 - exitPoint;

                    Quaternion rotation1 = Quaternion.Euler(0, 0, Mathf.Atan2(direction1.y, direction1.x) * Mathf.Rad2Deg);
                    Quaternion rotation2 = Quaternion.Euler(0, 0, Mathf.Atan2(direction2.y, direction2.x) * Mathf.Rad2Deg);
                    Quaternion rotation3 = Quaternion.Euler(0, 0, Mathf.Atan2(direction3.y, direction3.x) * Mathf.Rad2Deg);

                    transform.rotation = rotation1;

                    GameObject shotMiddle = (GameObject)Instantiate(projectilePrefab, exitPoint, rotation1);
                    GameObject shotUpper = (GameObject)Instantiate(projectilePrefab, exitPoint, rotation2);
                    GameObject shotLower = (GameObject)Instantiate(projectilePrefab, exitPoint, rotation3);

                    rb = shotMiddle.GetComponent<Rigidbody2D>();
                    Rigidbody2D rb2 = shotUpper.GetComponent<Rigidbody2D>();
                    Rigidbody2D rb3 = shotLower.GetComponent<Rigidbody2D>();

                    rb.AddForce(direction1 * (speed + 10));
                    rb2.AddForce(direction2 * (speed + 10));
                    rb3.AddForce(direction3 * (speed + 10));

                    Instantiate(shotgunShotParticle, particleExitPoint, rotation2);

                    Player.bulletCount -= 3;
                    if(Player.bulletCount < 0)
                        Player.bulletCount = 0;
                    break;

                case 3:

                    Vector2 targetB = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));

                    Vector2 directionB = targetB - exitPoint;
                    Quaternion rotationB = Quaternion.Euler(0, 0, Mathf.Atan2(directionB.y, directionB.x) * Mathf.Rad2Deg);
                    transform.rotation = rotationB;

                    directionB.Normalize();

                    GameObject shotB = (GameObject)Instantiate(projectilePrefab, exitPoint, rotationB);
                    shotB.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
                    rb = shotB.GetComponent<Rigidbody2D>();              
                    rb.AddForce(directionB * speed * 50);
                    rb.mass = 0.2f;

                    Instantiate(cannonShotParticle, particleExitPoint, rotationB);

                    Player.bulletCount -= 1;
                    break;
            }               
        }
		if (Input.GetButton ("Fire1") == true && weaponType == 4 && Player.magazineEmpty == false && Time.time > nextFire) {

            audioSource.PlayOneShot(ShotSound);
            nextFire = Time.time + fireRate / 3;

            Vector2 targetC = Camera.main.ScreenToWorldPoint (new Vector2 (Input.mousePosition.x, Input.mousePosition.y));

			Vector2 directionC = targetC - exitPoint;
			Quaternion rotationC = Quaternion.Euler (0, 0, Mathf.Atan2 (directionC.y, directionC.x) * Mathf.Rad2Deg);
			transform.rotation = rotationC;

			directionC.Normalize ();

			GameObject shotC = (GameObject)Instantiate (projectilePrefab, exitPoint, rotationC);
			rb = shotC.GetComponent<Rigidbody2D> ();
			rb.AddForce (directionC * speed * 4);

			//StartCoroutine (ShootDelayAR ());

			Instantiate (basicShotParticle, particleExitPoint, rotationC);      

			Player.bulletCount -= 1;
		}
	}
	IEnumerator ShootDelayAR()
	{
		yield return new WaitForSeconds (0.5f);
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
