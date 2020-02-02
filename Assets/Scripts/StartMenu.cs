using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public Button yourButton;
    public GameObject credits;
    public GameObject credits1;
    public GameObject creditsNextButton;
    public GameObject creditsBackButton;
    public GameObject help;
    public GameObject helpBackButton;

    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        credits.SetActive(false);
        credits1.SetActive(false);
        creditsNextButton.SetActive(false);
        creditsBackButton.SetActive(false);
        help.SetActive(false);
        helpBackButton.SetActive(false);
    }

    public void TaskOnClick()
    {
        Debug.Log("You have clicked the button!");
    }

    public IEnumerator RickRoll()
    {

        yield return new WaitForSeconds(1);
        Application.OpenURL("https://www.youtube.com/watch?v=dQw4w9WgXcQ");
    }

    public IEnumerator BobRoss()
    {

        yield return new WaitForSeconds(1);
        Application.OpenURL("https://www.youtube.com/watch?v=h5nMXlA-_rM");
    }

    public void Credits()
    {
        credits.SetActive(true);
        creditsNextButton.SetActive(true);
    }

    public void Help()
    {
        help.SetActive(true);
        helpBackButton.SetActive(true);
        StartCoroutine(RickRoll());
    }

    public void Credits1()
    {
        credits.SetActive(false);

        creditsNextButton.SetActive(false);
        credits1.SetActive(true);
        creditsBackButton.SetActive(true);
    }

    public void GoBackClick()
    {
        creditsNextButton.SetActive(false);
        creditsBackButton.SetActive(false);
        credits1.SetActive(false);
        StartCoroutine(BobRoss());
    }

    public void HelpGoBackClick()
    {
        helpBackButton.SetActive(false);
        help.SetActive(false);
    }


}
