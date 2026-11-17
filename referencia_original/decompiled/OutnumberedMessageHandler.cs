// Decompiled with JetBrains decompiler
// Type: OutnumberedMessageHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class OutnumberedMessageHandler : MonoBehaviour
{
  private bool 딟;
  private bool 땄;
  public GameObject AcceptButton;
  public GameObject CancelButton;
  public GuiText3D HeaderText;
  public GuiMultiLineText3D BodyText;
  public MenuOverlayHandler OverlayPrefab;
  private MenuOverlayHandler 딟;

  private void Awake()
  {
    this.AcceptButton.SetActive(false);
    this.CancelButton.SetActive(false);
    ((Component) this.HeaderText).gameObject.SetActive(false);
    ((Component) this.BodyText).gameObject.SetActive(false);
    this.딟 = Object.Instantiate((Object) this.OverlayPrefab, new Vector3(0.0f, (float) (((Component) this).transform.position.y - 0.100000001490116), 0.0f), Quaternion.identity) as MenuOverlayHandler;
  }

  public void Init(object[] Params)
  {
    this.BodyText.set_LocTextParms(Params);
    this.땄 = true;
  }

  private void Update()
  {
    if (this.딟 || ((Component) this).animation.isPlaying || !this.땄)
      return;
    this.AcceptButton.SetActive(true);
    this.CancelButton.SetActive(true);
    ((Component) this.HeaderText).gameObject.SetActive(true);
    ((Component) this.BodyText).gameObject.SetActive(true);
    this.HeaderText.UpdateMesh();
    this.BodyText.UpdateMesh();
    this.딟 = true;
  }

  public void OnButtonPressed(string Command)
  {
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (OutnumberedMessageHandler.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      OutnumberedMessageHandler.딟 = new Dictionary<string, int>(2)
      {
        {
          "Close",
          0
        },
        {
          "Store",
          1
        }
      };
    }
    int num;
    // ISSUE: reference to a compiler-generated field
    if (!OutnumberedMessageHandler.딟.TryGetValue(key, out num))
      return;
    switch (num)
    {
      case 0:
        ((Component) this.딟).GetComponent<MenuOverlayHandler>().Close();
        Object.Destroy((Object) ((Component) this).gameObject);
        break;
      case 1:
        ((Component) this.딟).GetComponent<MenuOverlayHandler>().Close();
        Object.Destroy((Object) ((Component) this).gameObject);
        if (GlobalAppData.떏().땥())
        {
          BaseMenuHandler.딟.DeactivateMenu();
          FrontendHub.딟.StoreScreen.ActivateMenu(땃.땽.땓);
          break;
        }
        FrontendHub.딟.LoginHandler.LoginAttempt(true);
        break;
    }
  }
}
