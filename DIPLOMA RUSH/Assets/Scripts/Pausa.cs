using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausa : MonoBehaviour
{   
    private bool                clickOpc1;
	private bool                clickOpc2;
    public  GameObject          _Pausa;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        if (Input.GetButtonDown("Pausa")){
            Time.timeScale = 0;
            _Pausa.SetActive(true);
        }
        if(clickOpc1 == true){
            Time.timeScale = 1;
            clickOpc1 = false;
            _Pausa.SetActive(false);
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
}

