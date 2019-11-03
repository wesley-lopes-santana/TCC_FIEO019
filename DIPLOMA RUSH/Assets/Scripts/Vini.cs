using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vini : MonoBehaviour
{   
    private bool                clickOpc1;
	private bool                clickOpc2;
    public  GameObject          _Escolha_Vini;
    public  GameObject          _Vini;

    // Start is called before the first frame update
    void Start()
    {
        _Escolha_Vini = GameObject.FindGameObjectWithTag("Escolha_Vini");
        _Vini = GameObject.FindGameObjectWithTag("Vini");
    }

    // Update is called once per frame
    void Update()
    {
        if(clickOpc1 == true){
            PlayerController.maxHp = PlayerController.maxHp + 1;
            Time.timeScale = 1;
            _Escolha_Vini.SetActive(false);
            Destroy(_Vini);
		}
		else if(clickOpc2 == true){
            PlayerController.moedas = PlayerController.moedas + 1;
            print(PlayerController.moedas);
            Time.timeScale = 1;
            _Escolha_Vini.SetActive(false);
            Destroy(_Vini);
		}
    }


    public void clickOpcao1(bool click){
		clickOpc1 = true;
	}
	public void clickOpcao2(bool click){
		clickOpc2 = true;
	}
}
