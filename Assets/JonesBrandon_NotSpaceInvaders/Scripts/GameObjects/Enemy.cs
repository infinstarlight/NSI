using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public GameObject enemy;
	public int startHealth = 5;
	public int currentHealth;
    private Transform player;

    private IEnumerator coroutine;

    void Awake ()
	{
		currentHealth = startHealth;
    }
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
	}

	void Death ()
	{
		Destroy (gameObject);
		Debug.Log ("Heeeeeeeeeeeeeeyyyyyyyyyyyyyy! That hurt!");
	}
}