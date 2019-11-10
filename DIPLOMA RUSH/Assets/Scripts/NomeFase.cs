using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NomeFase : MonoBehaviour
{   
    private float     contador = 0;
    public  GameObject Fase;
    // Start is called before the first frame update
    void Start()
    {
        Fase.SetActive(true);
        StartCoroutine("tiraTexto");
    }

    // Update is called once per frame
    void Update()
    {   

    }
    
    IEnumerator tiraTexto(){
        contador += 1;
        if(contador == 5){
            Fase.SetActive(false);
            StopCoroutine("tiraTexto");
        }
        yield return new WaitForSeconds(1);
        StartCoroutine("tiraTexto");
    }
}
