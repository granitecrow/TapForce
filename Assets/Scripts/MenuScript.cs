using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuScript : MonoBehaviour {

    public Canvas quitMenu;
    public Button startText;
    public Button exitText;

    // Use this for initialization
    void Start() {
        if (quitMenu != null)
        {
            quitMenu = quitMenu.GetComponent<Canvas>();
            quitMenu.enabled = false;
        }
        if (startText != null)
        {
            startText = startText.GetComponent<Button>();
        }
        if (exitText != null)
        {
        exitText = exitText.GetComponent<Button>();
        }
    }
    
    public void ExitPress()
    {
        if (quitMenu != null)
        {
            quitMenu.enabled = true;
        }
        if (startText != null)
        {
            startText.enabled = false;
        }
        if (exitText != null)
        {
            exitText.enabled = false;
        }
    }

    public void NoExitPress()
    {
        quitMenu.enabled = false;
        startText.enabled = true;
        exitText.enabled = true;
    }

    public void StartGame()
    {
        Application.LoadLevel("GetReady");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        Application.LoadLevel("MainMenu");
    }

}
