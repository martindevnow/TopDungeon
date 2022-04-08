using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingTextManager : MonoBehaviour
{
    public GameObject textContainer;
    public GameObject textPrefab;

    private List<FloatingText> floatingTexts = new List<FloatingText>();

    public void Show(string message, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        FloatingText floatingText = GetFloatingText();
        floatingText.go.transform.position = Camera.main.WorldToScreenPoint(position);

        floatingText.text.text = message;
        floatingText.text.fontSize = fontSize;
        floatingText.text.color = color;
        floatingText.motion = motion;
        floatingText.duration = duration;

        floatingText.Show();

    }

    private FloatingText GetFloatingText()
    {
        FloatingText text = floatingTexts.Find(t => !t.active);
        if (text == null)
        {
            text = new FloatingText();
            text.go = Instantiate(textPrefab);
            text.go.transform.SetParent(textContainer.transform);
            text.text = text.go.GetComponent<Text>();

            floatingTexts.Add(text);
        }

        return text;
    }

    private void Update()
    {
        foreach(FloatingText text in floatingTexts)
        {
            text.UpdateFloatingText();
        }
    }

}
