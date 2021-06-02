using UnityEngine;
using UnityEngine.UI;

public class TwoOptionsWindowFactory : WindowFactory
{
    [SerializeField]
    private GameObject yesNoWindowGO;
    [SerializeField]
    private GameObject windowOptionGO;
    [SerializeField]
    private GameObject windowsContainerGO;

    public override GameObject CreateWindow(string title, string contents, WindowOption[] windowOptions)
    {
        GameObject window = Instantiate(yesNoWindowGO, windowsContainerGO.transform);
        GameObject titleGO = window.transform.GetChild(1).GetChild(0).gameObject;
        GameObject contentsGO = window.transform.GetChild(2).GetChild(0).gameObject;
        GameObject optionSlot0 = window.transform.GetChild(3).GetChild(0).gameObject;
        GameObject optionSlot1 = window.transform.GetChild(3).GetChild(1).gameObject;

        CreateTitle(titleGO, title);
        CreateContents(contentsGO, contents);
        CreateWindowOption(window, optionSlot0, windowOptions[0]);
        CreateWindowCloseOption(window, optionSlot1, windowOptions[1]);

        return window;
    }

    private void CreateTitle(GameObject titleGO, string title)
    {
        titleGO.GetComponent<Text>().text = title;
    }

    private void CreateContents(GameObject contentsGO, string contents)
    {
        contentsGO.GetComponent<Text>().text = contents;
    }

    private void CreateWindowOption(GameObject windowGO, GameObject optionSlot, WindowOption windowOption)
    {
        GameObject option = Instantiate(windowOptionGO, optionSlot.transform);
        option.transform.GetChild(0).GetComponent<Text>().text = windowOption.contents;
        option.GetComponent<Button>().onClick.AddListener(() => windowOption.option());
        option.GetComponent<Button>().onClick.AddListener(() => DestroyWindow(windowGO));
    }

    private void CreateWindowCloseOption(GameObject windowGO, GameObject optionSlot, WindowOption windowOption)
    {
        GameObject option = Instantiate(windowOptionGO, optionSlot.transform);
        option.transform.GetChild(0).GetComponent<Text>().text = windowOption.contents;
        option.GetComponent<Button>().onClick.AddListener(() => windowOption.option());
        option.GetComponent<Button>().onClick.AddListener(() => DestroyWindow(windowGO));
    }

    private void DestroyWindow(GameObject windowGO)
    {
        Destroy(windowGO);
    }
}
