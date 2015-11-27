using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScriptPanelWin : MonoBehaviour
{
    public Text m_Winner;

	// Use this for initialization
	void Start ()
    {
    }
	
	IEnumerator C_Win()
    {
        for (int i = 0; i<4;i++)
        {
            yield return new WaitForSeconds(1f);
        }
        this.gameObject.SetActive(false);
        Application.LoadLevel(1);
    }

    public void setWinner(bool winnerisP1)
    {
        if (winnerisP1)
        { m_Winner.text = "Player1,\n you win"; }

        else if (!winnerisP1)
        { m_Winner.text = "Player2,\n you win"; }

        StartCoroutine(C_Win());
    }
}
