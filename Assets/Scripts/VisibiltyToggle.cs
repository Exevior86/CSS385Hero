using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibiltyToggle : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.H))
        {
            GetComponent<Renderer>().enabled = !GetComponent<Renderer>().enabled;
        }
    }
}
