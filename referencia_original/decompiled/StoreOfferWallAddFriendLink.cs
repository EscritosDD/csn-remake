// Decompiled with JetBrains decompiler
// Type: StoreOfferWallAddFriendLink
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;
using 딢;

public class StoreOfferWallAddFriendLink : MonoBehaviour
{
  public GuiButton3D Button;
  public GameObject BackgroundActive;
  public GameObject BackgroundComplete;

  private void OnEnable()
  {
    this.Button.set_CustomPressFunc("OnAddFriend");
    this.Button.set_CustomPressValue((object) null);
    this.UpdateVisuals();
  }

  private void UpdateVisuals()
  {
    if (GlobalAppData.땽().딟(땹.땟) == 0)
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

  private void OnAddFriend()
  {
    BaseMenuHandler.딟.DeactivateMenu();
    FrontendHub.딟.ChallengeFriendScreen.ActivateMenu(ChallengeFriendScreenHandler.땯.딧);
  }
}
