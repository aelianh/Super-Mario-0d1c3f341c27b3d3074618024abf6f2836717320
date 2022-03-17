using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //MAnagers de sonido
    private SFXManager sfxManager;
    private BGMManager bgmManager;
    private int coins;
    private int goomba;
    public Text goombaText;
    public Text coinsText;

    void Awake()
    {
        sfxManager = GameObject.Find("SFXManager").GetComponent<SFXManager>();
        bgmManager = GameObject.Find("BGMManager").GetComponent<BGMManager>();
    }


    public void DeathMario()
    {
        sfxManager.DeathSound();
        bgmManager.StopBGM();
    }



    //Funcion para matar goombas
    public void DeathGoomba(GameObject goomba)
    {
        //variable para el animator del goomba
        Animator goombaAnimator;
        //variable para el script del goomba
        Enemy goombaScript;
        //variable para el collider
        BoxCollider2D goombaCollider;

        //asignamos las variable
        goombaScript = goomba.GetComponent<Enemy>();
        goombaAnimator = goomba.GetComponent<Animator>();
        goombaCollider = goomba.GetComponent<BoxCollider2D>();

        //cambiamos a la animacion de muerte
        goombaAnimator.SetBool("GoombaDeath", true);

        //cambiamos la variable del goomba a false
        goombaScript.isAlive = false;

        //Ajustamos el collider
        /*goombaCollider.size = new Vector2(1, 0.5f);
        goombaCollider.offset = new Vector2(0, 0.25f);*/

        //desactivo el collider
        goombaCollider.enabled = false;

        //destruimos el goomba
        Destroy(goomba, 0.3f);

        //llamamos la funcion del sonido de muerte del goomba
        sfxManager.GoombaSound();
        goomba++;
        goombaText.text = "Goomba: " + goomba;
    }

    public void Coin(GameObject moneda)
    {
        Destroy(moneda);
        sfxManager.MonedaSound();
        coins++;
        coinsText.text = "Coins: " + coins;
    }
     public void Goomba(GameObject goomba)
    {
        Destroy(goomba);

    
    }
        public void BanderaVictoria (GameObject bandera)
    { 
        BoxCollider2D banderaCollider;

        banderaCollider = bandera.GetComponent<BoxCollider2D>();

        sfxManager.BanderaSound();
        SceneManager.LoadScene(0);
    }
    
    public void VictoriaMario ()
    {
        sfxManager.BanderaSound();
        bgmManager.StopBGM();
        
    }

}
