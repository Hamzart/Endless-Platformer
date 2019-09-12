using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSelfManage : MonoBehaviour {

	// Use this for initialization
	public bool isAfterPlayer=false;

	// Update is called once per frame
	void LateUpdate () {

		if (isAfterPlayer) {


			Vector3 cameraview = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, 0));
			if (GetComponent<SpriteRenderer> ().bounds.max.x < cameraview.x) {

				Destroy (gameObject);

			}
		}
	}
}
