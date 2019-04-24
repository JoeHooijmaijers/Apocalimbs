using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MajorEventUI : MonoBehaviour
{
    [SerializeField] private float fadeTime = 1.5f;
    public Text uiText;

    [SerializeField] private Color defeatColor;
    [SerializeField] private Color deathColor;
    [SerializeField] private Color baseColor;
    

    // Start is called before the first frame update
    void Start()
    {
        uiText = GetComponent<Text>();
        uiText.color = baseColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator IEFadeOut()
    {
        while (uiText.color.a > 0.0f)
        {
            uiText.color = new Color(uiText.color.r, uiText.color.g, uiText.color.b, uiText.color.a - Time.deltaTime);
            yield return null;
        }
        uiText.color = baseColor;
    }

    IEnumerator IEFadeInDefeated()
    {
        uiText.text = "Boss Defeated";
        uiText.color = defeatColor;
        while (uiText.color.a < 1.0f)
        {
            uiText.color = new Color(uiText.color.r, uiText.color.g, uiText.color.b, uiText.color.a + Time.deltaTime);
            yield return null;
        }
        yield return new WaitForSeconds(4);
        FadeOut();
    }

    IEnumerator IEFadeInDeath()
    {
        uiText.text = "You are dead";
        uiText.color = deathColor;
        while (uiText.color.a < 1.0f)
        {
            uiText.color = new Color(uiText.color.r, uiText.color.g, uiText.color.b, uiText.color.a + Time.deltaTime);
            yield return null;
        }
        yield return new WaitForSeconds(4);
        FadeOut();
    }

    public void FadeOut()
    {
        StartCoroutine(IEFadeOut());
    }

    public void FadeInDefeated()
    {
        StartCoroutine(IEFadeInDefeated());
        Debug.Log("Boss Defeated");
    }

    public void FadeInDeath()
    {
        StartCoroutine(IEFadeInDeath());
        Debug.Log("You are dead");
    }

}
