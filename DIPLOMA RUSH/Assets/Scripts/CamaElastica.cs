using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaElastica : MonoBehaviour
{
    public float forca;
    private Animator        camaElastica;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        camaElastica = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            camaElastica.SetTrigger("pisou");
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            other.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, forca));
        }
    }
}
