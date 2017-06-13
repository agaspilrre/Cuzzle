using UnityEngine;
using System.Collections;

public class acopleFinal4 : MonoBehaviour
{
    public bool pegado;//variable luis
    public GameObject caraCubo;
    Vector3 posicion;
    public bool definirPosicion;
    public bool cerrar;
    public bool CaraOk;
    public float speed;
    float spet;

    public bool detect;

    Rigidbody rb;

    GameObject puntero;

    GameObject inhabilitarPieza;
    GameObject habilitarCubo;

    public Material rojo;
    public Material verde;


    Quaternion rotacionRetorno;
    Vector3 posicionRetorno;

    GameObject padreRetorno;

    public GameObject[] colliders = new GameObject[5];//CAMBIA EN CADA SCRIPT
    GameObject GuardoPiezaAcoplada;



    // Use this for initialization
    void Start()
    {

        caraCubo = GameObject.Find("cubol4");//CAMBIA EN CADA SCRIPT
        puntero = GameObject.Find("Selector");
        rb = GetComponent<Rigidbody>();

        GuardoPiezaAcoplada = GameObject.Find("GameManager");

        //guarda la posicion original de la pieza
        rotacionRetorno = this.transform.rotation;
        posicionRetorno = this.transform.position;
        Debug.Log(posicionRetorno);
        Debug.Log(rotacionRetorno);


    }

    // Update is called once per frame
    void Update()
    {

        CaraOk = puntero.GetComponent<Puntero>().caraCorrecta[3];//para que la pieza solo pueda ponerse en su cara correspondiente        //CAMBIA EN CADA SCRIPT


        if (definirPosicion)
        {


            this.transform.position = caraCubo.transform.position;//esto es para una vez que esta la pieza pegada al cubo si rotamos el cubo la pieza lo siga
            //this.transform.rotation = caraCubo.transform.rotation;//ROTA LA PIEZA SI LA CARA ESTA INCLINADA

            this.transform.parent = caraCubo.transform;//para que la pieza adquiera el mismo movimiento que el cubo hace que se mueva como un hijo de la cara del cubo
        }

        //recordar q si la cara del selector no esta seleccionada no entrara en esta funcion
        if (Input.GetKeyDown(KeyCode.Space) && !cerrar && CaraOk)
        {
            Debug.Log("hola");

            posicion = this.transform.position;

            //spet = speed * Time.deltaTime;
            //this.transform.position = Vector3.Lerp(this.transform.position, caraCubo.transform.position, spet);
            //Vector3 movimiento = (caraCubo.transform.position - this.transform.position).normalized * spet;
            //rb.velocity = movimiento;
            this.transform.position = caraCubo.transform.position;

            GetComponent<moverFicha>().SetPermitido(false);//CORRECION DE BUG ROTACION D EPIEZA AL ACOPLAR
            //NUEVO
            StartCoroutine(comprobarColisiones());


        }


        /*
        if (Input.GetKeyDown(KeyCode.X) && cerrar)
        {
            CancelarAccion();
        }
        */




    }


    IEnumerator comprobarColisiones()
    {
        yield return new WaitForSeconds(0.1f);

        bool comprobador;
        for (int i = 0; i < colliders.Length; i++)
        {
            comprobador = colliders[i].GetComponent<Colisionadores>().getDetectCollision();
            if (comprobador)
            {

                detect = true;


            }
        }

        Debug.Log(detect);
        if (!detect)
        {
            pegado = true;
        }

        else
        {
            pegado = false;
            //provisional
            GetComponent<MeshRenderer>().material = rojo;

        }





        StartCoroutine(piezaReturn());
    }





    IEnumerator piezaReturn()
    {
        yield return new WaitForSeconds(2);

        if (pegado)
        {
            definirPosicion = true;

            GetComponent<moverFicha>().SetPermitido(false);//para que ya no podamos girar la ficha acoplada
            habilitarCubo = GameObject.Find("Cubo");
            habilitarCubo.GetComponent<Girar>().SetPermitido(true);//podemos mover el cubo de nuevo

            inhabilitarPieza = GameObject.Find("pieza4");   //CAMBIA EN CADA SCRIPT!!!
            inhabilitarPieza.SetActive(false);//desactivo la pieza pequeña porque ya esta acoplada

            cerrar = true;//si la pieza ha sio encajada correctamente ya no nos permite ejecutar este if a traves del booleano, es para que la pieza no se despegue

            puntero.GetComponent<Puntero>().caraCorrecta[3] = false; //CAMBIA EN CADA SCRIPT !!!!
            puntero.GetComponent<Selector>().SetPermitido(true);

            for (int i = 0; i < colliders.Length; i++)
            {
                colliders[i].GetComponent<Colisionadores>().Disable();
            }
            //desactivo los triger para que se convierta la pieza ya pegada en mayas de colision para que otros triger de otras piezas las puedan detectar

            GuardoPiezaAcoplada.GetComponent<retrocederMontaje>().Añadirpieza(this.gameObject);
        }

        else
        {
            this.transform.position = posicion;
            GetComponent<moverFicha>().SetPermitido(true);//CORRECION DE BUG ROTACION D EPIEZA AL ACOPLAR
            //devolvemos la ficha al centro de la pantalla si esta ha sido mal colocada, lo hacemos en courutina para que el usuario tenga tiempo de visualizar la pieza
            //provisional
            GetComponent<MeshRenderer>().material = verde;

            for (int i = 0; i < colliders.Length; i++)
            {
                colliders[i].GetComponent<Colisionadores>().setDetectorCollision(false);


            }//pongo las detecciones a false en caso de que la pieza no haya sido acoplada para una nueva comprobacion

            detect = false;
        }

    }


    public void CancelarAccion()
    {
        for (int i = 0; i < colliders.Length; i++)
        {
            colliders[i].GetComponent<Colisionadores>().Enable();


        }

        definirPosicion = false;



        puntero.GetComponent<Selector>().SetPermitido(false);

        padreRetorno = GameObject.Find("GRANDES");
        this.transform.parent = padreRetorno.transform;
        this.transform.position = posicionRetorno;//para que la pieza no se nos descuadre al cancelar la accion
        this.transform.rotation = rotacionRetorno;

        GetComponent<moverFicha>().SetPermitido(true);//para que ya no podamos girar la ficha acoplada

        habilitarCubo.GetComponent<Girar>().SetPermitido(false);//podemos mover el cubo de nuevo

        Debug.Log(inhabilitarPieza);

        inhabilitarPieza.SetActive(true);//desactivo la pieza pequeña porque ya esta acoplada

        cerrar = false;
    }

}
