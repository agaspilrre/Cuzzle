using UnityEngine;
using System.Collections;

public class prueba : MonoBehaviour {



    Collider myCollider;

	// Use this for initialization
	void Start () {

        myCollider = GetComponent<Collider>();
        myCollider.isTrigger = true;
	
	}
	
	// Update is called once per frame
	void Update () {


        if (myCollider.isTrigger)
        {
            StartCoroutine("changeTrigger");
        }
	
	}




    IEnumerator changeTrigger()
    {

        yield return new WaitForSeconds(8);

        myCollider.isTrigger = false;



    }







}
