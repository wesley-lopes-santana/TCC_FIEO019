using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausa : MonoBehaviour
{   
    private bool                clickOpc1;
	private bool                clickOpc2;
	private bool                clickPause;
    public  GameObject          _Pausa;
	public  GameObject          _Pause;
	public  GameObject			PauseText;
	public  GameObject		    CoracoesMauro;
	public  GameObject			Moedas;
	public  GameObject			Coletaveis;
	public  GameObject			Contador;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {   
        if (Input.GetButtonDown("Pausa") ||  clickPause == true ){
            Time.timeScale = 0;
			clickPause = false;
            _Pausa.SetActive(true);
			_Pause.SetActive(false);
			PauseText.SetActive(false);
			CoracoesMauro.SetActive(false);
			Moedas.SetActive(false);
			Coletaveis.SetActive(false);
			Contador.SetActive(false);
		}
        if(clickOpc1 == true){
            Time.timeScale = 1;
            clickOpc1 = false;
			clickPause = false;
			_Pause.SetActive(true);
            _Pausa.SetActive(false);
			PauseText.SetActive(true);
			CoracoesMauro.SetActive(true);
			Moedas.SetActive(true);
			Coletaveis.SetActive(true);
			Contador.SetActive(true);
		}
		else if(clickOpc2 == true){
            Time.timeScale = 1;
            _Pausa.SetActive(false);
            clickOpc2 = false;
            SceneManager.LoadScene(0);
		}
	
	}

    public void clickOpcao1(bool click){
		clickOpc1 = true;
	}
	public void clickOpcao2(bool click){
		clickOpc2 = true;
	}
	public void clickPausa(bool click){
		clickPause = true;
	}
}

