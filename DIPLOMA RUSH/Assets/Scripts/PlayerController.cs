using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    public LayerMask            groundLayer;
    public  GameController      _GameController;
    private slimeIAMesmo        _SlimeIAMesmo;
    public  GameObject          _Escolha;
    public  GameObject          _Escolha_Vini;

    private Rigidbody2D         PlayerRb;
    private Animator            PlayerAnimator;
    private SpriteRenderer      PlayerSr;

    public  float               velocidade;
    public  float               forcaPulo;
    private float               forcaPuloEscada;
    public float                gravidadeInicial;
    public bool                 ganhouPulo = false;
    public bool puloExtra;
    public  bool                estaOlhandoEsquerda;
    public  Transform           GroundCheck;    
    private bool                estaNoChao;
    private bool                morreu;
    public bool                 estaNaEscada;
    

    private bool                estaAtacando;
    public  Transform           mao;   
    public  GameObject          hitBoxPreFab;

    public  Color               hitColor;
    public  Color               noHitColor;

    public  static int                 maxHp = 3;
    public  static int                 moedas = 0;
    public  static int                 itens = 0;
	
	public int saude;
	public int numCor;
	
	public Image[] coracoes;
	public Sprite coracaoCheio;
	public Sprite coracaoVazio;

    public Transform            TransformPlayer;

    private Teleporte      _GameControllerTeleporte;
    // Start is called before the first frame update
    void Start()
    {   
        groundLayer = LayerMask.GetMask("Default");
        PlayerRb = GetComponent<Rigidbody2D>();
        PlayerAnimator = GetComponent<Animator>();
        PlayerSr = GetComponent<SpriteRenderer>();

        _GameControllerTeleporte = FindObjectOfType(typeof(Teleporte)) as Teleporte;
        _GameController = FindObjectOfType(typeof(GameController)) as GameController;
        _GameController.playerTransform = this.transform;

        _SlimeIAMesmo = FindObjectOfType(typeof(slimeIAMesmo)) as slimeIAMesmo;

        itens = 0;
        gravidadeInicial = PlayerRb.gravityScale;
        ganhouPulo = false;
        forcaPulo = 320;
        if(PassaValores.hp != 0){
            maxHp = PassaValores.hp;
        }
        moedas = PassaValores.moedas;
        
        if(PassaValores.cor_mapa == 2){
            int i = 0;
            foreach(string tipo in EscolhaFase1_2.lista_tag){
                foreach(GameObject gameObj in GameObject.FindGameObjectsWithTag(EscolhaFase1_2.lista_tag[i]))
                {
                    gameObj.GetComponent<Renderer>().material.color = new Color(+ .79f, + .79f, + .79f, .9f);

                }
                i++;
            }
        }else if(PassaValores.cor_mapa == 1){
            int i = 0;
            foreach(string tipo in EscolhaFase1_2.lista_tag){
                foreach(GameObject gameObj in GameObject.FindGameObjectsWithTag(EscolhaFase1_2.lista_tag[i]))
                {
                    gameObj.GetComponent<Renderer>().material.color = new Color(+ 1.1f, + 1.1f, + 1.1f, 1f);

                }
                i++;
            }
        }

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
            puloExtra = true;
        }


        if (ganhouPulo == true)
        {
            if (Input.GetButtonDown("Jump") && puloExtra == true && estaNoChao == false)
            {
                _GameController.playSFX(_GameController.sfxJump, 0.3f);
                velocidadeY = 0;
                PlayerRb.AddForce(new Vector2(0, forcaPulo));
                puloExtra = false;
            }
        }

        if (Input.GetButtonDown("Fire1"))
        {   
            _GameController.playSFX(_GameController.sfxAtack, 0.3f);
            estaAtacando = true;
            PlayerAnimator.SetTrigger("ataque");
        }

        if(maxHp <= 0){
            PassaValores.moedas = 0;
            PassaValores.hp = 3;
            SceneManager.LoadScene(_GameControllerTeleporte.ProximaFase-1);
        }

        PlayerRb.velocity = new Vector2(lados*velocidade ,velocidadeY);



        PlayerAnimator.SetInteger("lados", (int) lados);
        PlayerAnimator.SetBool("estaNoChao", estaNoChao);
        PlayerAnimator.SetFloat("velocidadeY", velocidadeY);
        PlayerAnimator.SetBool("estaAtacando", estaAtacando);
        PlayerAnimator.SetBool("morreu", morreu);
		
		numCor = maxHp;
		
		for (int i = 0; i < coracoes.Length; i++){
			if(i < numCor){
				coracoes[i].enabled = true;
			}else{
				coracoes[i].enabled = false;
			}
		}
        if (estaNaEscada)
        {
            PlayerRb.gravityScale = 0;

        }
        else
        {
            PlayerRb.gravityScale = gravidadeInicial;
        }
    }


    void FixedUpdate(){
        estaNoChao = Physics2D.OverlapCircle(GroundCheck.position, 0.02f, groundLayer);
    }

    void OnTriggerEnter2D(Collider2D colider) {
        if(colider.gameObject.tag == "Coletavel")
        {
            _GameController.playSFX(_GameController.sfxCoin, 0.5f);
            moedas += 1;
            Destroy(colider.gameObject);
        }
        else if(colider.gameObject.tag == "damage")
        {
            StartCoroutine("damageController");
        }
        else if(colider.gameObject.tag == "viu player")
        {   
            _SlimeIAMesmo.StopCoroutine("seguePlayer");
            _SlimeIAMesmo.StartCoroutine("seguePlayer");
        }
		//O ESCOLHA1_2 ESTA SENDO USADO TANTO PARA O LIVRO NA FASE 1.2 QUANTO PRA BATATA NA 2.1
        else if(colider.gameObject.tag == "Escolha1_2")
        {   
            itens += 1;
            _GameController.playSFX(_GameController.sfxCoin, 0.5f);
            _Escolha.SetActive(true);
            Time.timeScale = 0;
            Destroy(colider.gameObject);
        }
        else if(colider.gameObject.tag == "Vini")
        {
            print("aiai");
            _Escolha_Vini.SetActive(true);
            Time.timeScale = 0;
        }
        else if(colider.gameObject.tag == "Buraco")
        {   
            maxHp = 0;
        }
        else if(colider.gameObject.tag == "Itens")
        {
            _GameController.playSFX(_GameController.sfxCoin, 0.5f);
            itens += 1;
            Destroy(colider.gameObject);
        }else if(colider.gameObject.tag == "PuloExtra")
        {   
            ganhouPulo = true;
            forcaPulo = 250;
            _GameController.playSFX(_GameController.sfxCoin, 0.5f);
            itens += 1;
            Destroy(colider.gameObject);
        }
        PassaValores.hp = maxHp;
        PassaValores.moedas = moedas;

        if (colider.gameObject.tag == "Ladder")
        {
            estaNaEscada = true;
            forcaPuloEscada = forcaPulo;
            forcaPulo = 150;
      
        }
   
    }

    void OnCollisionEnter2D(Collision2D colider) {
        if(colider.gameObject.tag == "ground")
        {   
            estaNoChao = true;
        }

        if (colider.transform.tag == "plataformaMeche")
        {
            TransformPlayer.parent = colider.transform;
        }
    }

    void OnCollisionExit2D(Collision2D colider) {
        if(colider.gameObject.tag == "ground")
        {   
            estaNoChao = false;
        }
        if (colider.transform.tag == "plataformaMeche")
        {
            TransformPlayer.parent = null;
        }
    }

    void OnTriggerExit2D(Collider2D colider2) {
        if(colider2.gameObject.tag == "viu player")
        {   
            print("saas");
            _SlimeIAMesmo.StopCoroutine("seguePlayer");
            _SlimeIAMesmo.StartCoroutine("SlimeWalk");
        }
        if (colider2.gameObject.tag == "Ladder")
        {
            estaNaEscada = false;
            PlayerRb.velocity = new Vector2(PlayerRb.velocity.x, 0);
            forcaPulo = forcaPuloEscada;

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


