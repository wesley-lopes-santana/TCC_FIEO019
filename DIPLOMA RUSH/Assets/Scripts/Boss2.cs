using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss2 : MonoBehaviour
{
    public  GameObject[]    ProxPosicao;
    private Transform       alvo;
    private Rigidbody2D     slimeRb;
    private Animator        slimeAnimator;
    public  GameObject      HitBox;
    public  float           rateSpawn;
    public  GameObject      Tiro;
    private Vector3         destino;
    public static Transform   boss2_local;
    

    public float velocidade;
    public bool estaOlhandoEsquerda;
    private GameController  _GameController;
    private  Teleporte       _GameControllerTeleporte;

    private int contador = 0;
    private int vidaChefe = 3;


    // Start is called before the first frame update
    void Start()
    {
        boss2_local = this.GetComponent<Transform>();
        _GameController = FindObjectOfType(typeof(GameController)) as GameController;
        _GameControllerTeleporte = FindObjectOfType(typeof(Teleporte)) as Teleporte;
        alvo = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        slimeRb = GetComponent<Rigidbody2D>();
        slimeAnimator = GetComponent<Animator>();
        StartCoroutine("mexeChefe");
        StartCoroutine("Atirando");
        StartCoroutine("girachefe");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, ProxPosicao[contador].transform.position, velocidade * Time.deltaTime);
        StartCoroutine("mexeChefe");

        // if (transform.position.x > alvo.position.x && transform.localScale.x < 0){
        //     Gira();
        // }else if(transform.position.x < alvo.position.x && transform.localScale.x > 0){
        //     Gira();
        // }
        
        
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "hitBox")
        {
            _GameController.playSFX(_GameController.sfxEnemyDead, 0.32f);
            vidaChefe -= 1;
            if (vidaChefe == 2){
                gameObject.GetComponent<SpriteRenderer> ().color = new Color(0.887f, 0.506f, 0.517f, 1.000f);
                velocidade = 2.5f;
            }
            if (vidaChefe == 1){
                gameObject.GetComponent<SpriteRenderer> ().color = new Color(0.868f, 0.225f, 0.245f, 1.000f);
                velocidade = 3.5f;
            }
            if (vidaChefe == 0){
                SceneManager.LoadScene(2);
                Destroy(HitBox);
                gameObject.SetActive(false) ;
            }
            if (vidaChefe == 0){
                SceneManager.LoadScene(2);
                Destroy(HitBox);
                gameObject.SetActive(false) ;
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

    IEnumerator Atirando(){
        GameObject tempPrefab = Instantiate(Tiro) as GameObject;
        Destroy(tempPrefab, 2f);
        yield return new WaitForSeconds(2);
        StartCoroutine("Atirando");
    }

    IEnumerator Pausachefe(){
        velocidade = 0.25f;

        yield return new WaitForSeconds(1.5f);
        if (vidaChefe == 2){
            velocidade = 2.5f;
        }
        if (vidaChefe == 1){
            velocidade = 3.5f;
        }
    }

    void Gira()
    {
        float x = transform.localScale.x * -1; //Inverte o sinal do Transform -> Scale -> X
        transform.localScale = new Vector3(x, transform.localScale.y, transform.localScale.z);
    }

    IEnumerator girachefe(){
        if (transform.position.x > alvo.position.x && transform.localScale.x < 0){
            Gira();
        }else if(transform.position.x < alvo.position.x && transform.localScale.x > 0){
            Gira();
        }
        yield return new WaitForSeconds(2.5f);
        StartCoroutine("girachefe");
    }
}

