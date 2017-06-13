using UnityEngine;
using System.Collections;

public class Puntero : MonoBehaviour {

    // Use this for initialization
    public CambiarColor scrpt1;

    bool permitido = false;

   public bool []caraCorrecta =new bool[6];

    public string nombre;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (permitido)
        {
            if (Input.GetMouseButton(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                //Hace tranza una linea desde el lugar la camara hasta la poscion del raton.
                if (Physics.Raycast(ray, out hit, 100, LayerMask.GetMask("Punteros")))
                {
                    if (hit.rigidbody != null && hit.collider.name == "lado1" && nombre == "lado1")
                    {
                        scrpt1 = GameObject.Find("lado1").GetComponent<CambiarColor>();

                        scrpt1.MaterialCambiado();
                        caraCorrecta[0] = true;
                    }
                    if (hit.rigidbody != null && hit.collider.name == "lado2" && nombre == "lado2")
                    {
                        scrpt1 = GameObject.Find("lado2").GetComponent<CambiarColor>();

                        scrpt1.MaterialCambiado();
                        caraCorrecta[1] = true;
                    }
                    if (hit.rigidbody != null && hit.collider.name == "lado3" && nombre == "lado3")
                    {
                        scrpt1 = GameObject.Find("lado3").GetComponent<CambiarColor>();

                        scrpt1.MaterialCambiado();
                        caraCorrecta[2] = true;
                    }
                    if (hit.rigidbody != null && hit.collider.name == "lado4" && nombre == "lado4")
                    {
                        scrpt1 = GameObject.Find("lado4").GetComponent<CambiarColor>();

                        scrpt1.MaterialCambiado();
                        caraCorrecta[3] = true;
                    }
                    if (hit.rigidbody != null && hit.collider.name == "lado5" && nombre == "lado5")
                    {
                        scrpt1 = GameObject.Find("lado5").GetComponent<CambiarColor>();

                        scrpt1.MaterialCambiado();

                        caraCorrecta[4] = true;
                    }
                    if (hit.rigidbody != null && hit.collider.name == "lado6" && nombre == "lado6")
                    {
                        scrpt1 = GameObject.Find("lado6").GetComponent<CambiarColor>();

                        scrpt1.MaterialCambiado();
                        caraCorrecta[5] = true;
                    }
                }
            }
        }
    }

    public void SetPermitido(bool variable)
    {
        permitido = variable;
    }
    public void setNombre(string variable)
    {
        nombre = variable;
    }
}
