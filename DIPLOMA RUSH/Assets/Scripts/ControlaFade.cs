using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlaFade : MonoBehaviour
{   
    public static ControlaFade Instance{set;get;}

    public Image    imagem;
    private bool    estaEmTransicao;
    private float   transicao;
    private bool    estaMostrando;
    private float   duracao;

    private void Acorda(){

        Instance = this;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
