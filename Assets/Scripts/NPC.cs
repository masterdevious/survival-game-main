using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NPC : MonoBehaviour 
{
	private SpriteRenderer spriteRenderer;

	public List<string> talk = new List<string>(); 
	public Sprite leftSprite;
	public Sprite rightSprite;
	public Sprite upSprite;
	public Sprite downSprite;

	// Use this for initialization
	void Start () 
	{
		spriteRenderer = GetComponent<SpriteRenderer> ();
	}
	
	public string Talk(Vector2 direction)
	{
		if (direction == Vector2.right) 
		{
			spriteRenderer.sprite = leftSprite;
		} 
		else if (direction == -Vector2.right) 
		{
			spriteRenderer.sprite = rightSprite;
		} 
		else if (direction == Vector2.up) 
		{
			spriteRenderer.sprite = downSprite;
		} 
		else if (direction == -Vector2.up) 
		{
			spriteRenderer.sprite = upSprite;
		}

		return talk[0];
	}
}
