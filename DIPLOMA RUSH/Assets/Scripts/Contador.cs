using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Contador : MonoBehaviour
{
    public  float       tempoInicial;
    private Text        texto;
    private  Teleporte       _GameControllerTeleporte;
    // Start is called before the first frame update
    void Start()
    {
        texto = GetComponent<Text>();
        _GameControllerTeleporte = FindObjectOfType(typeof(Teleporte)) as Teleporte;
    }

    // Update is called once per frame
    void Update()
    {
        tempoInicial -= Time.deltaTime;
        texto.text = "" + (Mathf.Round(tempoInicial).ToString());
        if(int.Parse(texto.text) == 0){
            SceneManager.LoadScene(_GameControllerTeleporte.ProximaFase-1);
            PlayerController.moedas = 0;
        }
    }

}
