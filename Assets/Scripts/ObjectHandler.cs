using UnityEngine;
using System.Collections;

public class ObjectHandler : MonoBehaviour {

	//private List<Character> _characters;
	StateType _currentstate;

	public void ChangeState(StateType newstate)
	{
		_currentstate = newstate;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
