using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoVoador : MonoBehaviour
{
    
    private GameController  _GameController;
    private Animator        _InimigoVoador;
    public GameObject       _Player;

    private bool seguindo;
    public  GameObject      HitBox;

    public bool estaOlhandoEsquerda;
    public float velocidade;

    void Start()
    {
        _GameController = FindObjectOfType(typeof(GameController)) as GameController;

        _InimigoVoador = GetComponent<Animator>();

        _Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(seguindo == true && _Player.layer == 8)
        {
            velocidade = 1.15f;
            transform.position = Vector3.MoveTowards(transform.position, _GameController.playerTransform.position, velocidade * Time.deltaTime);
        }else{
            velocidade = 0f;
            transform.position = Vector3.MoveTowards(transform.position, _GameController.playerTransform.position, velocidade * Time.deltaTime);
        }

        if(transform.position.x < _GameController.playerTransform.position.x && estaOlhandoEsquerda == true)
        {
            Gira();
        }
        else if(transform.position.x > _GameController.playerTransform.position.x && estaOlhandoEsquerda == false)
        {
            Gira();
        }

        
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "hitBox"){
            print("a");
            print("cur");
            Destroy(HitBox);
            _GameController.playSFX(_GameController.sfxEnemyDead, 0.32f);
            _InimigoVoador.SetTrigger("morto");
        }
        if(col.gameObject.tag == "hitBox"){
            print("cur");
            Destroy(HitBox);
            _GameController.playSFX(_GameController.sfxEnemyDead, 0.32f);
            _InimigoVoador.SetTrigger("morto");
        }
    }

    void OnBecameVisible() {
        seguindo = true;
    }

    void OnDead(){
        Destroy(this.gameObject);
    }


    void Gira()
    {
        estaOlhandoEsquerda = !estaOlhandoEsquerda;
        float x = transform.localScale.x * -1; //Inverte o sinal do Transform -> Scale -> X
        transform.localScale = new Vector3(x, transform.localScale.y, transform.localScale.z);
    }
}
