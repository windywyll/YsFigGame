using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SlidersLifePlayers : MonoBehaviour
{
    public Slider mSliderLife;
    public Player player;
    private float mStartLife;

    void Start ()
    {
        Debug.Log(player.name + " StartLife : " + player.getLife());
        mStartLife = player.getLife();
    }
	void Update ()
    {
        Debug.Log(player.name + " Life : " + player.getLife());
        mSliderLife.value = (player.getLife() / mStartLife);
	}
}
