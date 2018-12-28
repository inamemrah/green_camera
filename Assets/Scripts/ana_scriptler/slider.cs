using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class slider : MonoBehaviour {

	public GameObject Plane; 
	public Material shader;

	public Slider Thereshold;
	public Slider Slope;



	void Start()
	{
		
		Plane.GetComponent<Material> ().SetColor("_keyingColor", new Color(0,255,55,255));
		shader.SetColor ("_keyingColor", new Color(0,255,55,255));
	
	}


	public void Thres_slide(float newThresh)
	{
		shader.SetFloat ("_thresh", newThresh);

		//Plane.GetComponent<Material> ().SetFloat("_thresh", newThresh);
	}

	public void Slope_slide(float newSlope)
	{
		shader.SetFloat ("_slope", newSlope);

		//Plane.GetComponent<Material> ().SetFloat("_thresh", newSlope);
	}
}
