// Decompiled with JetBrains decompiler
// Type: ConfirmResetPanelHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class ConfirmResetPanelHandler : MonoBehaviour
{
  private void OnButtonPressed(string Command)
  {
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (ConfirmResetPanelHandler.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      ConfirmResetPanelHandler.딟 = new Dictionary<string, int>(2)
      {
        {
          "Accept",
          0
        },
        {
          "Close",
          1
        }
      };
    }
    int num;
    // ISSUE: reference to a compiler-generated field
    if (!ConfirmResetPanelHandler.딟.TryGetValue(key, out num))
      return;
    if (num != 0)
    {
      if (num != 1)
        return;
      this.Close();
    }
    else
    {
      this.Close();
      딶.딡.땴().땢().StartReset(false);
    }
  }

  public void Close() => Object.Destroy((Object) ((Component) this).gameObject);
}
