using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayEndMessage : MonoBehaviour
{
    public EndData endData;
    public TMP_Text endMessage;
    // Start is called before the first frame update
    void Start()
    {
        endMessage.text = endData.gameOverMsg;
    }
}
