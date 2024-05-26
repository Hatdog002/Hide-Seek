using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public float Base1Count;
    public float Base2Count;
    public float Base3Count;

    public float timer;

    public TextMeshProUGUI txt;

    public PlayerTag player;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    public void Start()
    {
        timer = 10;    
    }

    public void Update()
    {
        timer -= Time.deltaTime;
        
        if (player.tags == PlayerTagss.Hider)
        {
            txt.text = "You are now the Hider";
            if (timer <= 7)
            {
                txt.text = "";
            }
        }
        else
        {
            txt.text = "You are now the Seeker        " + timer.ToString();
            if(timer <= 0)
            {
                txt.text = "";
            }
        }
    }
}
