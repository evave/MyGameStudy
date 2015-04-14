using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour {
	private BossController bossController;
	// Use this for initialization
	void Awake () {
		bossController = GameObject.FindGameObjectWithTag("Boss").GetComponent<BossController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerExit(Collider other){
		if(other.tag == "Player"){
			// Change the camera behavior
			// Wake up the boss
			bossController.bossAwake = true;
			// Disable Character Movement
			collider.isTrigger = false;
		}
	}
}
