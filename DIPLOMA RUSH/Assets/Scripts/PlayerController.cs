using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public  GameController   _GameController;
    private slimeIAMesmo     _SlimeIAMesmo;

    private Rigidbody2D         PlayerRb;
    private Animator            PlayerAnimator;
    private SpriteRenderer      PlayerSr;

    public  float               velocidade;
    public  float               forcaPulo;

    public  bool                estaOlhandoEsquerda;
    public  Transform           GroundCheck;
    private bool                estaNoChao;
    private bool                morreu;

    private bool                estaAtacando;
    public  Transform           mao;   
    public  GameObject          hitBoxPreFab;

    public  Color               hitColor;
    public  Color               noHitColor;

    public  int                 maxHp;
    public  int                 moedas = 0;

    // Start is called before the first frame update
    void Start()
    {
        PlayerRb = GetComponent<Rigidbody2D>();
        PlayerAnimator = GetComponent<Animator>();
        PlayerSr = GetComponent<SpriteRenderer>();

        _GameController = FindObjectOfType(typeof(GameController)) as GameController;
        _GameController.playerTransform = this.transform;

        _SlimeIAMesmo = FindObjectOfType(typeof(slimeIAMesmo)) as slimeIAMesmo;

    }

    // Update is called once per frame
    void Update()
    {   
        //MOVIMENTO DO PERSONAGEM ESQUERDA NEGATIVO DIREITA POSITIVO
        //
        float lados = Input.GetAxisRaw("Horizontal");

        if (estaAtacando == true && estaNoChao == true)
        {
            lados = 0;
        }

        if((lados > 0 && estaOlhandoEsquerda == true) || (lados < 0 && estaOlhandoEsquerda == false) )
        {
            Gira();
        }

        float velocidadeY = PlayerRb.velocity.y;

        if (Input.GetButtonDown("Jump") && estaNoChao == true)
        {   
            _GameController.playSFX(_GameController.sfxJump, 0.3f);
            PlayerRb.AddForce(new Vector2(0, forcaPulo));
        }

        if(Input.GetButtonDown("Fire1"))
        {   
            _GameController.playSFX(_GameController.sfxAtack, 0.3f);
            estaAtacando = true;
            PlayerAnimator.SetTrigger("ataque");
        }


        PlayerRb.velocity = new Vector2(lados*velocidade ,velocidadeY);



        PlayerAnimator.SetInteger("lados", (int) lados);
        PlayerAnimator.SetBool("estaNoChao", estaNoChao);
        PlayerAnimator.SetFloat("velocidadeY", velocidadeY);
        PlayerAnimator.SetBool("estaAtacando", estaAtacando);
        PlayerAnimator.SetBool("morreu", morreu);
    }


    //void FixedUpdate(){
    //    estaNoChao = Physics2D.OverlapCircle(GroundCheck.position, 0.02f);
    //}

    void OnTriggerEnter2D(Collider2D colider) {
        if(colider.gameObject.tag == "Coletavel")
        {
            _GameController.playSFX(_GameController.sfxCoin, 0.5f);
            moedas += 1;
            Destroy(colider.gameObject);
        }
        else if(colider.gameObject.tag == "damage")
        {
            print("THAT A LOT OF DAMAGE");
            StartCoroutine("damageController");
        }
        else if(colider.gameObject.tag == "viu player")
        {   
            _SlimeIAMesmo.StopCoroutine("seguePlayer");
            _SlimeIAMesmo.StartCoroutine("seguePlayer");
        }
        
    }

    void OnCollisionEnter2D(Collision2D colider) {
        if(colider.gameObject.tag == "ground")
        {   
            estaNoChao = true;
        }
    }

    void OnCollisionExit2D(Collision2D colider) {
        if(colider.gameObject.tag == "ground")
        {   
            estaNoChao = false;
        }
    }

    void OnTriggerExit2D(Collider2D colider2) {
        if(colider2.gameObject.tag == "viu player")
        {   
            print("saas");
            _SlimeIAMesmo.StopCoroutine("seguePlayer");
            _SlimeIAMesmo.StartCoroutine("SlimeWalk");
        }
    }


    //FUNÇÕES CRIADAS POR MIM
    void Gira()
    {
        estaOlhandoEsquerda = !estaOlhandoEsquerda;
        float x = transform.localScale.x * -1; //Inverte o sinal do Transform -> Scale -> X
        transform.localScale = new Vector3(x, transform.localScale.y, transform.localScale.z);
    }

    void NoFimAtaque()
    {
        estaAtacando = false;
    }

    void hitBoxAtaque()
    {
        GameObject hitBoxTemp = Instantiate(hitBoxPreFab, mao.position, transform.localRotation);
        Destroy(hitBoxTemp, 0.4f);
    }

    void footStep()
    {
        _GameController.playSFX(_GameController.sfxStep[Random.Range(0, _GameController.sfxStep.Length)], 0.8f);
    }

    IEnumerator damageController()
    {   
        _GameController.playSFX(_GameController.sfxDamage, 0.5f);

        maxHp -= 1;
        if(maxHp <= 0)
        {   
            morreu = true;
            //Destroy(gameObject,3.2f);
            StartCoroutine("TempoParaMorte");
            //Time.timeScale = 0;
        }

        this.gameObject.layer = LayerMask.NameToLayer("Invencivel");
        PlayerSr.color = hitColor;
        yield return new WaitForSeconds(0.25f);
        PlayerSr.color = noHitColor;

        for(int i = 0; i < 5; i++)
        {
            PlayerSr.enabled = false;
            yield return new WaitForSeconds(0.2f);
            PlayerSr.enabled = true;
            yield return new WaitForSeconds(0.2f);
        }

        PlayerSr.color = Color.white;

        this.gameObject.layer = LayerMask.NameToLayer("Player");

    }

    IEnumerator TempoParaMorte(){
        estaAtacando = true;
        yield return new WaitForSeconds(3f);
        Time.timeScale = 0;

 
     }
}


