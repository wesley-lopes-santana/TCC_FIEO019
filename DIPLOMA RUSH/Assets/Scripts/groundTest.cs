using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundTest : MonoBehaviour
{   

    private GameController  _GameController;

    private Rigidbody2D     GroundTestRb;
    private Animator        GroundTestAnimator;

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

    public IEnumerator     rotinaGroundTestAnda;

    // Start is called before the first frame update
    void Start()
    {   

        alvo = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        _GameController = FindObjectOfType(typeof(GameController)) as GameController;

        GroundTestRb = GetComponent<Rigidbody2D>();
        GroundTestAnimator = GetComponent<Animator>();

        // rotinaGroundTestAnda = GroundTestAnda();
        StartCoroutine("GroundTestAnda");
    }

    // Update is called once per frame
    void Update()
    {   
        
        GroundTestRb.velocity = new Vector2(lados * velocidade, GroundTestRb.velocity.y);
        
        if((lados > 0 && estaOlhandoEsquerda == true) || (lados < 0 && estaOlhandoEsquerda == false) )
        {
            Gira();
        }

        if(lados != 0)
        {
            GroundTestAnimator.SetBool("andando", true);
        }else
        {
            GroundTestAnimator.SetBool("andando", false);
        }   
    }


    void OnTriggerEnter2D(Collider2D col){

        if(col.gameObject.tag == "hitBox")
        {
            _GameController.playSFX(_GameController.sfxEnemyDead, 0.32f);
            GroundTestAnimator.SetTrigger("morto");
            Destroy(HitBox);
        }else if(col.gameObject.tag == "BarraInimigo")
        {
            if(lados == -1){
                lados = 1;
            }else if(lados == 1){
                lados = -1;
            }
        }
        else if(col.gameObject.tag == "Player")
        {   
            StopCoroutine("GroundTestSegue");
            StartCoroutine("GroundTestSegue");
        }
    }

    void OnTriggerExit2D(Collider2D col) {
        if(col.gameObject.tag == "Player")
        {   
            StopCoroutine("GroundTestSegue");
            StartCoroutine("GroundTestAnda");
        }
    }

    IEnumerator GroundTestAnda()
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
        StartCoroutine("GroundTestAnda");
    }
    



    IEnumerator GroundTestSegue()
    {   
        
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(alvo.position.x, transform.position.y), velocidade2 * Time.deltaTime);

        if (transform.position.x > alvo.position.x) {
            GiraEsquerda();
        } else {
            GiraDireita();
        }
        lados = 0;
        yield return null;

        StopCoroutine("GroundTestAnda");
        StartCoroutine("GroundTestSegue");
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
        GroundTestAnimator.SetBool("andando", true);
        estaOlhandoEsquerda = false;
        float x = System.Math.Abs(transform.localScale.x) * -1 ; //Inverte o sinal do Transform -> Scale -> X
        transform.localScale = new Vector3(x, transform.localScale.y, transform.localScale.z);
    }
    void GiraEsquerda()
    {   
        GroundTestAnimator.SetBool("andando", true);
        estaOlhandoEsquerda = true;
        float x = System.Math.Abs(transform.localScale.x); //Inverte o sinal do Transform -> Scale -> X
        transform.localScale = new Vector3(x, transform.localScale.y, transform.localScale.z);
    }

    //void GroundTestSegue()
    //{
    //   transform.position = Vector2.MoveTowards(transform.position, new Vector2(alvo.position.x, transform.position.y), velocidade * Time.deltaTime);
    //}
}
