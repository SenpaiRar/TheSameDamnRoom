using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DialogueSystem : MonoBehaviour
{
    public TextAsset Dialgoue;
    private string[] arrayOfText;



    private List<string> UnprocessedNameList = new List<string>();
    private List<string> UnprocessedDialogueList = new List<string>();

    private List<string> NameList = new List<string>();
    private List<string> DialogueList = new List<string>();

    public List<DialogueBox> TextBoxes = new List<DialogueBox>();

    private int lowerLimit;
    private int higherLimit;

    private List<string> RemoveCommandCharacters(List<string> unprocessed)
    {
        string[] commandCharacters = new string[] { "{", "}" };
        List<string> processedList = new List<string>();
        foreach (string item in unprocessed)
        {
            string newString = item;
            foreach (string i in commandCharacters)
            {
                newString = newString.Replace(i, "");
            }
            processedList.Add(newString);
        }
        return (processedList);
    }

    private void ParseText()
    {
        arrayOfText = Dialgoue.text.Split('\n');

        for (int i = 0; i < arrayOfText.Length - 1; i++)
        {
            switch (arrayOfText[i][0])
            {
                case '<':

                    UnprocessedNameList.Add(arrayOfText[i].Replace("<", ""));
                    break;

                case '{':
                    UnprocessedDialogueList.Add(arrayOfText[i].Replace("{", ""));
                    break;

            }
        }
    }

    private void Start()
    {
        ParseText();

        NameList = UnprocessedNameList;
        DialogueList = UnprocessedDialogueList;


        lowerLimit = 0;
        higherLimit = UnprocessedNameList.Count - TextBoxes.Count ;

        foreach (var item in UnprocessedNameList)
        {
            print(item);
        }
        foreach (var item in UnprocessedDialogueList)
        {
            print(item);
        }

        UpdateText();
    }


    public void UpdateText()
    {
        for (int i = 0; i < TextBoxes.Count; i++)
        {
            TextBoxes[i].NameBox.text = NameList[lowerLimit + i];
            TextBoxes[i].DialogueText.text = DialogueList[lowerLimit + i];
        }

       
    }
    public void MoveUpText()
    {
        if (lowerLimit > 0)
        {
            lowerLimit--;
            UpdateText();
        }
    }
    public void MoveDownText()
    {
        if (lowerLimit < higherLimit)
        {
            lowerLimit++;
            UpdateText();
        }
    }
}
