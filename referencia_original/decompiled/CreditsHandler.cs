// Decompiled with JetBrains decompiler
// Type: CreditsHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class CreditsHandler : BaseMenuHandler
{
  private bool 딟;
  public CreditsEntryHandlerList[] EntryPrefabLists;
  public GuiScrollList3D List;
  public float ScrollStartDelay;
  private float 딟;
  public float Offset;

  private void Start() => base.딟 = ((Component) this).transform.position;

  private void Update()
  {
    if (!this.딟)
      return;
    this.딟 += Time.deltaTime;
    if ((double) this.딟 <= (double) this.ScrollStartDelay)
      return;
    if ((double) this.List.get_Offset() < -(double) this.List.get_TotalOffset())
      this.List.SetOffset(this.Offset);
    this.List.Scroll(-0.1f * Time.deltaTime);
  }

  private void OnButtonPressed(string Command)
  {
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (CreditsHandler.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      CreditsHandler.딟 = new Dictionary<string, int>(1)
      {
        {
          "Back",
          0
        }
      };
    }
    int num;
    // ISSUE: reference to a compiler-generated field
    if (!CreditsHandler.딟.TryGetValue(key, out num) || num != 0)
      return;
    ((Component) FrontendHub.딟.MoneyDisplay).gameObject.SetActive(true);
    BaseMenuHandler.땄.ActivateMenu();
    this.DeactivateMenu();
  }

  public override void ActivateMenu()
  {
    base.ActivateMenu();
    this.딟 = true;
    this.딟 = 0.0f;
    this.List.SetOffset(this.Offset);
    this.List.NoRoundToPixel = true;
    for (int index1 = 0; index1 < this.EntryPrefabLists.Length; ++index1)
    {
      if (!Object.op_Equality((Object) this.EntryPrefabLists[index1], (Object) null))
      {
        for (int index2 = 0; index2 < this.EntryPrefabLists[index1].Entries.Length; ++index2)
        {
          CreditsEntryHandler entry = this.EntryPrefabLists[index1].Entries[index2];
          if (Object.op_Inequality((Object) entry, (Object) null))
          {
            CreditsEntryHandler creditsEntryHandler = Object.Instantiate((Object) entry) as CreditsEntryHandler;
            this.List.AddItem(((Component) creditsEntryHandler).transform, (float) ((double) creditsEntryHandler.Spacing * 0.5 / 320.0));
          }
        }
      }
    }
    ((Component) FrontendHub.딟.MoneyDisplay).gameObject.SetActive(false);
  }

  public override void DeactivateMenu()
  {
    this.딟 = false;
    this.List.RemoveAll(true);
    base.DeactivateMenu();
  }
}
