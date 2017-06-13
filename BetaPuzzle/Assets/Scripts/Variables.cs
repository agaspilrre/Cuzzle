using UnityEngine;
using System.Collections;

public class Variables : MonoBehaviour {

    // Use this for initialization

    public static bool permitir;

	void Start () {

	    permitir = true;
	}

    public bool getPermitir()
    {
        return permitir;
    }

    public void setPermitir(bool variable)
    {
        permitir = variable;
    }
}
