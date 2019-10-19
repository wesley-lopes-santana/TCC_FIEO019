using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
			Application.LoadLevel("Fase 1-1");
		}
		
		if(clickopc == true){
			Application.LoadLevel("Opções");
		}
		
		if(clickcre == true){
			Application.LoadLevel("Creditos");
		}
		if(clickVolta == true){
			Application.LoadLevel("Menu");
		}
		if(clickVolOpc == true){
			Application.LoadLevel("Opções");
		}
		if(clickCon == true){
			Application.LoadLevel("Controles");
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
