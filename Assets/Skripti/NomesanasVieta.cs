using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NomesanasVieta : MonoBehaviour, IDropHandler {
	//Uzglabās velkamā objekta un nomešanas lauka z rotāciju,
	// kāarī rotācijas un izmēru pieļaujamo starpību
	private float vietasZrot, velkObjZrot, rotacijasStarpiba;
	private Vector2 vietasIzm, velkObjIzm;
	private float xIzmeruStarp, yIzmeruStarp;
	//Norāde uz Objekti skriptu
	public Objekti objektuSkripts;
	//Nostrādās, ja objektu cenšas nomest uz jebkuras nomešanas  vietas
	public void OnDrop(PointerEventData notikums){
		//Pārbauda vai tika vilkts un atlaists vispār kāds objekts
		if (notikums.pointerDrag != null) {
			//Ja nomešanas vietas tags sakrīt ar vilktā objekta tagu
			if (notikums.pointerDrag.tag.Equals (tag)) {
				//Iegūst objekta rotāciju grādos
				vietasZrot = notikums.pointerDrag.GetComponent<RectTransform> ().eulerAngles.z;
				velkObjZrot = GetComponent<RectTransform> ().eulerAngles.z;
				//Aprēkina abu objektu z rotācijas starpību
				rotacijasStarpiba = Mathf.Abs (vietasZrot - velkObjZrot);
				//Līdzīgi kā ar Z rotāciju, jāpiefiksē objektu izmēri pa x un y asīm, kā arī starpība
				vietasIzm = notikums.pointerDrag.GetComponent<RectTransform> ().localScale;
				velkObjIzm = GetComponent<RectTransform> ().localScale;
				xIzmeruStarp = Mathf.Abs (vietasIzm.x - velkObjIzm.x);
				yIzmeruStarp = Mathf.Abs (vietasIzm.y - velkObjIzm.y);
				//Pārbauda vai objektu rotācijas un izmēru starpība ir pieļaujamajās robēžās
				if ((rotacijasStarpiba <= 6 || (rotacijasStarpiba >= 354 && rotacijasStarpiba <= 360)) && (xIzmeruStarp <= 0.1 && yIzmeruStarp <= 0.1)) {
					objektuSkripts.vaiIstajaVieta = true;
					//Noliktais objekts smuki iecentrējas nomešanas laukā
					notikums.pointerDrag.GetComponent<RectTransform> ().anchoredPosition = GetComponent<RectTransform> ().anchoredPosition;
					//Rotācijai
					notikums.pointerDrag.GetComponent<RectTransform> ().localRotation = GetComponent<RectTransform> ().localRotation;
					//Izsmēram
					notikums.pointerDrag.GetComponent<RectTransform> ().localScale = GetComponent<RectTransform> ().localScale;
					//Pārbauda tagu un atskaņo atbilstošo skaņas efektu un skaita vienu punktu
					switch (notikums.pointerDrag.tag) {
					case "Atkritumi":
						objektuSkripts.skanasAvots.PlayOneShot (objektuSkripts.skanasKoAtskanot [1]);
						objektuSkripts.punkti++;
						break;
					case "Slimnica":
						objektuSkripts.skanasAvots.PlayOneShot (objektuSkripts.skanasKoAtskanot [2]);
						objektuSkripts.punkti++;
						break;
					case "Autobuss":
						objektuSkripts.skanasAvots.PlayOneShot (objektuSkripts.skanasKoAtskanot [3]);
						objektuSkripts.punkti++;
						break;
					case "b2":
						objektuSkripts.skanasAvots.PlayOneShot (objektuSkripts.skanasKoAtskanot [4]);
						objektuSkripts.punkti++;
						break;
					case "e46":
						objektuSkripts.skanasAvots.PlayOneShot (objektuSkripts.skanasKoAtskanot [5]);
						objektuSkripts.punkti++;
						break;
					case "Eskavators":
						objektuSkripts.skanasAvots.PlayOneShot (objektuSkripts.skanasKoAtskanot [6]);
						objektuSkripts.punkti++;
						break;
					case "Policija":
						objektuSkripts.skanasAvots.PlayOneShot (objektuSkripts.skanasKoAtskanot [7]);
						objektuSkripts.punkti++;
						break;
					case "TraktorsDz":
						objektuSkripts.skanasAvots.PlayOneShot (objektuSkripts.skanasKoAtskanot [8]);
						objektuSkripts.punkti++;
						break;
					case "TraktorsZal":
						objektuSkripts.skanasAvots.PlayOneShot (objektuSkripts.skanasKoAtskanot [9]);
						objektuSkripts.punkti++;
						break;
					case "Cements":
						objektuSkripts.skanasAvots.PlayOneShot (objektuSkripts.skanasKoAtskanot [5]);
						objektuSkripts.punkti++;
						break;
					case "Ugundzesejs":
						objektuSkripts.skanasAvots.PlayOneShot (objektuSkripts.skanasKoAtskanot [10]);
						objektuSkripts.punkti++;
						break;
					default:
						Debug.Log ("Nedefinēts tags!");
						break;
					}
				}
				//Ja objekts nomests nepareizajā laukā
			} else {
				objektuSkripts.vaiIstajaVieta = false;
				objektuSkripts.skanasAvots.PlayOneShot (objektuSkripts.skanasKoAtskanot [0]);
				//Objektu aizmet uz sākotnējo pozīciju
				switch (notikums.pointerDrag.tag) {
				case "Atkritumi":
					objektuSkripts.atkritumaMasina.GetComponent<RectTransform> ().localPosition = objektuSkripts.atkrKoord;
					break;
				case "Slimnica":
					objektuSkripts.atraPalidziba.GetComponent<RectTransform> ().localPosition = objektuSkripts.atroKoord;
					break;
				case "Autobuss":
					objektuSkripts.autobuss.GetComponent<RectTransform> ().localPosition = objektuSkripts.bussKoord;
					break;
				case "b2":
					objektuSkripts.b2.GetComponent<RectTransform> ().localPosition = objektuSkripts.b2Koord;
					break;
				case "e46":
					objektuSkripts.e46.GetComponent<RectTransform> ().localPosition = objektuSkripts.e46Koord;
					break;
				case "Eskavators":
					objektuSkripts.Eskavators.GetComponent<RectTransform> ().localPosition = objektuSkripts.EskKoord;
					break;
				case "Policija":
					objektuSkripts.Policija.GetComponent<RectTransform> ().localPosition = objektuSkripts.PolKoord;
					break;
				case "TraktorsDz":
					objektuSkripts.TraktorsDz.GetComponent<RectTransform> ().localPosition = objektuSkripts.TDzKoord;
					break;
				case "TraktorsZal":
					objektuSkripts.Cements.GetComponent<RectTransform> ().localPosition = objektuSkripts.CemeKoord;
					break;
				case "Cements":
					objektuSkripts.Cements.GetComponent<RectTransform> ().localPosition = objektuSkripts.UgunsKoord;
					break;
				case "Ugundzesejs":
					objektuSkripts.TraktorsZal.GetComponent<RectTransform> ().localPosition = objektuSkripts.TZalKoord;
					break;

				default:
					Debug.Log ("Nedefinēts tags!");
					break;
				}
			}

		}
		//Parbauda vai ir maksimalie punkti
		if (objektuSkripts.punkti == 11) {
			//parada uzvaras logu, restartēšanas poga un spelejas uzvaras skana;
			objektuSkripts.uzvarasPanelis.SetActive (true);
			objektuSkripts.restartPoga.SetActive (true);
			objektuSkripts.skanasAvots.PlayOneShot (objektuSkripts.skanasKoAtskanot [11]);
			//Aptur laika skaitisanu un parada to uz ekrana.
			objektuSkripts.laiksAktivs = false;
			objektuSkripts.parada.GetComponent<Text> ().enabled = true;
			objektuSkripts.parada.text = "Jūs pabeidzāt spēli    "+Mathf.Round(objektuSkripts.laiks).ToString ()+" sekundēs!";
			//Parbauda vai esi izdarijis speli atri un parada atiecosas zvaigznes
			if (objektuSkripts.laiks <= 150) {
				objektuSkripts.zvaigzne1.SetActive (true);
			}
			if (objektuSkripts.laiks <= 100) {
				objektuSkripts.zvaigzne2.SetActive (true);
			}
			if (objektuSkripts.laiks <= 60) {
				objektuSkripts.zvaigzne3.SetActive (true);
			}
		}
   }

}
