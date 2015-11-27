using UnityEngine;
using System.Collections;

public class ScriptPlayButton : MonoBehaviour
{
    Animator animator;
	// Use this for initialization
	void Start ()
    {
        animator = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void StartSwinging ()
    {
        animator.SetBool("Fallen", true);
    }

    public void onClick()
    {
        Application.LoadLevel(2);
    }
}
