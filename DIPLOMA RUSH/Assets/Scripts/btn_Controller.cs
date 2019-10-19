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
	private bool clickcre;
	private bool clickVolta;
	private bool clickVolOpc;
	private bool clickCon;

    
    void Update()
    {
		if(clickini == true){
			SceneManager.LoadScene("Fase 1-1");
		}
		
		if(clickopc == true){
			SceneManager.LoadScene("Opções");
		}
		
		if(clickcre == true){
			SceneManager.LoadScene("Creditos");
		}
		if(clickVolta == true){
			SceneManager.LoadScene("Menu");
		}
		if(clickVolOpc == true){
			SceneManager.LoadScene("Opções");
		}
		if(clickCon == true){
			SceneManager.LoadScene("Controles");
		}
        
    }
	
	public void Click_ini(bool click){
		clickini = true;
	}
	public void Click_opc(bool click){
		clickopc = true;
	}
	public void Click_cre(bool click){
		clickcre = true;
	}
	public void Click_vol(bool click){
		clickVolta = true;
	}
	public void Click_volOpc(bool click){
		clickVolOpc = true;
	}
	public void Click_Con(bool click){
		clickCon = true;
	}
}
