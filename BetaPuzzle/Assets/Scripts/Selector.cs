using UnityEngine;
using System.Collections;

public class Selector : MonoBehaviour
{

    public float v_rotacion = 200.0F;

    bool permitido = true;

    bool segundoPerm = true;

    public float timeLeft = 0;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (permitido && segundoPerm)
        {
            /*
               transform.Rotate(0, Input.GetAxis("Horizontal") * v_rotacion * Time.deltaTime, 0, Space.World);

               transform.Rotate(Input.GetAxis("Vertical") * v_rotacion * Time.deltaTime, 0, 0, Space.World);

      */

            if (Input.GetKey("w"))
            {
                transform.Rotate(90, 0, 0, Space.World);

                segundoPerm = false;
            }
            if (Input.GetKey("a"))
            {
                transform.Rotate(0, 90, 0, Space.World);

                segundoPerm = false;
            }
            if (Input.GetKey("s"))
            {
                transform.Rotate(-90, 0, 0, Space.World);

                segundoPerm = false;
            }
            if (Input.GetKey("d"))
            {
                transform.Rotate(0, -90, 0, Space.World);

                segundoPerm = false;
            }

        }
        else
        {
            timeLeft += Time.deltaTime;
        }

        if (timeLeft >= 0.45F)
        {
            segundoPerm = true;

            timeLeft = 0;
        }
    }

    public void SetPermitido(bool variable)
    {
        permitido = variable;
    }


    public bool getPermitido()
    {
        return permitido;
    }

}