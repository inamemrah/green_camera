using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HariciKamera : MonoBehaviour {

	Renderer obje;
	public int deviceID = 0;
	public string kameraAdi;
	public int istenenGenislik = 720;
	public int istenenYuseklik = 576;
	public int istenenKareSayi = 25;

	// Use this for initialization
	void Start () {

		WebCamDevice[] kameralar = WebCamTexture.devices;

		WebCamTexture kameraGoruntu = new WebCamTexture (istenenGenislik, istenenYuseklik, istenenKareSayi);

		kameraAdi = kameralar [deviceID].name;

		obje = GetComponent<Renderer> ();

		obje.material.mainTexture = kameraGoruntu;

		kameraGoruntu.Play ();




	}





	
	// Update is called once per frame
	void Update () {
		
	}
}
