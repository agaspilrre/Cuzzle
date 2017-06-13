using UnityEngine;
using System.Collections;

public class pieza4 : MonoBehaviour {


    public Material inicial;
    public Material trasparente;
    public Material verdeTrans;
    bool usado = false;
    public moverFicha scrpt;
    public Girar scrpt2;
    public Selector scrpt3;
    public Puntero scrpt4;
    public Variables scrpt5;
    GameObject Pieza;
    public string nombre = "lado4";

   CambiarColor scrpt6;

    bool acertada;
    // Use this for initialization
    void Start()
    {

        GetComponent<MeshRenderer>().material = inicial;

        scrpt = GameObject.Find("Grande4").GetComponent<moverFicha>();

        scrpt2 = GameObject.Find("Cubo").GetComponent<Girar>();

        scrpt3 = GameObject.Find("Selector").GetComponent<Selector>();

        scrpt4 = GameObject.Find("Selector").GetComponent<Puntero>();

        scrpt5 = GameObject.Find("Main Camera").GetComponent<Variables>();

        Pieza = GameObject.Find("Grande4");

        Pieza.SetActive(false);

        acertada = false;

        scrpt6 = GameObject.Find("lado4").GetComponent<CambiarColor>();

    }


    void OnMouseDown()
    {
        if (acertada==false)
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
                scrpt5.setPermitir(true);
                scrpt2.SetPermitido(true);
                scrpt3.SetPermitido(true);
                scrpt4.SetPermitido(false);
                scrpt4.setNombre("");

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
