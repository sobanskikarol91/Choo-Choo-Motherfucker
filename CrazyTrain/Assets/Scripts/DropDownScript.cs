using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDownScript : MonoBehaviour 
{
	List<string> resolutions = new List<string>(){"1920x1080", "1366x768", "1280x1024"};
	public Dropdown dropDown;
	public Text selectedResolution;
	public void Dropdown_IndexChanged(int index)
	{
		string resolution = resolutions[index];
		switch (resolution)
		{
			case "1920x1080":
			Screen.SetResolution(1920, 1080, true, 60);
			Debug.Log(Screen.currentResolution);
			break;
			case "1366x768":
			Screen.SetResolution(1366, 768, true, 60);
			Debug.Log(Screen.currentResolution);
			break;
			case "1280x1024":
			Screen.SetResolution(1280, 1024, true, 60);
			Debug.Log(Screen.currentResolution);
			break;
			default:
			Debug.Log(Screen.currentResolution);
			break;
		}
	}
	// Use this for initialization
	void Start () 
	{
		PopulateList();
	}
	 void PopulateList()
	 {
		dropDown.AddOptions(resolutions);
	 }
}
