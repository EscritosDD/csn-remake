// Decompiled with JetBrains decompiler
// Type: 땃.땓
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 땃
{
  public class 땓 : Comparer<Transform>
  {
    public override int Compare([In] Transform obj0, [In] Transform obj1)
    {
      SquadSelectionUnitButtonNew componentInChildren1 = ((Component) obj0).GetComponentInChildren<SquadSelectionUnitButtonNew>();
      SquadSelectionUnitButtonNew componentInChildren2 = ((Component) obj1).GetComponentInChildren<SquadSelectionUnitButtonNew>();
      if (componentInChildren1.Character.땁().ClassType == componentInChildren2.Character.땁().ClassType)
      {
        int num = componentInChildren1.Character.떔().CompareTo(componentInChildren2.Character.떔());
        return num == 0 ? componentInChildren1.Character.딳().CompareTo(componentInChildren2.Character.딳()) : num;
      }
      return componentInChildren1.Character.땁().ClassType > componentInChildren2.Character.땁().ClassType ? -1 : 1;
    }
  }
}
