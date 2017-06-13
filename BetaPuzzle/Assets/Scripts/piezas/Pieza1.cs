using UnityEngine;
using System.Collections;

public class Pieza1 : MonoBehaviour {

    public Material inicial;
    public Material trasparente;
    public Material verdeTrans;
    public bool usado = false;
    public moverFicha scrpt;
    public Girar scrpt2;
    public Selector scrpt3;
    bool permitido;
    public Puntero scrpt4;
    public Variables scrpt5;
    GameObject Pieza;
    public string nombre = "lado1";

    CambiarColor scrpt6;

    bool acertada;



    // Use this for initialization
    void Start () {

        GetComponent<MeshRenderer>().material = inicial;

        scrpt = GameObject.Find("Grande1").GetComponent<moverFicha>();

        scrpt2 = GameObject.Find("Cubo").GetComponent<Girar>();

        scrpt3 = GameObject.Find("Selector").GetComponent<Selector>();

        scrpt4 = GameObject.Find("Selector").GetComponent<Puntero>();

        scrpt5 = GameObject.Find("Main Camera").GetComponent<Variables>();

        Pieza = GameObject.Find("Grande1");

         scrpt6 = GameObject.Find("lado1").GetComponent<CambiarColor>();//Hecho por Luis

        Pieza.SetActive(false);

        acertada= false;

        
       
        
    }

    


    


   

	
    void OnMouseDown()
    {
        if (acertada == false)
        {

            if (usado == false && scrpt5.getPermitir())
            {
                GetComponent<MeshRenderer>().material = trasparente;
                usado = true;
                //permite movimiento
                scrpt.SetPermitido(true);
                scrpt2.SetPermitido(false);
                scrpt3.SetPermitido(false);
                scrpt4.SetPermitido(true);
                scrpt4.setNombre(nombre);
                scrpt5.setPermitir(false);

                Pieza.SetActive(true);

            }
            else if (usado == true)
            {
                GetComponent<MeshRenderer>().material = inicial;
                usado = false;
                //permite movimiento
                scrpt.SetPermitido(false);
                scrpt2.SetPermitido(true);
                scrpt3.SetPermitido(true);
                scrpt4.SetPermitido(false);
                scrpt4.setNombre("");
                scrpt5.setPermitir(true);

                Pieza.SetActive(false);
                scrpt6.retornarCambio();
            }
        }
       
    }

    public void Acertado()
    {
        GetComponent<MeshRenderer>().material = verdeTrans;
    }



    public void SetAcertado(bool variable)
    {
        acertada = variable;
    }


}
