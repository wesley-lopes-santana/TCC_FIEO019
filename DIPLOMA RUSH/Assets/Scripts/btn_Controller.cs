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

    
    void Update()
    {
		if(clickini == true){
			Application.LoadLevel("Fase 1-1");
		}
		
		if(clickopc == true){
			Application.LoadLevel("Opções");
		}
		
		if(clickcre == true){
			Application.LoadLevel("SampleScene");
		}
		if(clickVolta == true){
			Application.LoadLevel("Menu");
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
}
