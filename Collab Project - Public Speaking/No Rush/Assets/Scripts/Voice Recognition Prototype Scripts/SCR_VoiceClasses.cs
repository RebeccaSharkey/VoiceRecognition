using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Phrases
{    
    [SerializeField] private List<Phrase> t_phrases;
    private string[] s_phrases;

    public Phrases()
    {
        t_phrases = new List<Phrase>();
        s_phrases = new string[0];
    }
    public Phrases(string placeHolder)
    {
        SetT_Phrases(placeHolder);
    }
    public Phrases(string[] placeHolder)
    {
        SetT_Phrases(placeHolder);
    }

    public List<Phrase> GetT_Phrases()
    {
        return t_phrases;
    }
    public void SetT_Phrases(string placeHolder)
    {
        if (t_phrases != null)
        {
            t_phrases.Clear();
        }
        t_phrases = new List<Phrase>();
        char[] sentenceStoppers = { '.', ',', '!', '?' };
        string[] placeHolderSentences = placeHolder.Split(sentenceStoppers);
        foreach (string placeHolderSentence in placeHolderSentences)
        {
            t_phrases.Add(new Phrase(placeHolderSentence.ToLower()));
        }
        SetS_Phrases();
    }
    public void SetT_Phrases(string[] arrayOfStrings)
    {
        if (t_phrases != null)
        {
            t_phrases.Clear();
        }
        t_phrases = new List<Phrase>();
        for(int i = 0; i < arrayOfStrings.Length; i++)
        {
            t_phrases.Add(new Phrase(arrayOfStrings[i]));
        }
        SetS_Phrases();
    }

    public string[] GetS_Phrases()
    {
        return s_phrases;
    }
    public void SetS_Phrases()
    {
        if (s_phrases != null)
        {
            Array.Clear(s_phrases, 0, s_phrases.Length);
        }
        s_phrases = new string[t_phrases.Count];
        for (int i = 0; i < t_phrases.Count; i++)
        {
            s_phrases[i] = t_phrases[i].GetPhrase();
        }
    }

    public bool CheckIfPresent(string placeHolder)
    {
        foreach (Phrase phrase in t_phrases)
        {
            if (phrase.GetPhrase() == placeHolder)
            {
                return true;
            }
        }

        return false;
    }

    public Phrase GetPhrase(string placeHolder)
    {
        foreach (Phrase phrase in t_phrases)
        {
            if (phrase.GetPhrase() == placeHolder)
            {
                return phrase;
            }
        }

        return t_phrases[0];
    }
    public Phrase GetPhrase(int i)
    {
        if (i < t_phrases.Count)
        {
            return t_phrases[i];
        }
        else
        {
            return null;
        }
    }
    public void SetPhrase(string placeHolder)
    {
        t_phrases.Add(new Phrase(placeHolder));
        SetS_Phrases();
    }
}

[Serializable]
public class Phrase
{
    [SerializeField] private string phrase;
    [SerializeField] private bool count;
    [SerializeField] private bool doSomething;
    [SerializeField] private string thingToDo;
    [SerializeField] private GameObject AICharacter;

    private bool found = false;
    private int timesUsed = 0;

    public Phrase(string placeHolder)
    {
        phrase = placeHolder;
        found = false;
    }

    public void SetPhrase(string placeHolder)
    {
        phrase = placeHolder;
    }
    public string GetPhrase()
    {
        return phrase;
    }

    public void SetFound(bool placeHolder)
    {
        found = placeHolder;
    }
    public bool GetFound()
    {
        return found;
    }

    public void Reset()
    {
        timesUsed = 0;
        found = false;
    }

    public void CheckWord()
    {
        if(count)
        {
            timesUsed++;
        }
        if(doSomething)
        {
            if(thingToDo != null && AICharacter != null)
            {
                AICharacter.GetComponent<SCR_AIConversation>().DoSomething(thingToDo);
            }
        }
    }

    public int GetTimesUsed()
    {
        return timesUsed;
    }
}
