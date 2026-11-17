// Decompiled with JetBrains decompiler
// Type: BarracksFilterPanelHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class BarracksFilterPanelHandler : MonoBehaviour
{
  public GameObject Overlay;
  public MenuAnimatorHandler MenuAnim;
  public GuiButton3D AgentFilterButton;
  public GuiButton3D EngineerFilterButton;
  public GuiButton3D MedicFilterButton;
  public GuiButton3D SoldierFilterButton;
  public GameObject AgentIcon;
  public GameObject EngineerIcon;
  public GameObject MedicIcon;
  public GameObject SoldierIcon;
  public float Opacity = 0.5f;
  private GameObject 딟;
  private int 딟;
  private int 땄;
  private int 딧;
  private int 딢;
  private 딧.딼 딟 = new 딧.딼();

  private void Start()
  {
    this.MenuAnim = ((Component) this).GetComponent<MenuAnimatorHandler>();
    this.딟 = Object.Instantiate((Object) this.Overlay, new Vector3(0.0f, 1.1f, 0.0f), Quaternion.identity) as GameObject;
    this.딟 = 0;
    this.땄 = 0;
    this.딧 = 0;
    this.딢 = 0;
  }

  public void Init(List<BarracksScreenHandler.딡> Characters)
  {
    foreach (BarracksScreenHandler.딡 character in Characters)
    {
      switch (character.딝().땁().ClassType)
      {
        case 땓.땅.딟:
          ++this.땄;
          continue;
        case 땓.땅.땄:
          ++this.딧;
          continue;
        case 땓.땅.딧:
          ++this.딢;
          continue;
        case 땓.땅.딢:
          ++this.딟;
          continue;
        default:
          continue;
      }
    }
    this.SetButtonState(this.딟, this.AgentFilterButton, this.AgentIcon);
    this.SetButtonState(this.땄, this.EngineerFilterButton, this.EngineerIcon);
    this.SetButtonState(this.딧, this.MedicFilterButton, this.MedicIcon);
    this.SetButtonState(this.딢, this.SoldierFilterButton, this.SoldierIcon);
  }

  private void SetButtonState(int Number, GuiButton3D Button, GameObject Icon)
  {
    if (Number > 0)
    {
      this.딟.딟(Icon, new Color(1f, 1f, 1f, 1f));
    }
    else
    {
      this.딟.딟(Icon, new Color(1f, 1f, 1f, this.Opacity));
      Button.Disabled = true;
    }
  }

  private void Update()
  {
  }

  public void Close()
  {
    this.딟.GetComponent<MenuOverlayHandler>().Close();
    this.MenuAnim.Close();
  }

  private void OnDestroy() => this.딟.딟();
}
