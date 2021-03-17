using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NotificationManager : MonoBehaviour
{

    public static NotificationManager current;


    [SerializeField] private TextMeshProUGUI notificationText;
    [SerializeField] private float fadeTime;
    private void Awake()
    {
        current = this;
    }
    private IEnumerator notifcationCoroutine;

    public void SetNewNotifcation(string msg)
    {
        if (notifcationCoroutine != null)
        {
            StopCoroutine(notifcationCoroutine);
        }
        notifcationCoroutine = FadeOutNotification(msg);
        StartCoroutine(notifcationCoroutine);
    }
    private  IEnumerator FadeOutNotification(string msg)
    {
        notificationText.text = msg;
        float t = 0;
        while (t < fadeTime)
        {
            t += Time.unscaledDeltaTime;
            notificationText.color = new Color(
                notificationText.color.r,
                notificationText.color.g,
                notificationText.color.b,
                Mathf.Lerp(1f, 0f, t/fadeTime));
            yield return null;
        }
    }
    
}
