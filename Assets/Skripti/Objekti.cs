using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Objekti : MonoBehaviour {
	//Esosa kanva
	public Canvas kanva;
	//SpelesObjekti
	public GameObject atkritumaMasina;
	public GameObject atraPalidziba;
	public GameObject autobuss;
	public GameObject b2;
	public GameObject e46;
	public GameObject Eskavators;
	public GameObject Policija;
	public GameObject TraktorsDz;
	public GameObject TraktorsZal;
	public GameObject Cements;
	public GameObject Ugunsdzeseji;
	//SpelesObjektuKoordinates
	[HideInInspector]
	public Vector2 atkrKoord;
	[HideInInspector]
	public Vector2 atroKoord;
	[HideInInspector]
	public Vector2 bussKoord;
	[HideInInspector]
	public Vector2 b2Koord;
	[HideInInspector]
	public Vector2 e46Koord;
	[HideInInspector]
	public Vector2 EskKoord;
	[HideInInspector]
	public Vector2 PolKoord;
	[HideInInspector]
	public Vector2 TDzKoord;
	[HideInInspector]
	public Vector2 TZalKoord;
	[HideInInspector]
	public Vector2 CemeKoord;
	[HideInInspector]
	public Vector2 UgunsKoord;
	//Uzglabās audio avotu, kurā atskaņot attēlu skaņas efektus
	public AudioSource skanasAvots;
	//Masīvs, kas uzglabā visas iespējamās skaņas
	public AudioClip[] skanasKoAtskanot;
	//Mainīgais piefiksē vai objekts nolikts īstajāvietā (true/false)
	[HideInInspector]
	public bool vaiIstajaVieta = false;
	//Uzglabās pēdējo objektu, kurš pakustināts
	public GameObject pedejaisVilktais = null;
	//Punkti;
	public int punkti=0;
	//Uzvaras logs
	public GameObject uzvarasPanelis;
	//Restartesanas poga
	public GameObject restartPoga;
	//Zvaigznu vertejumi
	public GameObject zvaigzne1;
	public GameObject zvaigzne2;
	public GameObject zvaigzne3;
	//Laika vertiba
	public float laiks;
	//Vai laiks tiek skaitits
	public bool laiksAktivs=true;
	//Teksts, kas parada laiku.
	public Text parada;


	void Start () {
		//Dabu masinu koordinates
		atkrKoord = atkritumaMasina.GetComponent<RectTransform> ().localPosition;	
		atroKoord = atraPalidziba.GetComponent<RectTransform> ().localPosition;	
		bussKoord = autobuss.GetComponent<RectTransform> ().localPosition;	
		b2Koord = b2.GetComponent<RectTransform> ().localPosition;
		e46Koord = e46.GetComponent<RectTransform> ().localPosition;
		EskKoord = Eskavators.GetComponent<RectTransform> ().localPosition;
		PolKoord = Policija.GetComponent<RectTransform> ().localPosition;
		TDzKoord = TraktorsDz.GetComponent<RectTransform> ().localPosition;
		TZalKoord = TraktorsZal.GetComponent<RectTransform> ().localPosition;
		CemeKoord = Cements.GetComponent<RectTransform> ().localPosition;
		UgunsKoord = Ugunsdzeseji.GetComponent<RectTransform> ().localPosition;
		//Uzvaras komponetus uztaisa neredzamus
		uzvarasPanelis.SetActive(false);
		restartPoga.SetActive(false);
		zvaigzne1.SetActive (false);
		zvaigzne2.SetActive (false);
		zvaigzne3.SetActive (false);
		parada.GetComponent<Text> ().enabled = false;


	}
}
