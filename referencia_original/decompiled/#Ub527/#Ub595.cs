// Decompiled with JetBrains decompiler
// Type: 딧.떕
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 딧
{
  public class 떕
  {
    public Bounds 딟;
    public List<Bounds> 딟 = new List<Bounds>();

    public void 딟([In] Vector3 obj0, [In] TextAnchor obj1)
    {
      ref Bounds local1 = ref this.딟;
      ((Bounds) ref local1).center = Vector3.op_Addition(((Bounds) ref local1).center, obj0);
      for (int index = 0; index < this.딟.Count; ++index)
      {
        Bounds bounds = this.딟[index];
        TextAnchor textAnchor = obj1;
        if (textAnchor != 4)
        {
          if (textAnchor == 5)
          {
            ref Bounds local2 = ref bounds;
            ((Bounds) ref local2).center = Vector3.op_Addition(((Bounds) ref local2).center, Vector3.op_Subtraction(obj0, new Vector3(0.0f, 0.0f, (float) ((Bounds) ref this.딟).extents.z)));
          }
        }
        else
        {
          ref Bounds local3 = ref bounds;
          ((Bounds) ref local3).center = Vector3.op_Addition(((Bounds) ref local3).center, Vector3.op_Subtraction(obj0, ((Bounds) ref this.딟).extents));
        }
        this.딟[index] = bounds;
      }
    }
  }
}
