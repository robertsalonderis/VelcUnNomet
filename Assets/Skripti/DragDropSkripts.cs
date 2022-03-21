using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Jāimporte, lai lietotu visus I interfeisus
using UnityEngine.EventSystems;

public class DragDropSkripts : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler {
	//Priekš pārvietojamā opbjekta atrašanās vietas uzglabāšanas
	private RectTransform velkObjRectTransf;
	//Velkamajam objektam piestiprinātā komponente
	private CanvasGroup kanvasGrupa;
	//Norāde uz objektu skriptu
	public Objekti objektuSkripts;
	void Start () {
		//Piekļūst objekta piestiprinātajai CanvasGroup komponentei
		kanvasGrupa = GetComponent<CanvasGroup> ();
		//Piekļūst objekta RectTransform komponentei
		velkObjRectTransf = GetComponent<RectTransform> ();
	}
	public void OnPointerDown(PointerEventData notikums){
		Debug.Log ("Kreisais kliksis uz objekta!");
	}
	public void OnBeginDrag(PointerEventData notikums){
		Debug.Log ("Uzsakts objekta vilksana!");
		//Velkot objektu tas paliek caurspīdīgs
		kanvasGrupa.alpha = 0.6F;
		//Lai objektam velkot iet cauri raycast stari
		kanvasGrupa.blocksRaycasts = false;
		objektuSkripts.pedejaisVilktais = null;

	}
	public void OnDrag(PointerEventData notikums){
		//Maina objekta x, y koordinātas
	   velkObjRectTransf.anchoredPosition += notikums.delta / objektuSkripts.kanva.scaleFactor;
	}
	public void OnEndDrag(PointerEventData notikums){
		Debug.Log ("Objekta vilksanas partraukta!");
		//Padarina objektu necaurspidigu
		kanvasGrupa.alpha = 1F;
		objektuSkripts.pedejaisVilktais = notikums.pointerDrag;
		//Ja objekts nebija nolikts ītajā vietā
		if (objektuSkripts.vaiIstajaVieta == false) {
			//Tad to atkal var vilkt
			kanvasGrupa.blocksRaycasts = true;
			//Ja nolikts ītajā vietā
		} else {
			//Aizmirst pēdejo objektu, kas vilkts
			objektuSkripts.pedejaisVilktais = null;
		}
		//Ja viens objekts nolikts īstajā vieta, tad lai varētu turpināt vilkt pārejos
		//iestata uz false
		objektuSkripts.vaiIstajaVieta = false;
	}
}
