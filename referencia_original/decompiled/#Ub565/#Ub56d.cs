// Decompiled with JetBrains decompiler
// Type: 땥.땭
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace 땥
{
  internal class 땭
  {
    private 떂 딟;

    public 땭([In] 떂 obj0) => this.딟 = obj0;

    private 땲 딟([In] 땋 obj0) => this.딟.딟(obj0).딟;

    public List<땲> 땄([In] 땋 obj0)
    {
      List<땲> 땲List = new List<땲>();
      땲List.Add(this.딟(obj0));
      for (int index = 0; (double) obj0.땄.딟 > (double) 땲List[index].땄.딟; ++index)
      {
        if (obj0.딟(땲List[index].땄))
          땲List.Add(땲List[index].딢);
        else
          땲List.Add(땲List[index].땄);
      }
      return 땲List;
    }

    private void 딟([In] 딦 obj0, [In] 떂 obj1)
    {
      if (((떂) obj0).딟.Count == 0)
        this.딟 = obj1;
      else
        obj1.딟((떂) obj0);
    }

    public void 딟([In] 딦 obj0, [In] 땋 obj1, [In] 땲[] obj2)
    {
      땼 땼 = new 땼(obj1, (떂) 딦.딟(obj2[1]), (떂) 딦.딟(obj2[2]));
      떏 떏1 = new 떏(obj1.땄, (떂) 땼, (떂) 딦.딟(obj2[3]));
      떏 떏2 = new 떏(obj1.딟, (떂) 딦.딟(obj2[0]), (떂) 떏1);
      this.딟(obj0, (떂) 떏2);
    }

    public void 땄([In] 딦 obj0, [In] 땋 obj1, [In] 땲[] obj2)
    {
      땼 땼 = new 땼(obj1, (떂) 딦.딟(obj2[1]), (떂) 딦.딟(obj2[2]));
      떏 떏 = new 떏(obj1.딟, (떂) 딦.딟(obj2[0]), (떂) 땼);
      this.딟(obj0, (떂) 떏);
    }

    public void 딧([In] 딦 obj0, [In] 땋 obj1, [In] 땲[] obj2)
    {
      땼 땼 = new 땼(obj1, (떂) 딦.딟(obj2[0]), (떂) 딦.딟(obj2[1]));
      this.딟(obj0, (떂) 땼);
    }

    public void 딢([In] 딦 obj0, [In] 땋 obj1, [In] 땲[] obj2)
    {
      땼 땼 = new 땼(obj1, (떂) 딦.딟(obj2[0]), (떂) 딦.딟(obj2[1]));
      떏 떏 = new 떏(obj1.땄, (떂) 땼, (떂) 딦.딟(obj2[2]));
      this.딟(obj0, (떂) 떏);
    }
  }
}
