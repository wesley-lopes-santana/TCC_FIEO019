using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{   
    private bool                clickOpc1;
	private bool                clickOpc2;
    public  GameObject          _FimJogo;
    private  Teleporte       _GameControllerTeleporte;

    // Start is called before the first frame update
    void Start()
    {
        _GameControllerTeleporte = FindObjectOfType(typeof(Teleporte)) as Teleporte;
    }

    // Update is called once per frame
    void Update()
    {
        if(clickOpc1 == true){
            Time.timeScale = 1;
            _FimJogo.SetActive(false);
            SceneManager.LoadScene(_GameControllerTeleporte.ProximaFase-1);
		}
		else if(clickOpc2 == true){
            Time.timeScale = 1;
            _FimJogo.SetActive(false);
            SceneManager.LoadScene(0);
		}
    }


    public void clickOpcao1(bool click){
		clickOpc1 = true;
	}
	public void clickOpcao2(bool click){
		clickOpc2 = true;
	}
}

