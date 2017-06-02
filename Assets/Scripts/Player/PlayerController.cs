using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public float movementSpeed;

	public GameObject projectile;
	public Rigidbody projectileRB;
	public Transform shotSpawn;
	public float fireRate;
    public AudioSource playerFire;

    public float time;
	private float nextFire;
	private Rigidbody rb;
    private GameObject projInstance;

	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
	}

	void Update ()
	{
		//Movement function
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.velocity = movement * movementSpeed;


        //Player attack
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            projInstance = (GameObject)Instantiate(projectile, shotSpawn.position, shotSpawn.rotation);
            projectileRB.AddForce(shotSpawn.forward * 5000);
            playerFire.Play();
            Debug.Log("hello!");

        }
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.transform.tag == "Enemy")
        {
            //projInstance = (GameObject)Instantiate(projectile, transform.position, transform.rotation);
            Destroy(projInstance, 10);
        }

    }

}