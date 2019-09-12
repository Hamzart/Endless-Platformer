using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float speed = 2.0f;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per 
	void Update () {
		transform.Translate (speed * Time.deltaTime, 0, 0, Space.World);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		
		if (other.tag =="Block")
		{
			Vector3 spawnPos = new Vector3 (other.GetComponent<SpriteRenderer> ().bounds.max.x, other.GetComponent<SpriteRenderer> ().bounds.min.y, 0);

			GameObject.Find ("PlatformGenerator").SendMessage ("CreateNewBlock",spawnPos);

		}

		else if (other.tag =="cave")
		{
			GameObject.Find ("PlatformGenerator").GetComponent<PlatformGenerator>().currentWorld = "Cave";

			Vector3 spawnPos = new Vector3 (other.transform.parent.GetComponent<SpriteRenderer> ().bounds.min.x, other.transform.parent.GetComponent<SpriteRenderer> ().bounds.min.y - other.transform.parent.GetComponent<SpriteRenderer> ().size.y, 0);
			GameObject.Find ("PlatformGenerator").SendMessage ("CreateNewBlock",spawnPos);

			transform.position = new Vector3 (transform.position.x, other.transform.parent.GetComponent<SpriteRenderer> ().bounds.min.y - 1 , transform.position.z);


		}

	}
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag =="Block")
		{
			other.GetComponent<BlockSelfManage> ().isAfterPlayer=true;
		}
	}



}
