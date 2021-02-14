using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //to be able to load scenes

public class MainMenuController : MonoBehaviour
{
    GameObject loadPanel;

    // Start is called before the first frame update
    void Start()
    {
        loadPanel = GameObject.Find("LoadGamePanel");
        loadPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayLevel1()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //load next scene in queue
        SceneManager.LoadScene("Level"); //will load specific scene by name
    }
    public void QuitGame()
    {
        Debug.Log("QUIT--");
        Application.Quit();
    }
    public void LoadPanel()
    {
        Debug.Log("LoadPanel selected");
        loadPanel.SetActive(true);
    }
}
