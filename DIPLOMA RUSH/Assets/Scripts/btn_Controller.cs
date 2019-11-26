using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class btn_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
	// Update is called once per frame
	private bool clickini;
	private bool clickopc;
	private bool clicksai;
	private bool clickVolta;
	private bool clickVolOpc;
	private bool clickCre;
	private bool clicksSom;
	private bool clickcSom;

    
    void Update()
    {
		if(clickini == true){
			SceneManager.LoadScene("Fase 1-1");
		}
		
		if(clickopc == true){
			SceneManager.LoadScene("Opções");
		}
		
		if(clicksai == true){
			Application.Quit();
		}
		if(clickVolta == true){
			SceneManager.LoadScene("Menu");
		}
		if(clickVolOpc == true){
			SceneManager.LoadScene("Opções");
		}
		if(clickCre == true){
			SceneManager.LoadScene("Creditos");
		}
	
    }
	
	public void Click_ini(bool click){
		clickini = true;
	}
	public void Click_opc(bool click){
		clickopc = true;
	}
	public void Click_sair(bool click){
		clicksai = true;
	}
	public void Click_vol(bool click){
		clickVolta = true;
	}
	public void Click_volOpc(bool click){
		clickVolOpc = true;
	}
	public void Click_Cre(bool click){
		clickCre = true;
	}
	public void Click_sSom(bool click){
		clicksSom = true;
	}
	public void Click_CSom(bool click){
		clickcSom = true;
	}
}