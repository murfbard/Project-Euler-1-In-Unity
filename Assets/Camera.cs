using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        transform.RotateAround(new Vector3(5,5,5), Vector3.up, 30 * Time.deltaTime);
	}

}
