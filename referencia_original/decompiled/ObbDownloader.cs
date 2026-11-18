// Decompiled with JetBrains decompiler
// Type: ObbDownloader
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.IO;
using UnityEngine;

public class ObbDownloader : MonoBehaviour
{
  private string 딟;
  private ObbDownloader.땍 딟;
  public string MainMenuSceneName;

  private void Update()
  {
    switch (this.딟)
    {
      case ObbDownloader.땍.딟:
        this.OpenMainScene();
        this.딟 = ObbDownloader.땍.딢;
        break;
    }
  }

  private void OpenMainScene() => Application.LoadLevel(Path.GetFileNameWithoutExtension(this.MainMenuSceneName));

  private enum 땍
  {
    딟,
    땄,
    딧,
    딢,
  }
}
