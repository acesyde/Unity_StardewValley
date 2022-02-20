using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.UI;

public class DayTimeController : MonoBehaviour
{
    private const float secondsInDay = 86400f;
    private float time;
    private int days;

    [SerializeField] private AnimationCurve nightTimeCurve;
    [SerializeField] private Color nightLightColor;
    [SerializeField] private Color dayLightColor = Color.white;
    [SerializeField] private Text text;
    [SerializeField] private float timeScale = 60f;
    [SerializeField] private Light2D globalLight;

    float Hours => time / 3600f;
    float Minutes => time % 3600f / 60f;

    private void Update()
    {
        time += Time.deltaTime * timeScale;
        int hh = (int) Hours;
        int mm = (int) Minutes;
        text.text = hh.ToString("00") + ":" + mm.ToString("00");
        float v = nightTimeCurve.Evaluate(Hours);
        Color c = Color.Lerp(dayLightColor, nightLightColor, v);
        globalLight.color = c;
        if (time > secondsInDay)
        {
            NextDay();
        }
    }

    private void NextDay()
    {
        time = 0;
        days += 1;
    }
}
