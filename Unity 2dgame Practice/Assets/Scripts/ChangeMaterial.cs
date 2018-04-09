using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour {

	// Use this for initialization
	void Start () {
        SpriteRenderer render = this.GetComponent<SpriteRenderer>();
        render.material.color = new Color(1, 0, 0, 1);
	}
	
}
