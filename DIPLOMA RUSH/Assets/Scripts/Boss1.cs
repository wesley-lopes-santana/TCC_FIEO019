using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss1 : MonoBehaviour
{
    public GameObject[] ProxPosicao;
    private Transform       alvo;
    public  GameObject      HitBox;
    public static Transform   boss1_local;
    private Animator        boss1Animator;

    public float velocidade;
    public bool estaOlhandoEsquerda;
    private GameController  _GameController;
    private  Teleporte       _GameControllerTeleporte;

    public static int contador = 0;
    private int vidaChefe = 10;


    // Start is called before the first frame update
    void Start()
    {
        boss1Animator = GetComponent<Animator>();
        _GameController = FindObjectOfType(typeof(GameController)) as GameController;
        _GameControllerTeleporte = FindObjectOfType(typeof(Teleporte)) as Teleporte;
        alvo = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        boss1_local = this.GetComponent<Transform>();
        
        StartCoroutine("mexeChefe");
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
            if(alvo.position.x < boss1_local.position.x && boss1_local.localScale.x < 1){
                vidaChefe -= 1;
            }else if(alvo.position.x > boss1_local.position.x && boss1_local.localScale.x > 1){
                vidaChefe -= 1;
            }
            vidaChefe -= 1;

            StartCoroutine("Pausachefe");

            if (vidaChefe <= 6 && vidaChefe >= 3){
                gameObject.GetComponent<SpriteRenderer> ().color = new Color(0.887f, 0.506f, 0.517f, 1.000f);
                velocidade = 2.0f;
            }
            if (vidaChefe <= 3 && vidaChefe >= 1){
                gameObject.GetComponent<SpriteRenderer> ().color = new Color(0.868f, 0.225f, 0.245f, 1.000f);
                velocidade = 2.5f;
            }
            if (vidaChefe == 1){
                gameObject.GetComponent<SpriteRenderer> ().color = new Color(0.868f, 0.225f, 0.245f, 1.000f);
                velocidade = 2.8f;
            }
            if (vidaChefe <= 0){
                Destroy(HitBox);
                velocidade = 0;
                boss1Animator.SetTrigger("morto");
                StartCoroutine("matouChefe");
                
            }
            
        }
    }

    IEnumerator mexeChefe(){
        
        if (transform.position != ProxPosicao[contador].transform.position){

        }else{
            Boss1.contador = Random.Range(0,5);
        }
        
        yield return new WaitForSeconds(1);
    }

    void Gira()
    {
        float x = transform.localScale.x * -1; //Inverte o sinal do Transform -> Scale -> X
        transform.localScale = new Vector3(x, transform.localScale.y, transform.localScale.z);
    }

    IEnumerator Pausachefe(){
        velocidade = 0.25f;
        yield return new WaitForSeconds(1.5f);
        velocidade = 1.5f;
        if (vidaChefe <= 6 && vidaChefe >= 3){
            velocidade = 2.0f;
        }
        if (vidaChefe <= 3 && vidaChefe >= 1){
            velocidade = 2.5f;
        }
        if (vidaChefe == 1){
            velocidade = 2.8f;
        }
        
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

    IEnumerator matouChefe(){
        
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
        ControlaFade.Fade(true, 2f);
        PassouFase.passou = true;
    }

}

