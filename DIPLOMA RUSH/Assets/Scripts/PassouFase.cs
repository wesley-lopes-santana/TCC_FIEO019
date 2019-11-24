using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PassouFase : MonoBehaviour
{   
    private     bool                clickOpc1;
    private     Teleporte           _GameControllerTeleporte;
    public      GameObject          _PassouFase;   
    public     static bool          passou = false; 

    // Start is called before the first frame update
    void Start()
    {
        passou = false;
        _GameControllerTeleporte = FindObjectOfType(typeof(Teleporte)) as Teleporte;
    }

    // Update is called once per frame
    void Update()
    {
        if(clickOpc1 == true){
            StartCoroutine ("Transicao");
		}
        
    }


    public void clickOpcao1(bool click){
		clickOpc1 = true;
	}

    
    public  IEnumerator Transicao(){
        Time.timeScale = 1;
        ControlaFade.Fade(true, 2f);
        passou = true;
        _PassouFase.SetActive(false);
        yield return new WaitForSeconds(1.0f);

    }
}