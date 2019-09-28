using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slimeIAMesmo : MonoBehaviour
{   

    private GameController  _GameController;

    private Rigidbody2D     slimeRb;
    private Animator        slimeAnimator;

    public  float           velocidade;
    public  float           timeToWalk;

    public  GameObject      HitBox;

    private int             lados;

    public  bool            estaOlhandoEsquerda;

    public  float           velocidade2;
    public GameObject       viuplayer;
   //public  Transform       achouPlayer;
    private bool            viuOPlayer;
    private Transform       alvo;

    public IEnumerator     rotinaSlimeAnda;

    // Start is called before the first frame update
    void Start()
    {   

        alvo = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        _GameController = FindObjectOfType(typeof(GameController)) as GameController;

        slimeRb = GetComponent<Rigidbody2D>();
        slimeAnimator = GetComponent<Animator>();

        // rotinaSlimeAnda = SlimeWalk();
        StartCoroutine("SlimeWalk");
    }

    // Update is called once per frame
    void Update()
    {   
        
        slimeRb.velocity = new Vector2(lados * velocidade, slimeRb.velocity.y);
        
        if((lados > 0 && estaOlhandoEsquerda == true) || (lados < 0 && estaOlhandoEsquerda == false) )
        {
            Gira();
        }

        if(lados != 0)
        {
            slimeAnimator.SetBool("andando", true);
        }else
        {
            slimeAnimator.SetBool("andando", false);
        }   
    }


    void OnTriggerEnter2D(Collider2D col){

        if(col.gameObject.tag == "hitBox")
        {
            _GameController.playSFX(_GameController.sfxEnemyDead, 0.32f);
            slimeAnimator.SetTrigger("morto");
            Destroy(HitBox);
        }
        // else if(col.gameObject.tag == "Player")
        // {   
        //     //StopCoroutine("SlimeWalk");
        //     // print(rotinaSlimeAnda);
        //     StopCoroutine("seguePlayer");
        //     StartCoroutine("seguePlayer");
        //     Destroy(viuplayer);
        // }
    }

    IEnumerator SlimeWalk()
    {
        int rand = Random.Range(0,100);

        if (rand < 33)
        {
            lados = -1;
        }
        else if(rand < 66)
        {
            lados = 0;
        }else
        {
            lados = 1;
        }


        yield return new WaitForSeconds(timeToWalk);
        StartCoroutine("SlimeWalk");
    }
    
    IEnumerator seguePlayer()
    {   
        
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(alvo.position.x, transform.position.y), velocidade2 * Time.deltaTime);

        if (transform.position.x > alvo.position.x) {
            GiraEsquerda();
        } else {
            GiraDireita();
        }
        lados = 0;
        yield return null;

        StopCoroutine("SlimeWalk");
        StartCoroutine("seguePlayer");
    }


    void OnDead()
    {
        Destroy(this.gameObject);
    }

    void Gira()
    {
        estaOlhandoEsquerda = !estaOlhandoEsquerda;
        float x = transform.localScale.x * -1; //Inverte o sinal do Transform -> Scale -> X
        transform.localScale = new Vector3(x, transform.localScale.y, transform.localScale.z);
    }
    void GiraDireita()
    {   
        slimeAnimator.SetBool("andando", true);
        estaOlhandoEsquerda = false;
        float x = System.Math.Abs(transform.localScale.x) * -1 ; //Inverte o sinal do Transform -> Scale -> X
        transform.localScale = new Vector3(x, transform.localScale.y, transform.localScale.z);
    }
    void GiraEsquerda()
    {   
        slimeAnimator.SetBool("andando", true);
        estaOlhandoEsquerda = true;
        float x = System.Math.Abs(transform.localScale.x); //Inverte o sinal do Transform -> Scale -> X
        transform.localScale = new Vector3(x, transform.localScale.y, transform.localScale.z);
    }

    //void seguePlayer()
    //{
    //   transform.position = Vector2.MoveTowards(transform.position, new Vector2(alvo.position.x, transform.position.y), velocidade * Time.deltaTime);
    //}
}
