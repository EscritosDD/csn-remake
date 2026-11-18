// Decompiled with JetBrains decompiler
// Type: 땺.딵
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Runtime.InteropServices;
using System.Text;

namespace 땺
{
  public class 딵
  {
    public 땰 딟;
    protected 땰 땄;
    public 땰 딧;

    public 딵([In] 땰 obj0, [In] 땰 obj1)
    {
      this.딟 = obj0;
      this.딧 = obj1;
      this.땄 = obj0;
      this.딟(obj0);
      this.딟(obj1);
    }

    public void 딟([In] 땰 obj0)
    {
    }

    public void 땄([In] 땰 obj0)
    {
    }

    public override string ToString()
    {
      StringBuilder stringBuilder = new StringBuilder();
      for (땰 딟 = this.딟; 딟 != this.딧; 딟 = 딟.딟)
        stringBuilder.Append(딟.딟.딟).Append("->");
      stringBuilder.Append(this.딧.딟.딟);
      return stringBuilder.ToString();
    }

    private 땰 딟([In] double obj0) => this.땄;

    public 땰 딟([In] 땮 obj0) => this.땄(obj0.딟);

    private 땰 땄([In] double obj0)
    {
      땰 땰 = this.딟(obj0);
      if (obj0 < 땰.딟)
      {
        while ((땰 = 땰.땄) != null)
        {
          if (obj0 >= 땰.딟)
          {
            this.땄 = 땰;
            return 땰;
          }
        }
      }
      else
      {
        while ((땰 = 땰.딟) != null)
        {
          if (obj0 < 땰.딟)
          {
            this.땄 = 땰.땄;
            return 땰.땄;
          }
        }
      }
      return (땰) null;
    }

    public 땰 땄([In] 땮 obj0)
    {
      double 딟1 = obj0.딟;
      땰 땰 = this.딟(딟1);
      double 딟2 = 땰.딟.딟;
      if (딟1 == 딟2)
      {
        if (obj0 != 땰.딟)
        {
          if (obj0 == 땰.땄.딟)
          {
            땰 = 땰.땄;
          }
          else
          {
            if (obj0 != 땰.딟.딟)
              throw new Exception("Failed to find Node for given afront point");
            땰 = 땰.딟;
          }
        }
      }
      else if (딟1 < 딟2)
      {
        while ((땰 = 땰.땄) != null && obj0 != 땰.딟)
          ;
      }
      else
      {
        while ((땰 = 땰.딟) != null && obj0 != 땰.딟)
          ;
      }
      this.땄 = 땰;
      return 땰;
    }
  }
}
