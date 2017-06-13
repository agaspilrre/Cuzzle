using UnityEngine;
using System.Collections;

public class moverFicha : MonoBehaviour {

    bool permitido = false;

    public float v_rotacion = 150.0F;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


        if (permitido)
        {
            transform.Rotate(0,0, Input.GetAxis("Horizontal") * v_rotacion * Time.deltaTime, Space.World);

            //transform.Rotate(Input.GetAxis("Vertical") * v_rotacion * Time.deltaTime, 0, 0, Space.World);

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
