using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporteInterno : MonoBehaviour
{

    public GameObject Portal;
    public GameObject Player;
    public float addX = 0;
    private Animator   portalAnimator;


    // Use this for initialization
    void Start()
    {
        portalAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {   
            portalAnimator.SetTrigger("abrindo");
            StartCoroutine(Teleport());
        }
    }


    IEnumerator Teleport()
    {
        yield return new WaitForSeconds(1.0f);
        Player.transform.position = new Vector2(Portal.transform.position.x + addX , Portal.transform.position.y);
        //addX serve para que player não nasca em cima do portal
        // 0 = nasce em cima
        // 1 ou mais = teleporta a direita
        // -1 ou menos = teleporta a esquerda
    }
}