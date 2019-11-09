using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporte : MonoBehaviour
{
    private GameController  _GameController;
    public  int             ProximaFase = 4;
    public  static int      minimoMoedas;
    public  static int      minimoItens;
    public  GameObject      _FaltaMoedaOuItens;
    public  GameObject      _PassouFase;
    public  GameObject      _PassouPelasMoedas;
    public  GameObject      _PassouPelosColetaveis;

    // Start is called before the first frame update
    void Start()
    {
        _GameController = FindObjectOfType(typeof(GameController)) as GameController;
        if (ProximaFase == 6){
            minimoMoedas = 30;
            minimoItens = 3;
        }else if(ProximaFase == 7){
            minimoMoedas = 30;
            minimoItens = 1;
        }else if(ProximaFase == 8){
            minimoMoedas = 30;
            minimoItens = 2;
        }else if(ProximaFase == 10){
            minimoMoedas = 30;
            minimoItens = 2;
        }else if(ProximaFase == 11){
            minimoMoedas = 30;
            minimoItens = 1;
        }else if(ProximaFase == 12){
            minimoMoedas = 30;
            minimoItens = 2;
        }else if(ProximaFase == 13){
            minimoMoedas = 30;
            minimoItens = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player"){
            if(PlayerController.itens == minimoItens){
                Time.timeScale = 0;
                _PassouFase.SetActive(true);
                _PassouPelasMoedas.SetActive(false);
            }else if(PlayerController.moedas >= minimoMoedas){
                Time.timeScale = 0;
                PlayerController.moedas = PlayerController.moedas - minimoMoedas;
                PassaValores.moedas = PlayerController.moedas;
                _PassouFase.SetActive(true);
                _PassouPelosColetaveis.SetActive(false);
            }else{
                _FaltaMoedaOuItens.SetActive(true);
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player"){
            _FaltaMoedaOuItens.SetActive(false);
        }
        
    }
}
