using UnityEngine;
using System.Collections;
using System;

public class InputManager : MonoBehaviour
{
    /**
     * Recupere les touches aux clavier lorsque la plateforme d'execution est IOS, ANDROID ou WINDOWS PHONE 8.1
     * Le Update va vérifier qu'il y ai au moins un touch en cours, si c'est le cas, il va lancer le traitement
     * de cet input.
     * Nous traitons uniquement le monoTouch, la premiere case du tableau "touch" contient le premier touch
     * effectué par le joueur.
     * La position du premier touch est envoyé au GameManager si nous sommes dans la scene Level.
     */
#if UNITY_ANDROID || UNITY_IOS || UNITY_WP8_1

    private Touch[] touches;

    private Joystick joystickPlayer1 = new Joystick(new Vector3(Screen.width * 5 / 6, Screen.width * 5 / 6, 0)
                                                    , Screen.width * 1 / 6);
    private Joystick joystickPlayer2 = new Joystick(new Vector3(Screen.width * 1 / 6, Screen.height - Screen.width * 1 / 6, 0)
                                                    , Screen.width * 1 / 6);
    private int IDJoystick1 = -1;
    private int IDJoystick2 = -1;
    private bool joystick1Activ = false;
    private bool joystick2Activ = false;

    void Start()
    {
        DontDestroyOnLoad(this);
    }

    void Update()
    {
        touches = Input.touches;


        if (touches.Length < 1)
        {
            return;
        }
        foreach(Touch touch in touches)
        {
            if(!joystickPlayer1.isActiv())
            {
                IDJoystick1 = joystickPlayer1.activJoystickAndGetIDIfInRange(touch);
            }
            else
            {
                if(IDJoystick1 == touch.fingerId)
                {
                    joystickPlayer1.getInput(touch);
                }
            }
            if (!joystickPlayer2.isActiv())
            {
                IDJoystick2 = joystickPlayer2.activJoystickAndGetIDIfInRange(touch);
            }
            else
            {
                if (IDJoystick2 == touch.fingerId)
                {
                    joystickPlayer2.getInput(touch);
                }
            }
        }
    }

    
#endif
}
