using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour {
    private int score = 0;
    public Text scoreText;
    private float speed;
    private float timeColor;
    private Material m_Material;
    public AudioSource change, good, bad, slow, orig;
    public Light light;
    private int mult;
    private bool mute;
    private bool isDead = false, isPaused = false;
    public DeathMenu deathMenu;
    public ZoneManager zm;

    public CollectibleManager cm;
    public GroundManager gm;
    public PauseMenu pm;
    private bool colorChanged = false, badBall = false, goodBall = false;
    // Use this for initialization
    void Start () {
        scoreText.text = (score).ToString();
        speed = 0.075f;
        mult = 1;
        m_Material = GetComponent<Renderer>().material;
        m_Material.color = Color.red;
        mute = MainMenu.muteMusic;
    }
    void OnTriggerEnter(Collider other)
    {

        if (other.tag.Equals("BZone"))
        {
            light.color = Color.blue*0.8f;
            m_Material.color = Color.blue;
            colorChanged = true;
        }
        if (other.tag.Equals("RZone"))
        {
            light.color = Color.red;
            m_Material.color = Color.red;
            colorChanged = true;
        }
        if (other.tag.Equals("GZone"))
        {
            light.color = Color.green;
            m_Material.color = Color.green;
            colorChanged = true;
        }

        if (other.tag.Equals("CRed"))
        {   if(m_Material.color == Color.red)
            {
                goodBall = true;
               score += 10;
               if (score >= 50*mult)
                {
                    mult += 1; 
                    speed *= 2;
                }
            }
            else
            {
                badBall = true;
                score = score / 2;
                int multBefore = mult;
                mult = score / 50;
                mult++;
                while (multBefore > mult)
                {
                    multBefore--;
                    speed /= 2;
                }
                print(mult);
                if (score <= 0)
                {
                    Death();
                }
            }
        }
        if (other.tag.Equals("CGreen"))
        {
            if (m_Material.color == Color.green)
            {
                goodBall = true;
                score += 10;
                if (score >= 50 * mult)
                {
                    mult += 1;
                    speed *= 2;
                }
            }
            else
            {
                badBall = true;
                score = score / 2;
                int multBefore = mult;
                mult = score / 50;
                mult++;
                while (multBefore > mult)
                {
                    multBefore--;
                    speed /= 2;
                }
                if (score <= 0)
                {
                    Death();
                }
            }
        }
        if (other.tag.Equals("CBlue"))
        {
            if (m_Material.color == Color.blue)
            {
                goodBall = true;
                score += 10;
                if (score >= 50 * mult)
                {
                    mult += 1;
                    speed *= 2;
                }
            }
            else
            {
                badBall = true;
                score = score / 2;
                int multBefore = mult;
                mult = score / 50;
                mult++;
                while (multBefore > mult)
                {
                    multBefore--;
                    speed /= 2;
                }
                if (score <= 0)
                {
                    Death();
                }
            }
        }
    }
	// Update is called once per frame
	void Update ()
    {
        if (colorChanged)
        {
            timeColor = Time.time;
            if(!mute)
                change.Play();
            print("saudio");
            colorChanged = false;
        }
        if(Time.time - timeColor> 1.0)
        {
            light.color = Color.white;
        }
        if (badBall)
        {
            badBall = false;
            if(!mute)
                bad.Play();
        }
        if (goodBall)
        {
            goodBall = false;
            if(!mute)
                good.Play();
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            if (!isPaused)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
        scoreText.text = (score).ToString();
        if (isDead || isPaused)
            return;
        transform.Translate(0, 0, -1*speed);
 
        
    }
    public void Pause()
    {
        if (!mute)
        {
            orig.Pause();
            slow.Play();
        }
        isPaused = true;
        zm.onPause();
        cm.onPause();
        gm.onPause();
        GetComponent<BallMovement>().onPause();
        pm.Pause();
    }
    public void Resume()
    {
        if (!mute)
        {
            orig.UnPause();
            slow.Stop();
        }
        isPaused = false;
        zm.resume();
        cm.resume();
        gm.resume();
        GetComponent<BallMovement>().resume();
        pm.Resume();

    }
    public void Death()
    {
        if (!mute)
        {
            orig.Stop();
            slow.Play();
        }
        isDead = true;
        zm.onDead();
        cm.onDead();
        gm.onDead();
        GetComponent<BallMovement>().onDead();
        deathMenu.ToggleEndMenu();
    }
}
