using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//https://github.com/omidfth

public class PersianUITextUnityUI : MonoBehaviour
{

    private Text textUI;
    [TextArea]
    public string mainText = "دفاع قهرمان را تا 50 درصد افزایش میدهد و او را سریعتر میکند.";

    // Use this for initialization
    private void Start()
    {
        textUI = GetComponent<Text>();
    }

    private string ToRtlParagraph(string text) {
        List<string> lines = new List<string>();
        string[] words = text.Split(' ');
        text = "";
        for (int i = 0; i < words.Length; i++)
        {
            text += RTL.GetText(words[i]) + " ";
        }
        float width = GetComponent<RectTransform>().sizeDelta.x;

        bool ok = false;
        int num = 0;
        int tempI = 0;
        while (!ok)
        {
            num++;
            TextGenerationSettings setting = textUI.GetGenerationSettings(new Vector2(width - 10f, 20.0F));
            TextGenerator generator = new TextGenerator();
            generator.Populate(text, setting);

            int maxSize = generator.characterCountVisible;
            int size = 0;
            bool end = false;
            for (int i = tempI; i < words.Length; i++)
            {
                size += words[i].Length + 1;
                if ((size - 1) > maxSize)
                {
                    string line = "";
                    int lineSize = 0;
                    for (int j = tempI; j < i; j++)
                    {
                        line += (words[j] + " ");
                        lineSize += words[j].Length + 1;
                    }
                    lines.Add(line);
                    if (lineSize != text.Length)
                    {
                        text = text.Substring(lineSize, text.Length - lineSize);
                    }
                    else
                    {
                        text = "";
                    }
                    tempI = i;
                    break;
                }
                else if (i == words.Length - 1)
                {
                    string line = "";
                    int lineSize = 0;
                    for (int j = tempI; j < i + 1; j++)
                    {
                        line += (words[j] + " ");
                        lineSize += words[j].Length + 1;
                    }
                    lines.Add(line);
                    end = true;
                }
            }

            if (end)
            {
                ok = true;
            }
            if (num == 10)
            {
                ok = true;
            }
        }

        text = "";
        for (int i = 0; i < lines.Count; i++)
        {
            text += lines[i] + "\n";
        }
        return text;
    }

    // Update is called once per frame
    private void Update()
    {
        string text = "";
        string[] paragraphs = mainText.Split('\n');
        for (int i = 0; i < paragraphs.Length; i++)
        {
            text += ToRtlParagraph(paragraphs[i]);
        }

        textUI.text = RTL.GetText(text);
    }
}
