using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{   

    public  Transform   background;
    public  float       velocidade;

    private Transform   cam;
    private Vector3     posicaoCamAnterior;

    // Start is called before the first frame update
    void Start()
    {   

        cam = Camera.main.transform;
        posicaoCamAnterior = cam.position;
    }

    // Update is called once per frame
    void Update()
    {
        float paralaxX = posicaoCamAnterior.x - cam.position.x;
        float bgTargetX = background.position.x + paralaxX;

        Vector3 bgPosition = new Vector3(bgTargetX, background.position.y, background.position.z);
        background.position = Vector3.Lerp(background.position, bgPosition, velocidade * Time.deltaTime);

        posicaoCamAnterior = cam.position;

    }
}
