using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowFactory : MonoBehaviour
{
    [SerializeField] private GameObject windowParent;
    [SerializeField] private GameObject windowPrefab;
    [SerializeField] private GameObject optionPrefab;
    private const int titleId = 1;
    private const int contentId = 2;
    private const int optionsId = 3;

    public GameObject CreateWindow(Window window)
    {
        GameObject windowGO = Instantiate(windowPrefab, windowParent.transform);
        windowGO.transform.GetChild(titleId).GetChild(0).GetComponent<Text>().text = window.Title;
        windowGO.transform.GetChild(contentId).GetChild(0).GetComponent<Text>().text = window.Content;
        GameObject optionsGO = windowGO.transform.GetChild(optionsId).gameObject;
        foreach(Option option in window.Options)
        {
            GameObject optionGO = Instantiate(optionPrefab, optionsGO.transform);
            optionGO.transform.GetChild(0).GetComponent<Text>().text = option.Content;
            optionGO.GetComponent<Button>().onClick.AddListener(() => option.OptionEvent.Invoke());
        }
        return windowGO;
    }
}
