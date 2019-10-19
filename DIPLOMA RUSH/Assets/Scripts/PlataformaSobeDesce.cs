using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaSobeDesce : MonoBehaviour
{

    public Transform  plataforma;

    public float maxY;
    public float minY;
    public float velocidade;
    private float proxPosicao ;

    // Start is called before the first frame update
    void Start()
    {
        proxPosicao = maxY;
    }

    // Update is called once per frame
    void Update()
    {   
        if(plataforma.position.y == maxY){
            proxPosicao = minY;
        }
        else if(plataforma.position.y == minY){
            proxPosicao = maxY;
        }
        // while(plataforma.position.y > minY && plataforma.position.y < maxY){
        //    plataforma.position = Vector2.MoveTowards(plataforma.position, new Vector2(plataforma.position.x, maxY), velocidade * Time.deltaTime);
        // }
        // if(plataforma.position.y == minY ){
        plataforma.position = Vector2.MoveTowards(plataforma.position, new Vector2(plataforma.position.x, proxPosicao), velocidade * Time.deltaTime);
        // }
        // else if(plataforma.position.y > minY && plataforma.position.y == maxY ){
        //     plataforma.position = Vector2.MoveTowards(plataforma.position, new Vector2(plataforma.position.x, minY), velocidade * Time.deltaTime);
        // }
        
    }
}
