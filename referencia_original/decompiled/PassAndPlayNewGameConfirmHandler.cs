// Decompiled with JetBrains decompiler
// Type: PassAndPlayNewGameConfirmHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class PassAndPlayNewGameConfirmHandler : MonoBehaviour
{
  private MenuAnimatorHandler 딟;
  private PassAndPlayScreen1Handler 딟;
  private SquadPointSelectionScreenHandler 딟;
  private GameObject 딟;
  public GameObject Overlay;

  private void Start() => this.딟 = Object.Instantiate((Object) this.Overlay, new Vector3(0.0f, 0.7f, 0.0f), Quaternion.identity) as GameObject;

  public void Init(
    PassAndPlayScreen1Handler PassAndPlayScreen,
    SquadPointSelectionScreenHandler SquadPointSelectionScreen,
    Transform startPoint,
    Transform endPoint)
  {
    this.딟 = ((Component) this).GetComponent<MenuAnimatorHandler>();
    this.딟 = PassAndPlayScreen;
    this.딟 = SquadPointSelectionScreen;
    this.딟.StartPoint = startPoint;
    this.딟.EndPoint = endPoint;
  }

  private void OnButtonPressed(string Command)
  {
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (PassAndPlayNewGameConfirmHandler.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      PassAndPlayNewGameConfirmHandler.딟 = new Dictionary<string, int>(2)
      {
        {
          "Confirm",
          0
        },
        {
          "Cancel",
          1
        }
      };
    }
    int num;
    // ISSUE: reference to a compiler-generated field
    if (!PassAndPlayNewGameConfirmHandler.딟.TryGetValue(key, out num))
      return;
    if (num != 0)
    {
      if (num != 1)
        return;
      this.딟.Close();
      this.딟.GetComponent<MenuOverlayHandler>().Close();
    }
    else
    {
      this.딟.Close();
      this.딟.GetComponent<MenuOverlayHandler>().Close();
      딢.딳.땄();
      this.딟.ClearMatchList();
      딧.땧 LoadingInfo = new 딧.땧(GlobalAppData.딢().Version, 딶.딹.딟);
      this.딟.DeactivateMenu();
      this.딟.ActivateMenu(true, LoadingInfo, (BaseMenuHandler) this.딟);
    }
  }
}
