using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //to be able to load scenes
using TMPro;

public class GameOverMenuController : MonoBehaviour
{
    public TMP_Text endConditionText;
    public EndData endData;
    // Start is called before the first frame update
    void Start()
    {
        endConditionText.text = endData.gameOverMsg;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene("Level");
    }
}
