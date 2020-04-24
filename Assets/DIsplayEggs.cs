using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DIsplayEggs : MonoBehaviour
{
    public Text eggs;
    private int eggos;

    private void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        eggos = GameObject.FindGameObjectsWithTag("Egg").Length;
        eggos--;
        eggs.text = eggos.ToString();
    }
}
