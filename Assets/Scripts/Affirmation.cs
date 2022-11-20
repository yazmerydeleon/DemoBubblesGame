using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Affirmation 
{
    private static List<string> affirmations;
    private static void Load()
    {
        var source = Resources.Load<TextAsset>("motivationalQuotes");
        var lines = source.text.Split(';');

        affirmations = new List<string>(lines.Length-1);

        for (int i = 0; i < lines.Length-1; i++)
        {
            affirmations.Add(lines[i]);
        }
    }

    public static string GetAffirmation(int index)
    {
        return affirmations[index];
    }

    public static int NumberOfAffirmations()
    {
        return affirmations.Count;
    }

    static Affirmation()
    {
        Load();
    }
}
