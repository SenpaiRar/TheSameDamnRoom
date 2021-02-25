using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ParseDialogueText : MonoBehaviour
{
    public TextAsset Dialgoue;
    private string[] arrayOfText;
    public List<string> NameList = new List<string>();
    public List<string> DialgoueList = new List<string>();

    private void Start()
    {
        arrayOfText = Dialgoue.text.Split('\n');

        for (int i = 0; i < arrayOfText.Length; i++)
        {
            switch (arrayOfText[i][0])
            {

                case '<':
                    NameList.Add(arrayOfText[i]);
                    break;

                case '{':
                    DialgoueList.Add(arrayOfText[i]);
                    break;

            }
                  
      }

        foreach (var item in NameList)
        {
            print(item);
        }
        foreach (var item in DialgoueList)
        {
            print(item);
        }
    }
}
