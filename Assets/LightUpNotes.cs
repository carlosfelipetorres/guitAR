using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightUpNotes : MonoBehaviour {

	public GameObject[] notas;

	public Color altColor = Color.red;
	public float sec = 10f;
	// Use this for initialization
	void Start () {
		//mi.GetComponent<Renderer>().material.color = altColor;
		StartCoroutine(LateCall(0));
	}

	IEnumerator LateCall(int i)
	{
		if (i < notas.Length) {
			yield return new WaitForSeconds (sec);

			notas [i].GetComponent<Renderer> ().material.color = altColor;
			i = i + 1;
			StartCoroutine (LateCall (i));
		}
	}
}
