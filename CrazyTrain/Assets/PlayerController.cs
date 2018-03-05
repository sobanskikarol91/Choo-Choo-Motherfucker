using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    ColorObject _colorObject;
    FMOD.Studio.EventInstance chuuSound;
    FMOD.Studio.ParameterInstance chuuActive;

    FMOD.Studio.EventInstance engineSound;
    FMOD.Studio.ParameterInstance engineSpeed;

    FMOD.Studio.EventInstance musicSound;
    FMOD.Studio.ParameterInstance musicSpeed;

    public AudioSource deathSnd;
    public AudioSource stationPass;
    public AudioSource changeRails;
    public ColorChanger _colorChanger;

    public ParticleSystem[] particles;
    public GameObject[] carriages;

    [SerializeField] protected float EngineVolume = 1.0f;
    [SerializeField] protected float MusicVolume = 1.0f;

    Mover mover;
    bool Alive = true;

    private void Start()
    {
        particles = GetComponentsInChildren<ParticleSystem>();
        mover = GetComponent<Mover>();
        _colorObject = GetComponent<ColorObject>();
        _colorChanger = GetComponent<ColorChanger>();
        //FMODUnity.RuntimeManager.PlayOneShot("event:/Train/Engine");

        chuuSound = FMODUnity.RuntimeManager.CreateInstance("event:/Train/Chuu");
        chuuSound.getParameter("ChuuActive", out chuuActive);

        engineSound = FMODUnity.RuntimeManager.CreateInstance("event:/Train/Engine");
        engineSound.getParameter("GameSpeed", out engineSpeed);

        musicSound = FMODUnity.RuntimeManager.CreateInstance("event:/Music/Saloon");
        musicSound.getParameter("GameSpeed", out musicSpeed);

        engineSpeed.setValue(0.05f);
        musicSpeed.setValue(0.2f);

        engineSound.setVolume(EngineVolume);

     
        engineSound.start();
        musicSound.setVolume(MusicVolume);
        musicSound.start();
    }

    void Update()
    {
        if (!Alive) return;

        if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < 6)
        {
            transform.position += new Vector3(0, 2, 0);
            changeRails.Play();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > 0)
        {
            transform.position += new Vector3(0, -2, 0);
            changeRails.Play();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            chuuSound.start();
            chuuActive.setValue(1.0f);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            chuuActive.setValue(0.0f);
        }


        //musicSpeed.setValue((mover.speed - 25.0f) / 200.0f + 0.5f);
        engineSpeed.setValue((mover.speed - 25.0f) / 200.0f + 0.5f);

        float initialSpeed = GetComponent<Mover>().speed;
        float currentSpeed = GetComponent<Mover>().currentSpeed;
        float gameSpeed = 0.5f;
        if (currentSpeed < initialSpeed)
        {
            gameSpeed = currentSpeed / initialSpeed * 0.5f;
        }
        else
        {
            gameSpeed = 0.5f + ((currentSpeed - initialSpeed) / (25.0f - initialSpeed)) * 0.1f;
        }

        //musicSpeed.setValue(gameSpeed);
        engineSpeed.setValue(gameSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "station")
        {
            COLOR stationColor = collision.gameObject.GetComponent<ColorObject>()._color;

            if (_colorObject._color != stationColor)
                Death();
            else
            {
                _colorChanger.ChangeColor();
                FMODUnity.RuntimeManager.PlayOneShot("event:/Station/TrainPass");
                GameManager.instance.UpdatePoints();
            }
        }
    }

    public void Death()
    {
        foreach (GameObject c in carriages)
        {
            Destroy(c.gameObject);
        }
        CameraShaker.instance.ShakeCamere();
        Alive = false;
        Explode.instance.DoExplode();
        engineSound.setVolume(0);
        engineSound.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        GetComponentInChildren<SpriteRenderer>().enabled = false;
        DecreaseMovement.instance.Slow();
        deathSnd.Play();
        GetComponent<BoxCollider2D>().enabled = false;
        Camera.main.GetComponent<Mover>().enabled = false;
        mover.enabled = false;
        //engineSound.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        //musicSound.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);

        foreach (ParticleSystem ps in particles)
        {
            ps.Stop();
        }
    }
}
