// Decompiled with JetBrains decompiler
// Type: 땺.딞
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;
using 땥;

namespace 땺
{
  public class 딞
  {
    internal float 딟;
    internal 땨 딟 = new 땨();

    public void 딟([In] 땏 obj0, [In] int obj1)
    {
      switch (obj0.딢())
      {
        case 땙.땄:
          땶 땶 = (땶) obj0;
          this.딟.Clear();
          this.딟.Add(땶.딢());
          this.딟 = 땶.딶();
          break;
        case 땙.딧:
          땖 땖 = (땖) obj0;
          this.딟.Clear();
          this.딟.Add(땖.딢());
          this.딟.Add(땖.땃());
          this.딟 = 땖.딶();
          break;
        case 땙.딢:
          떅 떅 = (떅) obj0;
          this.딟.Clear();
          for (int index = 0; index < 떅.땄.Count; ++index)
            this.딟.Add(떅.땄[index]);
          this.딟 = 떅.딶();
          break;
        case 땙.땃:
          땿 땿 = (땿) obj0;
          this.딟.Clear();
          this.딟.Add(땿.딟[obj1]);
          this.딟.Add(obj1 + 1 >= 땿.딟.Count ? 땿.딟[0] : 땿.딟[obj1 + 1]);
          this.딟 = 땿.딶();
          break;
      }
    }

    public int 딟([In] 떁 obj0)
    {
      int num1 = 0;
      float num2 = 떁.딶(this.딟[0], obj0);
      for (int index = 1; index < this.딟.Count; ++index)
      {
        float num3 = 떁.딶(this.딟[index], obj0);
        if ((double) num3 > (double) num2)
        {
          num1 = index;
          num2 = num3;
        }
      }
      return num1;
    }

    public 떁 땄([In] 떁 obj0)
    {
      int index1 = 0;
      float num1 = 떁.딶(this.딟[0], obj0);
      for (int index2 = 1; index2 < this.딟.Count; ++index2)
      {
        float num2 = 떁.딶(this.딟[index2], obj0);
        if ((double) num2 > (double) num1)
        {
          index1 = index2;
          num1 = num2;
        }
      }
      return this.딟[index1];
    }
  }
}
