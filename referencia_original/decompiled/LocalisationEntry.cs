// Decompiled with JetBrains decompiler
// Type: LocalisationEntry
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using SplashDamage.Mobile.Text;
using System.Runtime.InteropServices;
using UnityEngine;

public class LocalisationEntry : ScriptableObject
{
  private static string 딟 = "bad param count";
  public LanguageEntries Entries;
  public int NumParameters;
  public int NumVariables;
  public string[] VariableNames;
  public int[] VariableValues;

  public string 딟([In] 딧.땗 obj0) => this.딟(obj0, true);

  public string 딟([In] 딧.땗 obj0, [In] bool obj1)
  {
    switch (obj0)
    {
      case 딧.땗.땄:
        return this.Entries.French;
      case 딧.땗.딧:
        return this.Entries.German;
      case 딧.땗.딢:
        return this.Entries.Italian;
      case 딧.땗.땃:
        return this.Entries.Spanish;
      case 딧.땗.딶:
        return this.Entries.Russian;
      case 딧.땗.땓:
        return this.Entries.Portuguese;
      case 딧.땗.땺:
        return obj1 && string.IsNullOrEmpty(this.Entries.EnglishWeb) ? this.Entries.English : this.Entries.EnglishWeb;
      case 딧.땗.땥:
        return obj1 && string.IsNullOrEmpty(this.Entries.FrenchWeb) ? this.Entries.French : this.Entries.FrenchWeb;
      case 딧.땗.딝:
        return obj1 && string.IsNullOrEmpty(this.Entries.GermanWeb) ? this.Entries.German : this.Entries.GermanWeb;
      case 딧.땗.떎:
        return obj1 && string.IsNullOrEmpty(this.Entries.ItalianWeb) ? this.Entries.Italian : this.Entries.ItalianWeb;
      case 딧.땗.떂:
        return obj1 && string.IsNullOrEmpty(this.Entries.SpanishWeb) ? this.Entries.Spanish : this.Entries.SpanishWeb;
      case 딧.땗.땭:
        return obj1 && string.IsNullOrEmpty(this.Entries.RussianWeb) ? this.Entries.Russian : this.Entries.RussianWeb;
      case 딧.땗.딦:
        return obj1 && string.IsNullOrEmpty(this.Entries.PortugueseWeb) ? this.Entries.Portuguese : this.Entries.PortugueseWeb;
      default:
        return this.Entries.English;
    }
  }

  public void 딟([In] 딧.땗 obj0, [In] string obj1)
  {
    switch (obj0)
    {
      case 딧.땗.딟:
        this.Entries.English = obj1;
        break;
      case 딧.땗.땄:
        this.Entries.French = obj1;
        break;
      case 딧.땗.딧:
        this.Entries.German = obj1;
        break;
      case 딧.땗.딢:
        this.Entries.Italian = obj1;
        break;
      case 딧.땗.땃:
        this.Entries.Spanish = obj1;
        break;
      case 딧.땗.딶:
        this.Entries.Russian = obj1;
        break;
      case 딧.땗.땓:
        this.Entries.Portuguese = obj1;
        break;
      case 딧.땗.땺:
        this.Entries.EnglishWeb = obj1;
        break;
      case 딧.땗.땥:
        this.Entries.FrenchWeb = obj1;
        break;
      case 딧.땗.딝:
        this.Entries.GermanWeb = obj1;
        break;
      case 딧.땗.떎:
        this.Entries.ItalianWeb = obj1;
        break;
      case 딧.땗.떂:
        this.Entries.SpanishWeb = obj1;
        break;
      case 딧.땗.땭:
        this.Entries.RussianWeb = obj1;
        break;
      case 딧.땗.딦:
        this.Entries.PortugueseWeb = obj1;
        break;
    }
  }

  public string 딟([In] 딧.땗 obj0, [In] object[] obj1)
  {
    int num = obj1 != null ? obj1.Length : 0;
    if (this.NumParameters != num)
      return "<" + LocalisationEntry.딟 + "! had: " + num.ToString() + ", needs: " + this.NumParameters.ToString() + ">";
    if (obj0 == 딧.땗.땤)
      return "<unknown>";
    string format = this.딟(obj0);
    if (obj1 != null)
      return string.Format(format, obj1);
    if (this.VariableValues == null || this.VariableValues.Length == 0)
      return string.Format(format);
    object[] objArray = new object[this.VariableValues.Length];
    for (int index = 0; index < objArray.Length; ++index)
      objArray[index] = (object) this.VariableValues[index];
    return string.Format(format, objArray);
  }
}
