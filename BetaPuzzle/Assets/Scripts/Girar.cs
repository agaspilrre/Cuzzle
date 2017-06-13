using UnityEngine;
using System.Collections;

public class Girar : MonoBehaviour
{

    // Use this for initialization

    public Transform prueba;

    public float v_rotacion = 98.24F;

    bool permitido = true;

    float timeTransition = 0.45F;

    float currentTime = 0;

    bool girando = false;

    int posicionGiro;

    int[] rotacion;

    public Variables v1;

    Quaternion quat = Quaternion.Euler(90, 0, 0);

    void Start()
    {
        //calcular();

        rotacion = new int[3];

        for (int i = 0; i < 2; i++)
            rotacion[i] = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (girando == true)
        {
            giro();
        }

        if (permitido == true)
        {
            if (Input.GetKey("w"))
            {
                quat = Quaternion.Euler(90, 0, 0);
                rotacion[0] += 90;
                girando = true;
                permitido = false;
                posicionGiro = 1;
                v1.setPermitir(false);
            }
            if (Input.GetKey("a"))
            {
                quat = Quaternion.Euler(0, 90, 0);
                rotacion[1] += 90;
                girando = true;
                permitido = false;
                posicionGiro = 2;
                v1.setPermitir(false);
            }
            if (Input.GetKey("s"))
            {
                quat = Quaternion.Euler(-90, 0, 0);
                rotacion[0] += -90;
                girando = true;
                permitido = false;
                posicionGiro = 3;
                v1.setPermitir(false);
            }
            if (Input.GetKey("d"))
            {
                quat = Quaternion.Euler(0, -90, 0);
                rotacion[1] += -90;
                girando = true;
                permitido = false;
                posicionGiro = 4;
                v1.setPermitir(false);
            }

        }

    }

    public void SetPermitido(bool variable)
    {
        permitido = variable;
    }

    public void giro()
    {

        if (posicionGiro == 1)
        {
            transform.Rotate(Vector3.right, v_rotacion * Time.deltaTime, Space.World);
        }
        if (posicionGiro == 2)
        {
            transform.Rotate(Vector3.up, v_rotacion * Time.deltaTime, Space.World);
        }
        if (posicionGiro == 3)
        {
            transform.Rotate(Vector3.left, v_rotacion * Time.deltaTime, Space.World);
        }
        if (posicionGiro == 4)
        {
            transform.Rotate(Vector3.down, v_rotacion * Time.deltaTime, Space.World);
        }

        currentTime += Time.deltaTime;

        if (currentTime >= timeTransition)
        {
            girando = false;

            //transform.rotation = Quaternion.Euler(rotacion[0], rotacion[1], 0);

            transform.rotation = prueba.rotation;

            permitido = true;

            v1.setPermitir(true);

            currentTime = 0;
        }
    }

    public void calcular()//esta funcion no calcula el tiempo exacto
    {
        v_rotacion = Quaternion.Angle(transform.rotation, quat) / timeTransition;
    }

    public bool getGirar()
    {
        return girando;
    }

}
