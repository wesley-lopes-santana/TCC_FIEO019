using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscolhaFase1_2 : MonoBehaviour
{
    private bool                clickOpc1;
	private bool                clickOpc2;
    public  GameObject          _Escolha;
    public  GameObject[]        _Todos_GameObjects;
    public static string[] lista_tag = new string[9] {"hitBox","Coletavel","ground","plataformaMeche","Buraco",
                                            "Escolha1_2","Player","Untagged", "BarraInimigo"};

    // Start is called before the first frame update
    void Start()
    {
        _Escolha = GameObject.FindGameObjectWithTag("Escolha");
        
    }

    // Update is called once per frame
    void Update()
    {
        if(clickOpc1 == true){
            int i = 0;
            Time.timeScale = 1;
            foreach(string tipo in lista_tag){
                foreach(GameObject gameObj in GameObject.FindGameObjectsWithTag(lista_tag[i]))
                {
                    gameObj.GetComponent<Renderer>().material.color = new Color(+ .79f, + .79f, + .79f, .9f);

                }
                i++;
            }
            PassaValores.cor_mapa = 2;
            _Escolha.SetActive(false);
		}
		else if(clickOpc2 == true){
            int i = 0;
            Time.timeScale = 1;
            foreach(string tipo in lista_tag){
                foreach(GameObject gameObj in GameObject.FindGameObjectsWithTag(lista_tag[i]))
                {
                    gameObj.GetComponent<Renderer>().material.color = new Color(+ 1.1f, + 1.1f, + 1.1f, 1f);

                }
                i++;
            }
            PassaValores.cor_mapa = 1;
            _Escolha.SetActive(false);
		}
    }



    public void clickOpcao1(bool click){
		clickOpc1 = true;
	}
	public void clickOpcao2(bool click){
		clickOpc2 = true;
	}
}
