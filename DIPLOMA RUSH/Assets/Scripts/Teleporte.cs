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
    private Teleporte       _GameControllerTeleporte;

    // Start is called before the first frame update
    void Start()
    {
        PassouFase.passou = false;

        _GameController = FindObjectOfType(typeof(GameController)) as GameController;
        _GameControllerTeleporte = FindObjectOfType(typeof(Teleporte)) as Teleporte;
        if (ProximaFase == 6){
            minimoMoedas = 30;
            minimoItens = 0;
        }else if(ProximaFase == 7){
            minimoMoedas = 30;
            minimoItens = 2;
        }else if(ProximaFase == 8){
            minimoMoedas = 30;
            minimoItens = 2;
        }else if(ProximaFase == 10){
            minimoMoedas = 30;
            minimoItens = 2;
        }else if(ProximaFase == 11){
            minimoMoedas = 30;
            minimoItens = 2;
        }else if(ProximaFase == 12){
            minimoMoedas = 30;
            minimoItens = 2;
        }else if(ProximaFase == 13){
            minimoMoedas = 30;
            minimoItens = 2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(PassouFase.passou == true){
            StartCoroutine("Transicao_Fases");
        }
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player"){
            if(ProximaFase == 5){
                StartCoroutine("Transicao");
            }
            else if(PlayerController.itens == minimoItens){
                _PassouFase.SetActive(true);
                _PassouPelasMoedas.SetActive(false);
                Time.timeScale = 0;
            }else if(PlayerController.moedas >= minimoMoedas){                
                PlayerController.moedas = PlayerController.moedas - minimoMoedas;
                PassaValores.moedas = PlayerController.moedas;
                _PassouFase.SetActive(true);
                _PassouPelosColetaveis.SetActive(false);
                Time.timeScale = 0;
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

    IEnumerator Transicao(){
        ControlaFade.Fade(true, 2f);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(_GameControllerTeleporte.ProximaFase);
    }

    public IEnumerator Transicao_Fases(){
        Time.timeScale = 1;
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene(_GameControllerTeleporte.ProximaFase);  
    }
}
