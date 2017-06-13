using UnityEngine;
using System.Collections;

public class acoplarFicha2 : MonoBehaviour
{


    public bool pegado = true;//variable luis
    public GameObject caraCubo;
    Vector3 posicion;
    public bool definirPosicion;
    public bool cerrar;
    public bool CaraOk;
    public float speed;
    float spet;

    Rigidbody rb;

    GameObject puntero;

    GameObject inhabilitarPieza;
    GameObject habilitarCubo;

    public Material rojo;
    public Material verde;

    public float MrMinRotacion;
    public float MrMaxRotacion;

    Quaternion rotacionRetorno;
    Vector3 posicionRetorno;

    GameObject padreRetorno;



    // Use this for initialization
    void Start()
    {

        caraCubo = GameObject.Find("cubol2");
        puntero = GameObject.Find("Selector");
        rb = GetComponent<Rigidbody>();

      rotacionRetorno = this.transform.rotation;
      posicionRetorno = this.transform.position;



   }

    // Update is called once per frame
    void Update()
    {

        CaraOk = puntero.GetComponent<Puntero>().caraCorrecta[1];//para que la pieza solo pueda ponerse en su cara correspondiente


        if (definirPosicion)
        {


            this.transform.position = caraCubo.transform.position;//esto es para una vez que esta la pieza pegada al cubo si rotamos el cubo la pieza lo siga
            //this.transform.rotation = caraCubo.transform.rotation;//ROTA LA PIEZA SI LA CARA ESTA INCLINADA

            this.transform.parent = caraCubo.transform;//para que la pieza adquiera el mismo movimiento que el cubo hace que se mueva como un hijo de la cara del cubo
        }

        //recordar q si la cara del selector no esta seleccionada no entrara en esta funcion
        if (Input.GetKeyDown(KeyCode.Space) && !cerrar && CaraOk)
        {
            
            posicion = this.transform.position;

            //spet = speed * Time.deltaTime;
            //this.transform.position = Vector3.Lerp(this.transform.position, caraCubo.transform.position, spet);
            //Vector3 movimiento = (caraCubo.transform.position - this.transform.position).normalized * spet;
            //rb.velocity = movimiento;
            this.transform.position = caraCubo.transform.position;

            

            if (this.transform.rotation.eulerAngles.x > MrMinRotacion && this.transform.rotation.eulerAngles.x < MrMaxRotacion)
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


        
        if (Input.GetKeyDown(KeyCode.X) && cerrar)
        {
            CancelarAccion();
        }
        



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

            inhabilitarPieza = GameObject.Find("pieza2");
            inhabilitarPieza.SetActive(false);//desactivo la pieza pequeña porque ya esta acoplada

            cerrar = true;//si la pieza ha sio encajada correctamente ya no nos permite ejecutar este if a traves del booleano, es para que la pieza no se despegue

             puntero.GetComponent<Puntero>().caraCorrecta[1]=false;//para el selector y que no se quede abierto lo de pegar la pieza
            puntero.GetComponent<Selector>().SetPermitido(true);

        }

        else
        {
            this.transform.position = posicion;
            //devolvemos la ficha al centro de la pantalla si esta ha sido mal colocada, lo hacemos en courutina para que el usuario tenga tiempo de visualizar la pieza
            //provisional
            GetComponent<MeshRenderer>().material = verde;
        }

    }

   void CancelarAccion()
   {


      definirPosicion = false;



      puntero.GetComponent<Selector>().SetPermitido(false);

      padreRetorno = GameObject.Find("GRANDES");
      this.transform.parent = padreRetorno.transform;
      this.transform.position = posicionRetorno;//para que la pieza no se nos descuadre al cancelar la accion
      this.transform.rotation = rotacionRetorno;

      GetComponent<moverFicha>().SetPermitido(true);//para que ya no podamos girar la ficha acoplada

      habilitarCubo.GetComponent<Girar>().SetPermitido(false);//podemos mover el cubo de nuevo

      

      inhabilitarPieza.SetActive(true);//desactivo la pieza pequeña porque ya esta acoplada

      cerrar = false;

      //NUEVO
      puntero.GetComponent<Puntero>().caraCorrecta[1] = false;


   }






}