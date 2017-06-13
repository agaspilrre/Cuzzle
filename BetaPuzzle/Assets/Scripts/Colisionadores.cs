using UnityEngine;
using System.Collections;

public class Colisionadores : MonoBehaviour {



    
    
    private bool detectorColisiones;
    Collider col;
    

	// Use this for initialization
	void Awake () {

        col = GetComponent<Collider>();
        col.isTrigger = true;
       
       

	}
	
	


    void OnTriggerEnter(Collider other)
    {

        Debug.Log("he amigo ha abido una colision");
        detectorColisiones = true;



    }


    public void Enable()
    {
        col.isTrigger = true;
    }

    public void Disable()
    {
        col.isTrigger = false;
    }

    public bool getDetectCollision()
    {
        return detectorColisiones;
    }

    public void setDetectorCollision(bool i_value)
    {
        detectorColisiones = i_value;
    }






}
