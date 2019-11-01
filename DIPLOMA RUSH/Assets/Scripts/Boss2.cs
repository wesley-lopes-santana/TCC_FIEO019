using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss2 : MonoBehaviour
{
    public GameObject[] ProxPosicao;
    private Transform       alvo;
    private Rigidbody2D     slimeRb;
    private Animator        slimeAnimator;
    public  GameObject      HitBox;
    

    public float velocidade;
    public bool estaOlhandoEsquerda;
    private GameController  _GameController;
    private  Teleporte       _GameControllerTeleporte;

    private int contador = 0;
    private int vidaChefe = 5;


    // Start is called before the first frame update
    void Start()
    {
        _GameController = FindObjectOfType(typeof(GameController)) as GameController;
        _GameControllerTeleporte = FindObjectOfType(typeof(Teleporte)) as Teleporte;
        alvo = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        slimeRb = GetComponent<Rigidbody2D>();
        slimeAnimator = GetComponent<Animator>();
        StartCoroutine("mexeChefe");
        
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, ProxPosicao[contador].transform.position, velocidade * Time.deltaTime);
        StartCoroutine("mexeChefe");

        if (transform.position.x > alvo.position.x && transform.localScale.x < 0){
            Gira();
        }else if(transform.position.x < alvo.position.x && transform.localScale.x > 0){
            Gira();
        }

    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "hitBox")
        {
            
            _GameController.playSFX(_GameController.sfxEnemyDead, 0.32f);
            vidaChefe -= 1;
            if (vidaChefe == 0){
                Destroy(HitBox);
                gameObject.SetActive(false) ;
                SceneManager.LoadScene(_GameControllerTeleporte.ProximaFase);
            }
            
        }
    }

    IEnumerator mexeChefe(){
        if (transform.position != ProxPosicao[contador].transform.position){

        }else{
            if (contador == 5){
                contador = 0;
            }else{
                contador = contador + 1;
            }
        }
        
        yield return new WaitForSeconds(1);
    }

    void Gira()
    {
        float x = transform.localScale.x * -1; //Inverte o sinal do Transform -> Scale -> X
        transform.localScale = new Vector3(x, transform.localScale.y, transform.localScale.z);
    }
}

