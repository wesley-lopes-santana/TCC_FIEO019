using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss2 : MonoBehaviour
{
    public  GameObject[]    ProxPosicao;
    private Transform       alvo;
    private Animator        boss2Animator;
    public  GameObject      HitBox;
    public  float           rateSpawn;
    public  GameObject      Tiro;
    private Vector3         destino;
    public static Transform boss2_local;
    public static bool      passouUltimoBoss;
    

    public float velocidade;
    public bool estaOlhandoEsquerda;
    private GameController  _GameController;
    private  Teleporte       _GameControllerTeleporte;

    private int contador = 0;
    private int vidaChefe = 8;
    // private int de_costas;


    // Start is called before the first frame update
    void Start()
    {
        boss2_local = this.GetComponent<Transform>();
        _GameController = FindObjectOfType(typeof(GameController)) as GameController;
        _GameControllerTeleporte = FindObjectOfType(typeof(Teleporte)) as Teleporte;
        alvo = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        boss2Animator = GetComponent<Animator>();
        StartCoroutine("mexeChefe");
        StartCoroutine("Atirando");
        StartCoroutine("girachefe");
    }

    // Update is called once per frame
    void Update()
    {
        if(vidaChefe >= 1){
            transform.position = Vector3.MoveTowards(transform.position, ProxPosicao[contador].transform.position, velocidade * Time.deltaTime);
            StartCoroutine("mexeChefe");
        }
        // if (alvo.position.x < boss2_local.position.x && boss2_local.localScale.x > 1){
        //     de_costas = 0;
        // }else if(alvo.position.x < boss2_local.position.x && boss2_local.localScale.x < 1){
        //     de_costas = 1;
        // }else if(alvo.position.x > boss2_local.position.x && boss2_local.localScale.x < 1){
        //     de_costas = 0;
        // }else if(alvo.position.x > boss2_local.position.x && boss2_local.localScale.x > 1){
        //     de_costas = 1;
        // }

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
            StartCoroutine("Pausachefe");
            if (vidaChefe <= 6 && vidaChefe >= 4){
                gameObject.GetComponent<SpriteRenderer> ().color = new Color(0.887f, 0.506f, 0.517f, 1.000f);
                velocidade = 2.0f;
                StartCoroutine("Pausachefe");
            }
            if (vidaChefe <= 4 && vidaChefe >= 2){
                gameObject.GetComponent<SpriteRenderer> ().color = new Color(0.868f, 0.225f, 0.245f, 1.000f);
                velocidade = 2.5f;
                StartCoroutine("Pausachefe");
            }
            if (vidaChefe == 3){
                boss2Animator.SetTrigger("reiniciando");
                StartCoroutine("Pausachefe");
            }
            if (vidaChefe == 1){
                gameObject.GetComponent<SpriteRenderer> ().color = new Color(0.868f, 0.225f, 0.245f, 1.000f);
                velocidade = 3.0f;
                StartCoroutine("Pausachefe");
            }
            if (vidaChefe <= 0){
                StopCoroutine("Atirando");
                boss2Animator.SetTrigger("morto");
                Destroy(HitBox);
                // gameObject.SetActive(false);
                
                velocidade = 0;
                StartCoroutine("matouChefe");
            }            
        }
    }

    IEnumerator mexeChefe(){
        if (transform.position != ProxPosicao[contador].transform.position){

        }else{
            contador = Random.Range(0,5);
        }
        
        yield return new WaitForSeconds(1);
    }

    IEnumerator Atirando(){
        // if(de_costas == 0){
        GameObject tempPrefab = Instantiate(Tiro) as GameObject;
        Destroy(tempPrefab, 2f);
        // }
        
        yield return new WaitForSeconds(2.5f);
        StartCoroutine("Atirando");
    }

    IEnumerator Pausachefe(){
        if(vidaChefe >= 2){
            boss2Animator.SetTrigger("hit");
        }
        velocidade = 0.25f;
        if(vidaChefe == 3){
            velocidade = 0.0f;
            StopCoroutine("Atirando");
            yield return new WaitForSeconds(3.0f);
            StartCoroutine("Atirando");
        }else{
            yield return new WaitForSeconds(1.5f);
        }
        velocidade = 1.5f;
        if (vidaChefe <= 6 && vidaChefe >= 4){
            velocidade = 2.0f;
        }
        if (vidaChefe <= 4 && vidaChefe >= 2){
            velocidade = 2.5f;
        }
        if (vidaChefe == 1){
            velocidade = 3.0f;
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

    IEnumerator matouChefe(){
        yield return new WaitForSeconds(3.0f);
        gameObject.SetActive(false);
        passouUltimoBoss = true;
        ControlaFade.Fade(true, 2f);
        PassouFase.passou = true;
    }
}

