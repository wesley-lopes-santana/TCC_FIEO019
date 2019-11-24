using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlaFade : MonoBehaviour
{   
    public static ControlaFade Instance{set;get;}

    public Image    imagem;
    private static bool    estaEmTransicao;
    private static float   transicao;
    private static bool    estaMostrando;
    private static float   duracao;

    private void Acorda(){

        Instance = this;

    }

    public static void Fade(bool mostrando, float duracao){
        estaMostrando = mostrando;
        estaEmTransicao = true;
        ControlaFade.duracao = duracao;
        transicao = (estaMostrando) ? 0 : 1;
    }

    private void Update()
    {   
        if(!estaEmTransicao){
            return;
        }
        transicao += (estaMostrando) ? Time.deltaTime * (1/duracao) : -Time.deltaTime * (1/duracao);
        imagem.color = Color.Lerp(new Color(0,0,0,0), Color.black, transicao);

        if (transicao > 1 || transicao < 0){
            estaEmTransicao = false;
        }
        
    }
}
