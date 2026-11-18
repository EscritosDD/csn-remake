// Decompiled with JetBrains decompiler
// Type: SearchBarHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

public class SearchBarHandler : MonoBehaviour
{
  private DateTime 딟 = DateTime.MaxValue;
  public GameObject ClearButton;
  public GuiTextField3D TextField;

  private void Start()
  {
    this.TextField.add_TextChangedEvent(new GuiTextField3D.딣(this.OnSearchTextChanged));
    this.OnSearchTextChanged();
  }

  private void Update()
  {
    if (this.TextField.get_Text().Length == 0)
      this.ClearButton.SetActive(false);
    if (!(DateTime.Now >= this.딟))
      return;
    ((Component) this).SendMessageUpwards("OnSearch", (object) this.TextField.get_Text().ToString());
    this.딟 = DateTime.MaxValue;
  }

  private void OnEnable() => this.TextField.Clear();

  private void OnSearchTextChanged()
  {
    this.ClearButton.SetActive(this.TextField.get_Text().Length != 0);
    if (this.TextField.get_Text().Length == 0)
      return;
    this.딟 = DateTime.Now.AddSeconds(1.0);
  }

  private void OnButtonPressed(string Command)
  {
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (SearchBarHandler.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      SearchBarHandler.딟 = new Dictionary<string, int>(1)
      {
        {
          "Clear",
          0
        }
      };
    }
    int num;
    // ISSUE: reference to a compiler-generated field
    if (!SearchBarHandler.딟.TryGetValue(key, out num) || num != 0)
      return;
    this.TextField.Clear();
    ((Component) this).SendMessageUpwards("Clear");
  }
}
