using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

using System.Collections;


public class retrocederMontaje : MonoBehaviour {


    public GameObject[] Grandes=new GameObject[6];

    //LISTA DONDE SE AÑADEN LAS PIEZAS QUE YA HAN SIDO MONTADAS

    private List <GameObject> piezasMontadas = new List <GameObject>();

    private List<Component> arrayScripts = new List<Component>();
    

    private acopleFinal1 af1;
    private acopleFinal2 af2;
    private acopleFinal3 af3;
    private acopleFinal4 af4;
    private acopleFinal5 af5;
    private acopleFinal6 af6;

    bool permitirRetroceso=true;

    public GameObject Canvas;


	// Use this for initialization
	void Awake () {

       af1= Grandes[0].GetComponent<acopleFinal1>();
       af2=Grandes[1].GetComponent<acopleFinal2>();
       af3= Grandes[2].GetComponent<acopleFinal3>();
        af4=Grandes[3].GetComponent<acopleFinal4>();
        af5=Grandes[4].GetComponent<acopleFinal5>();
        af6=Grandes[5].GetComponent<acopleFinal6>();

        arrayScripts.Add(af1);
        arrayScripts.Add(af2);
        arrayScripts.Add(af3);
        arrayScripts.Add(af4);
        arrayScripts.Add(af5);
        arrayScripts.Add(af6);

        Canvas.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {


        if (Input.GetKeyDown(KeyCode.X) && piezasMontadas.Count>0)
        {
            for(int i = 0; i < Grandes.Length; i++)
            {
                if (Grandes[i].GetComponent<moverFicha>().getPermitido())
                {
                    permitirRetroceso = false;
                }
            }

            if (permitirRetroceso)
            {
                retrocede();
                Debug.Log(piezasMontadas.Count);
            }

           permitirRetroceso=true;
        }




        




        if (piezasMontadas.Count == 6)
        {
            Debug.Log("ENHORABUENA HAS GANADO");
            Canvas.SetActive(true);//activa el canvas de ganador
            Invoke("reiniciarPartida",4);

        }

    }

   public void Añadirpieza(GameObject objeto)
    {

        piezasMontadas.Add(objeto);
        Debug.Log(piezasMontadas[0]);


    }

    public void QuitarPieza(GameObject objeto)
    {
        piezasMontadas.Remove(objeto);


        
    }

    public void retrocede()
    {

        Debug.Log("retrocede");
        for(int i = 0; i < piezasMontadas.Count; i++)
        {
            Debug.Log("soy i y valgo: "+i);
            if (i == piezasMontadas.Count-1)
            {

                if (piezasMontadas[i].gameObject.tag == "Grande1")
                {
                    af1.CancelarAccion();
                    QuitarPieza(piezasMontadas[i]);
                }

                else if(piezasMontadas[i].gameObject.tag == "Grande2")
                {
                    af2.CancelarAccion();
                    QuitarPieza(piezasMontadas[i]);
                }

                else if (piezasMontadas[i].gameObject.tag == "Grande3")
                {
                    af3.CancelarAccion();
                    QuitarPieza(piezasMontadas[i]);
                }

                else if (piezasMontadas[i].gameObject.tag == "Grande4")
                {
                    af4.CancelarAccion();
                    QuitarPieza(piezasMontadas[i]);
                }

                else if (piezasMontadas[i].gameObject.tag == "Grande5")
                {
                    af5.CancelarAccion();
                    QuitarPieza(piezasMontadas[i]);
                }

                else 
                {
                    af6.CancelarAccion();
                    QuitarPieza(piezasMontadas[i]);
                }






            }
        }
    }


    void reiniciarPartida()
    {
        
        SceneManager.LoadScene("NFacil");
    }


 





}
