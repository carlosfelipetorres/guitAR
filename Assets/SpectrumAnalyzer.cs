using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpectrumAnalyzer : MonoBehaviour {
	public Text text;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float[] spectrum = new float[1024];
		AudioListener.GetSpectrumData(spectrum, 0, FFTWindow.Hamming);
		float l1 = spectrum [0] + spectrum [2] + spectrum [4];
		float l2 = spectrum [10] + spectrum [11] + spectrum [12];
		float l3 = spectrum[20] + spectrum [21] + spectrum [22];
		float l4 = spectrum [40] + spectrum [41] + spectrum [42] + spectrum [43];
		float l5 = spectrum [80] + spectrum [81] + spectrum [82] + spectrum [83];
		float l6 = spectrum [160] + spectrum [161] + spectrum [162] + spectrum [163];
		float l7 = spectrum [320] + spectrum [321] + spectrum [322] + spectrum [323];
		Debug.Log(l1 + " " + l2 + " " + l3 + " " + l4 + " " + l5 + " " + l6 + " " + l7);
		text.text = l1 + " " + l2 + " " + l3 + " " + l4 + " " + l5 + " " + l6 + " " + l7;
		GameObject [] cubes = GameObject.FindGameObjectsWithTag("notes");

		for( int i = 1; i < cubes.Length; i++)
		{
			switch (cubes[i].name)
			{
			case "Mi":
				if(l1 > 0.2) cubes [i].gameObject.GetComponent<Renderer> ().material.color = Color.red;
				break;
			case "Si":
				if(l2 > 0.2) cubes[i].gameObject.GetComponent<Renderer> ().material.color = Color.red;
				break;
			case "Sol":
				if(l3 > 0.2) cubes[i].gameObject.GetComponent<Renderer> ().material.color = Color.red;
				break;
			case "Re":
				if(l4 > 0.2) cubes[i].gameObject.GetComponent<Renderer> ().material.color = Color.red;
				break;
			case "La":
				if(l5 > 0.2) cubes[i].gameObject.GetComponent<Renderer> ().material.color = Color.red;
				break;
			case "MI":
				if(l6 > 0.2) cubes[i].gameObject.GetComponent<Renderer> ().material.color = Color.red;
				break;
			}           
		}
	}
}
