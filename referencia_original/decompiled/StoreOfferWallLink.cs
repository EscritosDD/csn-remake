// Decompiled with JetBrains decompiler
// Type: StoreOfferWallLink
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;
using 딢;

public class StoreOfferWallLink : MonoBehaviour
{
  public GuiButton3D Button;
  public GameObject BackgroundActive;
  public GameObject BackgroundComplete;
  public 땹 Cookie;
  public string URL;
  public string VoucherName;

  private void OnEnable()
  {
    this.Button.set_CustomPressFunc("OnFollowURL");
    this.Button.set_CustomPressValue((object) null);
    this.UpdateVisuals();
  }

  private void UpdateVisuals()
  {
    if (GlobalAppData.땽().딟(this.Cookie) == 0)
    {
      this.BackgroundActive.SetActive(true);
      this.BackgroundComplete.SetActive(false);
    }
    else
    {
      this.BackgroundActive.SetActive(false);
      this.BackgroundComplete.SetActive(true);
    }
    FrontendHub.딟.StoreScreen.MainScrollList.UpdateItemClipping();
  }

  private void OnFollowURL()
  {
    GlobalAppData.딶(this.URL);
    if (GlobalAppData.땽().딟(this.Cookie) == 0)
    {
      GlobalAppData.땽().딟(this.Cookie, 1, true);
      string str = GlobalAppData.딧().GameSettings.딟(this.VoucherName);
      if (!string.IsNullOrEmpty(str))
        GlobalAppData.땽().땺(str);
    }
    this.UpdateVisuals();
  }
}
