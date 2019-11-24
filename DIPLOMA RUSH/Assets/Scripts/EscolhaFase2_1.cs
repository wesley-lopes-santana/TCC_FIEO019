using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscolhaFase2_1 : MonoBehaviour
{
    private bool                clickOpc1;
	private bool                clickOpc2;
	private bool                clickOpc3;
    public  GameObject          _Escolha;

    // Start is called before the first frame update
    void Start()
    {
        _Escolha = GameObject.FindGameObjectWithTag("Escolha");
        
    }

    // Update is called once per frame
    void Update()
    {
        if(clickOpc1 == true){
			Time.timeScale = 1;
            if(PlayerController.maxHp <- 2 ){
				PlayerController.maxHp = 3;
			}
            _Escolha.SetActive(false);
		}
		else if(clickOpc2 == true){
			Time.timeScale = 1;
            _Escolha.SetActive(false);
		}
		else if(clickOpc3 == true){
			Time.timeScale = 1;
			SceneManager.LoadScene(0);
            _Escolha.SetActive(false);
		}
    }



    public void clickOpcao1(bool click){
		clickOpc1 = true;
	}
	public void clickOpcao2(bool click){
		clickOpc2 = true;
	}
	public void clickOpcao3(bool click){
		clickOpc3 = true;
	}
}
