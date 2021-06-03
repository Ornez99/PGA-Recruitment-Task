using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private string saveSeparator = "#value#";
    [SerializeField] private QuitGame quitGame;
    [SerializeField] private FloatVariable bestTime;
    [SerializeField] private FloatVariable currentTime;

    private void Awake()
    {
        quitGame.QuitEvent += Save;
        Load();
    }

    public void Save()
    {
        string[] contents = new string[]
        {
            "" + bestTime.Value
        };
        string saveString = string.Join(saveSeparator, contents);
        File.WriteAllText(Application.dataPath + "/save.txt", saveString);
    }

    public void Load()
    {
        if(File.Exists(Application.dataPath + "/save.txt"))
        {
            string saveString = File.ReadAllText(Application.dataPath + "/save.txt");
            string[] contents = saveString.Split(new[] { saveSeparator }, System.StringSplitOptions.None);
            float bestTime = float.Parse(contents[0]);
            this.bestTime.Value = bestTime;
        }
    }
}
