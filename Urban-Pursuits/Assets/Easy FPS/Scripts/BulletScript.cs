using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	[Tooltip("Furthest distance bullet will look for target")]
	public float maxDistance = 1000000;
	RaycastHit hit;
	[Tooltip("Prefab of wall damange hit. The object needs 'LevelPart' tag to create decal on it.")]
	public GameObject decalHitWall;
	[Tooltip("Decal will need to be sligtly infront of the wall so it doesnt cause rendeing problems so for best feel put from 0.01-0.1.")]
	public float floatInfrontOfWall;
	[Tooltip("Blood prefab particle this bullet will create upoon hitting enemy")]
	public GameObject bloodEffect;
	[Tooltip("Put Weapon layer and Player layer to ignore bullet raycast.")]
	public LayerMask ignoreLayer;

	[Tooltip("Particle system for the bullet trail")]
    public ParticleSystem trailEffect;

	void Start()
    {
        // Instantiate the trail effect at the bullet's position and parent it to the bullet
        if (trailEffect != null)
        {
            ParticleSystem trailInstance = Instantiate(trailEffect, transform.position, Quaternion.identity, transform);
            trailInstance.Play();
        }
    }

	/*
	* Uppon bullet creation with this script attatched,
	* bullet creates a raycast which searches for corresponding tags.
	* If raycast finds somethig it will create a decal of corresponding tag.
	*/
	void Update () {

		if(Physics.Raycast(transform.position, transform.forward,out hit, maxDistance, ~ignoreLayer)){
			if(decalHitWall){
				if(hit.transform.tag == "LevelPart"){
					Instantiate(decalHitWall, hit.point + hit.normal * floatInfrontOfWall, Quaternion.LookRotation(hit.normal));
					Destroy(gameObject);
				}
				if(hit.transform.tag == "Dummie"){
    Instantiate(bloodEffect, hit.point, Quaternion.LookRotation(hit.normal));
    EnemyHealth enemyHealth = hit.transform.GetComponent<EnemyHealth>();
    if (enemyHealth != null)
    {
        enemyHealth.TakeDamage(20f); // Replace 20f with the actual damage amount
    }
}
			}		
			Destroy(gameObject);
		}
		Destroy(gameObject, 0.1f);
	}

}
