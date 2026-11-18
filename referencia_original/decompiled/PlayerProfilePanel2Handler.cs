// Decompiled with JetBrains decompiler
// Type: PlayerProfilePanel2Handler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class PlayerProfilePanel2Handler : MonoBehaviour
{
  private MenuAnimatorHandler 딟;
  private MenuOverlayHandler 딟;
  public MenuOverlayHandler OverlayPrefab;
  public GuiText3D LevelNumberText;
  public GuiText3D AbilityNameText;
  public GuiMultiLineText3D AbilityDescriptionText;
  public UnitAbilityButton AbilityIcon;

  private void Start()
  {
  }

  public void Init(PlayerAbilityEntry Entry, Transform StartPoint, Transform EndPoint)
  {
    this.AbilityIcon.Init(Entry);
    this.LevelNumberText.set_LocTextParms(new object[1]
    {
      (object) (Entry.RequiredLevel + 1)
    });
    this.LevelNumberText.UpdateMesh();
    this.AbilityDescriptionText.LocText = Entry.AbilityInfo.Description;
    this.AbilityDescriptionText.UpdateMesh();
    this.AbilityNameText.LocText = Entry.AbilityInfo.Title;
    this.AbilityNameText.UpdateMesh();
    this.딟 = ((Component) this).GetComponent<MenuAnimatorHandler>();
    this.딟 = Object.Instantiate((Object) this.OverlayPrefab, new Vector3(0.0f, (float) (((Component) this).transform.position.y - 0.100000001490116), 0.0f), Quaternion.identity) as MenuOverlayHandler;
    this.딟.StartPoint = StartPoint;
    this.딟.EndPoint = EndPoint;
  }

  private void OnButtonPressed(string Command)
  {
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (PlayerProfilePanel2Handler.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      PlayerProfilePanel2Handler.딟 = new Dictionary<string, int>(1)
      {
        {
          "Close",
          0
        }
      };
    }
    int num;
    // ISSUE: reference to a compiler-generated field
    if (!PlayerProfilePanel2Handler.딟.TryGetValue(key, out num) || num != 0)
      return;
    this.Close();
  }

  public void Close()
  {
    this.딟.Close();
    this.딟.Close();
  }
}
