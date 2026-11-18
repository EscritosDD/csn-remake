// Decompiled with JetBrains decompiler
// Type: SceneDataJson
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[딧.딷]
[Serializable]
public sealed class SceneDataJson
{
  [딧.떁(Name = "LanguageSelection")]
  public string LanguageSelection;
  [딧.떁(Name = "Main")]
  public string MainMenu;
  [딧.떁(Name = "Loading")]
  public string LoadingScreen;
  [딧.떁(Name = "Tally")]
  public string TallyScreen;
  [딧.떁(Name = "Tutorial")]
  public string TutorialScreen;

  [SpecialName]
  public string 딟() => this.딟(this.LanguageSelection);

  [SpecialName]
  public string 땄() => this.딟(this.MainMenu);

  [SpecialName]
  public string 딧() => this.딟(this.LoadingScreen);

  [SpecialName]
  public string 딢() => this.딟(this.TallyScreen);

  [SpecialName]
  public string 땃() => this.딟(this.TutorialScreen);

  private string 딟([In] string obj0) => Path.GetFileNameWithoutExtension(obj0);

  [SpecialName]
  public string[] 딶()
  {
    List<string> stringList = new List<string>();
    if (!string.IsNullOrEmpty(this.LanguageSelection))
      stringList.Add(this.LanguageSelection);
    if (!string.IsNullOrEmpty(this.MainMenu))
      stringList.Add(this.MainMenu);
    if (!string.IsNullOrEmpty(this.LoadingScreen))
      stringList.Add(this.LoadingScreen);
    if (!string.IsNullOrEmpty(this.TallyScreen))
      stringList.Add(this.TallyScreen);
    if (!string.IsNullOrEmpty(this.TutorialScreen))
      stringList.Add(this.TutorialScreen);
    return stringList.ToArray();
  }
}
