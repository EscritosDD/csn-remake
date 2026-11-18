// Decompiled with JetBrains decompiler
// Type: GameUpdateConfirmPrompt
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class GameUpdateConfirmPrompt : MonoBehaviour
{
  private GameUpdateConfirmPrompt.땎 딟;
  private GameUpdateConfirmPrompt.땎 땄;

  public void Init(GameUpdateConfirmPrompt.땎 Update, GameUpdateConfirmPrompt.땎 Cancel)
  {
    this.딟 = Update;
    this.땄 = Cancel;
  }

  private void OnButtonPressed(string Command)
  {
    string key = Command;
    if (key != null)
    {
      // ISSUE: reference to a compiler-generated field
      if (GameUpdateConfirmPrompt.딟 == null)
      {
        // ISSUE: reference to a compiler-generated field
        GameUpdateConfirmPrompt.딟 = new Dictionary<string, int>(2)
        {
          {
            "Cancel",
            0
          },
          {
            "Update",
            1
          }
        };
      }
      int num;
      // ISSUE: reference to a compiler-generated field
      if (GameUpdateConfirmPrompt.딟.TryGetValue(key, out num))
      {
        switch (num)
        {
          case 0:
            this.땄();
            break;
          case 1:
            this.딟();
            break;
        }
      }
    }
    Object.Destroy((Object) ((Component) this).gameObject);
  }

  public delegate void 땎();
}
