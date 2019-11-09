using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PassouFase : MonoBehaviour
{   
    private     bool                clickOpc1;
    private     Teleporte           _GameControllerTeleporte;
    public      GameObject          _PassouFase;      

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
            _PassouFase.SetActive(false);
            SceneManager.LoadScene(_GameControllerTeleporte.ProximaFase);
		}
    }


    public void clickOpcao1(bool click){
		clickOpc1 = true;
	}
}