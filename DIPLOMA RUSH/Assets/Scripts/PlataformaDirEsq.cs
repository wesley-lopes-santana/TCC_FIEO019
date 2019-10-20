using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaDirEsq : MonoBehaviour

    
{
    public Transform plataforma;
    public float maxX;
    public float minX;
    public float velocidade;
    private float proxPosicao;
    // Start is called before the first frame update
    void Start()
    {
        proxPosicao = maxX;
    }

    // Update is called once per frame
    void Update()
    {
        if (plataforma.position.x == minX)
        {
            proxPosicao = maxX;
        }
        else if (plataforma.position.x == maxX)
        {
            proxPosicao = minX;
        }
        // while(plataforma.position.y > minY && plataforma.position.y < maxY){
        //    plataforma.position = Vector2.MoveTowards(plataforma.position, new Vector2(plataforma.position.x, maxY), velocidade * Time.deltaTime);
        // }
        // if(plataforma.position.y == minY ){
        plataforma.position = Vector2.MoveTowards(plataforma.position, new Vector2(proxPosicao, plataforma.position.y ), velocidade * Time.deltaTime);
        // }
        // else if(plataforma.position.y > minY && plataforma.position.y == maxY ){
        //     plataforma.position = Vector2.MoveTowards(plataforma.position, new Vector2(plataforma.position.x, minY), velocidade * Time.deltaTime);
        // }

    }
}