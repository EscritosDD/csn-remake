// Decompiled with JetBrains decompiler
// Type: 땃.떄
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace 땃
{
  public class 떄
  {
    public 떈 딟;
    public List<떈> 딟 = new List<떈>();

    public 떄([In] 딶.땖 obj0, [In] 딶.땙 obj1, [In] 떈 obj2)
    {
      떈 떈1 = new 떈(0);
      떈 떈2 = new 떈(1);
      떈 떈3 = new 떈(2);
      떈 떈4 = new 떈(3);
      떈 떈5 = new 떈(4);
      떈 떈6 = new 떈(5);
      떈 떈7 = new 떈(6);
      떈 떈8 = new 떈(7);
      떈 떈9 = new 떈(8);
      떈 떈10 = new 떈(9);
      떈 떈11 = new 떈(10);
      떈 떈12 = new 떈(11);
      떈 떈13 = new 떈(12);
      떈 떈14 = new 떈(13);
      떈 떈15 = new 떈(14);
      떈 떈16 = new 떈(15);
      this.딟.Add(떈1);
      this.딟.Add(떈2);
      this.딟.Add(떈3);
      this.딟.Add(떈4);
      this.딟.Add(떈5);
      this.딟.Add(떈6);
      this.딟.Add(떈7);
      this.딟.Add(떈8);
      this.딟.Add(떈9);
      this.딟.Add(떈10);
      this.딟.Add(떈11);
      this.딟.Add(떈12);
      this.딟.Add(떈13);
      this.딟.Add(떈14);
      this.딟.Add(떈15);
      this.딟.Add(떈16);
      if (obj2 != null)
      {
        for (int index = 0; index < this.딟.Count; ++index)
        {
          if (obj2.땄() == this.딟[index].땄())
          {
            this.딟 = this.딟[index];
            break;
          }
        }
      }
      else
        this.딟 = this.딟[0];
      떈1.딟(new 떌() { 딟 = 떈2 });
      떈1.딟(new 떌() { 딟 = 떈5 });
      떈2.딟(new 떌() { 딟 = 떈3 });
      떈3.딟(new 떌() { 딟 = 떈7 });
      떈5.딟(new 떌() { 딟 = 떈9 });
      떈7.딟(new 떌() { 딟 = 떈8 });
      떈7.딟(new 떌() { 딟 = 떈11 });
      떈8.딟(new 떌() { 딟 = 떈4 });
      떈9.딟(new 떌() { 딟 = 떈10 });
      떈9.딟(new 떌() { 딟 = 떈13 });
      떈10.딟(new 떌() { 딟 = 떈6 });
      떈11.딟(new 떌() { 딟 = 떈12 });
      떈11.딟(new 떌() { 딟 = 떈15 });
      떈12.딟(new 떌() { 딟 = 떈8 });
      떈13.딟(new 떌() { 딟 = 떈14 });
      떈15.딟(new 떌() { 딟 = 떈16 });
    }

    public 떉 딟([In] 떈 obj0) => new 떉()
    {
      딟 = obj0.땄() != 15 ? 0.0f : 1f
    };
  }
}
