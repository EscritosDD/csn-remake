// Decompiled with JetBrains decompiler
// Type: CharacterSilhouetteHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

public class CharacterSilhouetteHandler : MonoBehaviour
{
  public GameObject LoadingSpinner;
  public GameObject DownloadingIcon;

  private void Start()
  {
    this.LoadingSpinner.SetActive(true);
    this.DownloadingIcon.SetActive(false);
  }

  public void SetIcons(bool IsDownloading)
  {
    if (IsDownloading)
    {
      if (Object.op_Inequality((Object) this.LoadingSpinner, (Object) null))
        this.LoadingSpinner.SetActive(false);
      if (!Object.op_Inequality((Object) this.DownloadingIcon, (Object) null))
        return;
      this.DownloadingIcon.SetActive(true);
    }
    else
    {
      if (Object.op_Inequality((Object) this.LoadingSpinner, (Object) null))
        this.LoadingSpinner.SetActive(true);
      if (!Object.op_Inequality((Object) this.DownloadingIcon, (Object) null))
        return;
      this.DownloadingIcon.SetActive(false);
    }
  }
}
