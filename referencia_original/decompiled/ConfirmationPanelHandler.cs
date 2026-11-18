// Decompiled with JetBrains decompiler
// Type: ConfirmationPanelHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ConfirmationPanelHandler : MonoBehaviour
{
  private Vector3 딟;
  private Vector3 땄;
  private GameObject 딟;
  public GameObject Overlay;
  private MenuAnimatorHandler 딟;
  private ConfirmationPanelHandler.떇 딟;
  private ConfirmationPanelHandler.떇 땄;

  protected void InitialiseConfirmationPanel(
    Vector3 Pos,
    ConfirmationPanelHandler.떇 Confirm,
    ConfirmationPanelHandler.떇 Cancel,
    Transform StartPoint,
    Transform EndPoint)
  {
    this.딟 = Pos;
    this.딟 = Confirm;
    this.땄 = Cancel;
    this.딟 = ((Component) this).GetComponent<MenuAnimatorHandler>();
    if (Object.op_Inequality((Object) this.딟, (Object) null))
    {
      this.딟.StartPoint = StartPoint;
      this.딟.EndPoint = EndPoint;
    }
    this.땄 = this.딟;
    ref Vector3 local = ref this.땄;
    local.y = (__Null) (local.y - 0.0500000007450581);
    this.딟 = Object.Instantiate((Object) this.Overlay, this.땄, Quaternion.identity) as GameObject;
    딶.딡.땴().딟(true, false);
    // ISSUE: reference to a compiler-generated method
    this.set_ConfirmationPanelActive(true);
  }

  private void OnButtonPressed(string Command)
  {
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (ConfirmationPanelHandler.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      ConfirmationPanelHandler.딟 = new Dictionary<string, int>(3)
      {
        {
          "Confirm",
          0
        },
        {
          "Cancel",
          1
        },
        {
          "Back",
          1
        }
      };
    }
    int num;
    // ISSUE: reference to a compiler-generated field
    if (!ConfirmationPanelHandler.딟.TryGetValue(key, out num))
      return;
    if (num != 0)
    {
      if (num != 1)
        return;
      this.땄();
    }
    else
      this.딟();
  }

  public void CloseConfirmationPanel(bool CloseInstantly)
  {
    MenuOverlayHandler component = this.딟.GetComponent<MenuOverlayHandler>();
    if (CloseInstantly)
    {
      if (Object.op_Inequality((Object) component, (Object) null))
        component.CloseInstantly();
    }
    else if (Object.op_Inequality((Object) component, (Object) null))
      component.Close();
    if (Object.op_Inequality((Object) this.딟, (Object) null))
      this.딟.Close();
    else
      Object.Destroy((Object) ((Component) this).gameObject);
    딶.딡.땴().딟(false, false);
    // ISSUE: reference to a compiler-generated method
    this.set_ConfirmationPanelActive(false);
    if (!CloseInstantly || !Object.op_Inequality((Object) this.딟, (Object) null))
      return;
    this.딟.set_LerpVal(0.0f);
  }

  [CompilerGenerated]
  [SpecialName]
  public bool get_ConfirmationPanelActive() => this.딟;

  public delegate void 떇();
}
