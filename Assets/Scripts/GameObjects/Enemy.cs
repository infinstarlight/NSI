using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public GameObject enemy;
	public int startHealth = 5;
	public int currentHealth;
    private Transform player;
    public AudioSource DeathSound;

    private IEnumerator coroutine;

    void Awake ()
	{
		currentHealth = startHealth;
    }

    // Remember to disable "Play On Awake" on Audio Source component
    void OnTriggerEnter(Collider otherObj)
    {
        if (otherObj.tag == "PlayerProjectile")
        {
            Debug.Log("Ouch!");
            TakeDamage(currentHealth);
            
        }
        //if (otherObj.gameObject.tag == "Player")
        //{
        //    Destroy(gameObject);
        //}
    }
    public void TakeDamage (int amount)
	{
		currentHealth--;
		if (currentHealth <= 0)
			Death ();
        //DeathSound.Play();
    }

	void Death ()
	{
		Destroy (gameObject);
		Debug.Log ("Heeeeeeeeeeeeeeyyyyyyyyyyyyyy! That hurt!");
        DeathSound.Play();
    }
}