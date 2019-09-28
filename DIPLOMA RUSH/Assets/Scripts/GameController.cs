using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private Camera      cam;
    public  Transform   playerTransform;

    public  Transform   limiteCamEsc, limiteCamDir, limiteCamCima, limiteCamBaixo;
    public  float       velocidadeCam;


    //SONS
    [Header("Audio")]
    public  AudioSource sfxSource;
    public  AudioSource musicSource;

    public  AudioClip   sfxJump;
    public  AudioClip   sfxAtack;
    public  AudioClip[] sfxStep;
    public  AudioClip   sfxCoin;
    public  AudioClip   sfxEnemyDead;
    public  AudioClip   sfxDamage;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate()
    {
        MecheCamera();
    }
    
    public void MecheCamera(){
        if(playerTransform != null){
            float posCamX = playerTransform.position.x;
            float posCamY = playerTransform.position.y;
        
            if (cam.transform.position.x < limiteCamEsc.position.x && playerTransform.position.x < limiteCamEsc.position.x){

                posCamX = limiteCamEsc.position.x;

            }else if (cam.transform.position.x > limiteCamDir.position.x && playerTransform.position.x > limiteCamDir.position.x){

                posCamX = limiteCamDir.position.x;

            }

            if (cam.transform.position.y < limiteCamBaixo.position.y && playerTransform.position.y < limiteCamBaixo.position.y){

                posCamY = limiteCamBaixo.position.y;

            }else if (cam.transform.position.y > limiteCamCima.position.y && playerTransform.position.y > limiteCamCima.position.y){

                posCamY = limiteCamCima.position.y;

            }

            Vector3 posCam = new Vector3(posCamX, posCamY, cam.transform.position.z);
            cam.transform.position = Vector3.Lerp(cam.transform.position, posCam, velocidadeCam * Time.deltaTime);
        }
        //Vector3 posCam = new Vector3(playerTransform.position.x, playerTransform.position.y, cam.transform.position.z);
        //cam.transform.position = posCam;

    }



    public void playSFX(AudioClip sfxClip, float volume)
    {
        sfxSource.PlayOneShot(sfxClip, volume);
    }

}
