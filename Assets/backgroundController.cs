using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class backgroundController : MonoBehaviour
{
	//[SerializeField] private GameObject cameraObj;
	[SerializeField] private GameObject back1;
	/*[SerializeField] private GameObject back2;
	[SerializeField] private GameObject back3;
	[SerializeField] private float finishSec;
    */

    [SerializeField] private float moveXDif;
    [SerializeField] private float finalbackX;

	//[SerializeField] private GameObject player;
	//[SerializeField] private playerController playerCon;

	private Vector3 firstPos;
	//private Vector3 cameraPos;

	void Start()
	{
		//cameraPos = cameraObj.transform.position;
		firstPos = back1.transform.position;
		//playerCon = player.GetComponent<playerController>();
		//backgroundMove();
	}

	void FixedUpdate () {
		
		transform.Translate (moveXDif, 0, 0);
		if (transform.position.x <= finalbackX) {
			transform.position = firstPos;
		}
		
		
		/*if (camera.transform.position.y > back1.transform.position.y + back1.transform.localScale.y / 2.0f)
		{
			Vector3 tmp1 = back1.transform.position;
			Vector3 tmp2 = back2.transform.position;
			back1.transform.position = new Vector3(tmp1.x, tmp2.y + (back1.transform.localScale.y), tmp1.z);
		}else if (camera.transform.position.y > back2.transform.position.y + back2.transform.localScale.y / 2.0f)
		{
			Vector3 tmp1 = back2.transform.position;
			Vector3 tmp2 = back1.transform.position;
			back2.transform.position = new Vector3(tmp1.x, tmp2.y + (back2.transform.localScale.y), tmp1.z);
		}*/
		
		/*else if (camera.transform.position.y > back3.transform.position.y + back3.transform.localScale.y / 2.0f)
		{
			Vector3 tmp1 = back3.transform.position;
			Vector3 tmp2 = back1.transform.position;
			back3.transform.position = new Vector3(tmp1.x, tmp2.y + (back3.transform.localScale.y), tmp1.z);
		}*/
		
		//if(transform.position.y + transform.localScale / 2.0f > )
	}
	
	/*
	private Tween backgroundMove(){
		return back.transform.DOMoveX(finalbackX, finishSec).SetLoops(-1, LoopType.Restart);
	}*/
}
