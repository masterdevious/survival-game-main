using UnityEngine;
using System.Collections;

public class InputHandler : MonoBehaviour {

	StateType _currentstate;
	
	public void ChangeState(StateType newstate)
	{
		_currentstate = newstate;
	}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		switch(_currentstate)
		{
		case StateType.Battle:
			HandleBattle();
			break;
		case StateType.Menu:
			HandleMenu();
			break;
		case StateType.World:
			HandleWorld();
			break;
		}
	}

	void HandleBattle ()
	{
		throw new System.NotImplementedException ();
	}

	void HandleMenu ()
	{
		throw new System.NotImplementedException ();
	}

	void HandleWorld ()
	{
		throw new System.NotImplementedException ();
	}
}
