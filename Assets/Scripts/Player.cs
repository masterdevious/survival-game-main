using UnityEngine;
using System.Collections;

	//Player inherits from MovingObject, our base class for objects that can move, Enemy also inherits from this.
	public class Player : MonoBehaviour
	{

	//public LayerMask Water;

	private Rigidbody2D rb2d;	
	private BoxCollider2D boxCollider;
	private bool moving;
	private Vector2 direction;
	private RaycastHit2D hit;
	private int moveCycle;
	private int moveCycMax;
	private Animator animator;
    
    // make private after debug is complete
    public Fireball fireball;
    public int health = 100;
    public float speed = 5.0f;

		//Start overrides the Start function of MovingObject
		private void Start ()
		{
			rb2d = GetComponent <Rigidbody2D> ();
			boxCollider = GetComponent <BoxCollider2D> ();
			animator = GetComponent<Animator> ();
			moving = false;
			direction = Vector2.zero;
			moveCycMax = 10;
			moveCycle = 0;
		}

		
		
		private void Update ()
		{
			//big list of cases that will depend on the current state of the stack, have seperate subroutine for each
			//create seperate function for checking linecast in each direction
			//if(!moving)
			//{
				if (Input.GetKey(KeyCode.RightArrow))
				{
					direction = Vector2.right;
                    animator.SetTrigger("walkRight");
                    //Move ();
				}
			
				else if (Input.GetKey(KeyCode.LeftArrow))
				{
					direction = -Vector2.right;
                    animator.SetTrigger("walkLeft");
                    //Move ();
				}
			
				else if (Input.GetKey(KeyCode.UpArrow))
				{
					direction = Vector2.up;
                    animator.SetTrigger("walkUp");
                    //Move ();
				}
			
				else if (Input.GetKey(KeyCode.DownArrow))
				{
					direction = -Vector2.up;
					animator.SetTrigger("walkDown");
					//Move ();
				}

				else if (Input.GetKeyDown(KeyCode.A))
				{
                //handle in game manager, have either a preset textbox set to false from the start or instantiate a textbox here when it is called
                //GameObject textBox = GameObject.Find("Canvas");
                //textBox.SetActive(false);
				    Talk();
				}

                else if (Input.GetKeyDown(KeyCode.S))
                {
                    fireball.Spawn(this.transform);
                }

                else
                {
                    direction = Vector2.zero;
                }
			
			//}

			/*else
			{
				if(moveCycle<10)
				{
					moveCycle++;
					rb2d.transform.position += (((Vector3)direction)/moveCycMax);
				}
				else
				{
					moveCycle = 0;
					moving = false;
				}
			}*/
		}

    void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + direction * speed * Time.fixedDeltaTime);
    }

    private void Attack()
        {
        Fireball clone;
        clone = Instantiate(fireball, transform.position, transform.rotation) as Fireball;
        Rigidbody projectile = clone.GetComponent<Rigidbody>();
        projectile.velocity = direction;
    }

		private void Move ()
		{
			Vector2 start = transform.position;
			Vector2 end = start + direction;

			boxCollider.enabled = false;
			hit = Physics2D.Linecast (start, end,1<<LayerMask.NameToLayer("BlockingLayer"));
			boxCollider.enabled = true;

			if (hit.transform == null) 
			{
				moving = true;
			} 

			else if(hit.transform != null)
			{
				moving = false;
			}
		}
			
		private void OnTriggerEnter2D(Collider2D other)
		{
			if(other.tag == "Door")
			{
				rb2d.transform.position = new Vector3(0,0,0); //needs to go to game manager
			}
		}

		private void Talk()
		{
			Vector2 start = transform.position;
			Vector2 end = start + direction;

			boxCollider.enabled = false;
			hit = Physics2D.Linecast (start, end,1<<LayerMask.NameToLayer("BlockingLayer"));
			boxCollider.enabled = true;

			if (hit.transform == null) 
			{
				Debug.Log (end.ToString ());
			} 
		
			else if (hit.transform.tag == "NPC") 
			{
				NPC tto = hit.transform.GetComponent<NPC>();
			if(tto != null)
			{
				Debug.Log(tto.Talk(direction));
			}
		}
			
		}

	}