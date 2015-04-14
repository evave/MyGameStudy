using UnityEngine;
using System.Collections;

public class BossController : MonoBehaviour {

	public bool bossAwake = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(bossAwake){
			print ("Boss is Awake");
			// Play intro animation

		}
	}
}
