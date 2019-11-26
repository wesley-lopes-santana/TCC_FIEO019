using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ContaColetaveis : MonoBehaviour
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
        texto.text = "0" + (Mathf.Round(PlayerController.itens).ToString());
    }

}