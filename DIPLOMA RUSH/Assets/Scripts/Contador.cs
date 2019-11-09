using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Contador : MonoBehaviour
{
    public      float           tempoInicial;
    private     Text            texto;
    private     Teleporte       _GameControllerTeleporte;
    public     GameObject      _FimJogo;
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
            Time.timeScale = 0;
            _FimJogo.SetActive(true);
            PlayerController.moedas = 0;
        }
    }

}
