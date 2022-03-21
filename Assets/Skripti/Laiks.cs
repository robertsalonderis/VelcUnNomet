using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Laiks : MonoBehaviour {
	public Objekti objektuSkripts;

	//Laiku skaita;
	void Update () {
		//Ja bool vertiba ir true tad skaita laiku.
		if(objektuSkripts.laiksAktivs==true){
			objektuSkripts.laiks += Time.deltaTime;
		}
	
}
}
