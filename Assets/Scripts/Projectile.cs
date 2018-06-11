using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    public Rigidbody2D projectile;
    public Transform Spawnpoint;

    // Use this for initialization
    void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public void Spawn(Transform trans)
    {
        projectile = GetComponent<Rigidbody2D>();
        Rigidbody2D clone;
        clone = (Rigidbody2D)Instantiate(projectile, trans.position, Quaternion.identity);
        clone.velocity = trans.TransformDirection(Vector3.forward * 20);
    }
}
