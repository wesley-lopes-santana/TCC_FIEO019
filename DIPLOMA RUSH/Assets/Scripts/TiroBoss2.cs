using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroBoss2 : MonoBehaviour
{   
    private Transform       alvo;
    private Vector3         destino;
    private Transform       inicio;
    private float           velocidade=3.5f;
    private Vector3         newPos;
    // Start is called before the first frame update
    void Start()
    {
        alvo = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        destino = alvo.position;
        inicio = Boss2.boss2_local;
        newPos = inicio.position;
    }

    // Update is called once per frame
    void Update()
    {  
        if(newPos != destino){
            this.gameObject.transform.position = Vector3.MoveTowards(newPos, destino, velocidade*Time.deltaTime);
            Destroy(this.gameObject, 2f);
            newPos = this.gameObject.transform.position;
        }
        
    }
}
