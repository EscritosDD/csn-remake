// Decompiled with JetBrains decompiler
// Type: 딟.딟
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 딟
{
  public class 딟 : 땋
  {
    private List<string> 딟 = new List<string>();

    public void 딟()
    {
    }

    public void 땄()
    {
    }

    public void 딟([In] string obj0, [In] Dictionary<string, string> obj1) => this.땄(obj0);

    public void 딟([In] string obj0, [In] double obj1, [In] Dictionary<string, string> obj2) => this.땄(obj0);

    public void 딟([In] string obj0) => this.땄(obj0);

    public void 딟([In] string obj0, [In] string obj1, [In] string obj2, [In] string obj3) => this.땄("ECommerce");

    public void 딟([In] string obj0, [In] int obj1, [In] string obj2, [In] string obj3) => this.땄(string.Format("Timing {0} - {1} - {2}", (object) obj0, (object) obj2, (object) obj3));

    private void 땄([In] string obj0)
    {
      this.딟.Add(obj0);
      if (this.딟.Count <= 5)
        return;
      this.딟.RemoveAt(0);
    }

    public void 딧()
    {
      GUI.skin.box.fontSize = 16;
      for (int index = 0; index < this.딟.Count; ++index)
        GUILayout.Box(this.딟[index], new GUILayoutOption[0]);
    }
  }
}
