using UnityEngine;
using System.Collections;

public class CambiarColor : MonoBehaviour {

    public Material rojo;
    public Material verde;

    void Start () {

        GetComponent<MeshRenderer>().material = rojo;

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void MaterialCambiado()
    {
        GetComponent<MeshRenderer>().material = verde;
    }

   //FUNCION LUIS EN EL SCRIPT DE MARIO
    public void retornarCambio()
   {
      GetComponent<MeshRenderer>().material = rojo;

   }


}
