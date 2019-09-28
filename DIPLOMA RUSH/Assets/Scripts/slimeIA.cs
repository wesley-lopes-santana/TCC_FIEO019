using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slimeIA : MonoBehaviour
{   

    private GameController  _GameController;
    private Rigidbody2D     slimeRb;
    private Animator        slimeAnimator;

    public  float           velocidade;
    public  float           timeToWalk;

    public  GameObject      HitBox;

    private int             lados;

    public  bool            estaOlhandoEsquerda;
    // Start is called before the first frame update
    void Start()
    {
        _GameController = FindObjectOfType(typeof(GameController)) as GameController;

        slimeRb = GetComponent<Rigidbody2D>();
        slimeAnimator = GetComponent<Animator>();

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
            Destroy(HitBox);
            _GameController.playSFX(_GameController.sfxEnemyDead, 0.32f);
            slimeAnimator.SetTrigger("morto");
        }
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
