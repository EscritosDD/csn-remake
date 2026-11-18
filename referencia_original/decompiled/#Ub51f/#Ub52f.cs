// Decompiled with JetBrains decompiler
// Type: 딟.딯
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 딟
{
  public class 딯
  {
    private List<딡> 딟 = new List<딡>();

    public void 딟([In] 딡 obj0)
    {
      Debug.Log((object) ("Sending Request: " + obj0.땃() + " " + obj0.딢()));
      this.딟.Add(obj0);
      obj0.딟();
    }

    public void 딟()
    {
      int index = 0;
      while (index < this.딟.Count)
      {
        딡 딡 = this.딟[index];
        if (딡.땄())
        {
          딡.딧();
          딡.Dispose();
          this.딟.RemoveAt(index);
        }
        else
          ++index;
      }
    }
  }
}
