using System;
using System.Text.RegularExpressions;
using UnityEngine;

public class StringParser
{ 
    public string HasValue(string text,string searchingValue)
    {
        if (text.Contains(searchingValue))
            return text;
        return null;
    }
    public string GetStringFromEnum(Enum enumName)
    {
        return enumName.ToString().ToLower();
    }
    public string GetStringWithoutNumbers(string text)
    {
        var cleanText = Regex.Replace(text, "_", string.Empty);
       return Regex.Replace(cleanText, @"[\d-]", string.Empty);
    }
    public bool GetSearchingValue(string text, string searchingValue)
    {
        if(text.Contains(searchingValue))
            return true;
        return false;
    }
}