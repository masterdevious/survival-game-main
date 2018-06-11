using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour
{

    public Rigidbody2D projectile;
    public Transform Spawnpoint;
    private Vector2 direction;
    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, 5.5f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Spawn(Transform trans)
    {
        projectile = GetComponent<Rigidbody2D>();
        Rigidbody2D clone;
        clone = (Rigidbody2D)Instantiate(projectile, trans.position, Quaternion.identity);
        //clone.velocity = trans.TransformDirection(Vector3.forward * 20);
        //projectile.AddForce(Vector2.right * 3f);
        direction = Vector2.right;
        clone.velocity = Vector2.right * 5f;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collision");
        if (other.gameObject.tag == "NPC")
        {
            Destroy(gameObject);
        }
    }
}
