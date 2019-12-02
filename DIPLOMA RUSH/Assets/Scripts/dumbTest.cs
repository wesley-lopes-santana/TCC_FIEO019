using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dumbTest : MonoBehaviour
{   
    private GameController  _GameController;
    private Rigidbody2D     DumbTestRb;
    private Animator        DumbTesteAnimator;

    public  float           velocidade;
    public  float           timeToWalk;

    public  GameObject      HitBox;

    private int             lados;

    public  bool            estaOlhandoEsquerda;
    // Start is called before the first frame update
    void Start()
    {
        _GameController = FindObjectOfType(typeof(GameController)) as GameController;

        DumbTestRb = GetComponent<Rigidbody2D>();
        DumbTesteAnimator = GetComponent<Animator>();

        StartCoroutine("DumbTestAnda");
    }

    // Update is called once per frame
    void Update()
    {   
        
        DumbTestRb.velocity = new Vector2(lados * velocidade, DumbTestRb.velocity.y);

        if((lados > 0 && estaOlhandoEsquerda == true) || (lados < 0 && estaOlhandoEsquerda == false) )
        {
            Gira();
        }

        if(lados != 0)
        {
            DumbTesteAnimator.SetBool("andando", true);
        }else
        {
            DumbTesteAnimator.SetBool("andando", false);
        }

    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "hitBox")
        {   
            lados = 0;
            Destroy(HitBox);
            _GameController.playSFX(_GameController.sfxEnemyDead, 0.32f);
            DumbTesteAnimator.SetTrigger("morto");
        }else if(col.gameObject.tag == "BarraInimigo")
        {
            if(lados == -1){
                lados = 1;
            }else if(lados == 1){
                lados = -1;
            }
        }
    }
    

    IEnumerator DumbTestAnda()
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
        StartCoroutine("DumbTestAnda");
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

}
