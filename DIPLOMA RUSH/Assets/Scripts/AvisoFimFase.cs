using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AvisoFimFase : MonoBehaviour
{
    private Text        texto;
    
    // Start is called before the first frame update
    void Start()
    {
        texto = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        texto.text = $"Você só possui {PlayerController.moedas} moedas e {PlayerController.itens} itens,"+
        $"mas é necessario {Teleporte.minimoMoedas} moedas ou os {Teleporte.minimoItens}  itens escondidos"+
        "CORRA AINDA PODE DAR TEMPO!!!!";
    }

}