using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Izvelne : MonoBehaviour {
	//Iet Uz Scene Pilseta
	public void pilseta(){
		SceneManager.LoadScene ("Pilseta", LoadSceneMode.Single);
	}
	//Iet Uz Scene More
	public void more(){
		SceneManager.LoadScene ("More", LoadSceneMode.Single);
	}
}
