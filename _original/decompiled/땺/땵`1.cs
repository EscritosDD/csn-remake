// Decompiled with JetBrains decompiler
// Type: 땺.땵`1
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using FarseerPhysics.Collision;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using 땥;

namespace 땺
{
  public class 땵<딟>
  {
    public int 딟;
    public int 땄;
    public List<땛<딟>> 딟;
    public AABB 딟;
    public 땵<딟>[] 딟;

    public 땵([In] AABB obj0, [In] int obj1, [In] int obj2)
    {
      this.딟 = (int) obj0;
      this.딟 = (int) new List<땛<딟>>();
      this.딟 = obj1;
      this.땄 = obj2;
    }

    [SpecialName]
    public bool 딟() => this.딟 != null;

    private int 딟([In] AABB obj0, [In] AABB obj1)
    {
      if (obj0.땃().땄(ref obj1))
        return 1;
      if (obj0.딶().땄(ref obj1))
        return 2;
      if (obj0.땓().땄(ref obj1))
        return 3;
      return obj0.땺().땄(ref obj1) ? 4 : 0;
    }

    public void 딟([In] 땛<딟> obj0)
    {
      if (!this.딟())
      {
        if (((List<땛<딟>>) this.딟).Count >= this.딟 && this.땄 > 0)
        {
          ((List<땛<딟>>) this.딟).Add(obj0);
          this.딟 = (int) new 땵<딟>[4];
          this.딟[0] = (object) new 땵<딟>(this.딟.땃(), this.딟, this.땄 - 1);
          this.딟[1] = (object) new 땵<딟>(this.딟.딶(), this.딟, this.땄 - 1);
          this.딟[2] = (object) new 땵<딟>(this.딟.땓(), this.딟, this.땄 - 1);
          this.딟[3] = (object) new 땵<딟>(this.딟.땺(), this.딟, this.땄 - 1);
          List<땛<딟>> 땛List = new List<땛<딟>>();
          foreach (땛<딟> 땛 in (List<땛<딟>>) this.딟)
          {
            switch (this.딟((AABB) this.딟, (AABB) 땛.딟))
            {
              case 1:
                ((땵<딟>) this.딟[0]).딟(땛);
                continue;
              case 2:
                ((땵<딟>) this.딟[1]).딟(땛);
                continue;
              case 3:
                ((땵<딟>) this.딟[2]).딟(땛);
                continue;
              case 4:
                ((땵<딟>) this.딟[3]).딟(땛);
                continue;
              default:
                땛.딟 = this;
                땛List.Add(땛);
                continue;
            }
          }
          this.딟 = (int) 땛List;
        }
        else
        {
          obj0.딟 = this;
          ((List<땛<딟>>) this.딟).Add(obj0);
        }
      }
      else
      {
        switch (this.딟((AABB) this.딟, (AABB) obj0.딟))
        {
          case 1:
            ((땵<딟>) this.딟[0]).딟(obj0);
            break;
          case 2:
            ((땵<딟>) this.딟[1]).딟(obj0);
            break;
          case 3:
            ((땵<딟>) this.딟[2]).딟(obj0);
            break;
          case 4:
            ((땵<딟>) this.딟[3]).딟(obj0);
            break;
          default:
            obj0.딟 = this;
            ((List<땛<딟>>) this.딟).Add(obj0);
            break;
        }
      }
    }

    public static bool 딟([In] AABB obj0, [In] 떁 obj1, [In] 떁 obj2)
    {
      AABB aabb = new AABB();
      떁.땃(ref obj1, ref obj2, out aabb.LowerBound);
      떁.딢(ref obj1, ref obj2, out aabb.UpperBound);
      if (!AABB.딟(obj0, aabb))
        return false;
      떁 떁1 = obj2 - obj1;
      떁 떁2 = obj1;
      떁 떁3 = new 떁(-떁1.땄, 떁1.딟);
      if ((double) 떁3.땃() == 0.0)
        return true;
      떁3.땓();
      float num1 = 떁.딶(떁2, 떁3);
      떁[] 떁Array = obj0.땥();
      float num2 = 떁.딶(떁Array[0], 떁3) - num1;
      for (int index = 1; index < 4; ++index)
      {
        if (Math.Sign(떁.딶(떁Array[index], 떁3) - num1) != Math.Sign(num2))
          return true;
      }
      return false;
    }

    public void 딟([In] Func<땛<딟>, bool> obj0, [In] ref AABB obj1)
    {
      Stack<땵<딟>> 땵Stack = new Stack<땵<딟>>();
      땵Stack.Push(this);
      while (땵Stack.Count > 0)
      {
        땵<딟> 땵1 = 땵Stack.Pop();
        // ISSUE: cast to a reference type
        if (AABB.땄(ref obj1, (AABB&) ref 땵1.딟))
        {
          foreach (땛<딟> 땛 in (List<땛<딟>>) 땵1.딟)
          {
            // ISSUE: cast to a reference type
            if (AABB.땄(ref obj1, (AABB&) ref 땛.딟) && !obj0(땛))
              return;
          }
          if (땵1.딟())
          {
            foreach (땵<딟> 땵2 in (땵<딟>[]) 땵1.딟)
              땵Stack.Push(땵2);
          }
        }
      }
    }

    public void 딟([In] Func<딮, 땛<딟>, float> obj0, [In] ref 딮 obj1)
    {
      Stack<땵<딟>> 땵Stack = new Stack<땵<딟>>();
      땵Stack.Push(this);
      float num1 = obj1.딟;
      떁 딟 = obj1.딟;
      떁 떁 = 딟 + (obj1.땄 - obj1.딟) * num1;
      while (땵Stack.Count > 0)
      {
        땵<딟> 땵1 = 땵Stack.Pop();
        if (땵<딟>.딟((AABB) 땵1.딟, 딟, 떁))
        {
          foreach (땛<딟> 땛 in (List<땛<딟>>) 땵1.딟)
          {
            if (땵<딟>.딟((AABB) 땛.딟, 딟, 떁))
            {
              딮 딮;
              딮.딟 = obj1.딟;
              딮.땄 = obj1.땄;
              딮.딟 = num1;
              float num2 = obj0(딮, 땛);
              if ((double) num2 == 0.0)
                return;
              if ((double) num2 > 0.0)
              {
                num1 = num2;
                떁 = 딟 + (obj1.땄 - obj1.딟) * num1;
              }
            }
          }
          if (this.딟())
          {
            foreach (땵<딟> 땵2 in (땵<딟>[]) 땵1.딟)
              땵Stack.Push(땵2);
          }
        }
      }
    }

    public void 딟([In] ref List<땛<딟>> obj0)
    {
      obj0.AddRange((IEnumerable<땛<딟>>) this.딟);
      if (!this.딟())
        return;
      foreach (땵<딟> 땵 in (땵<딟>[]) this.딟)
        땵.GetAllNodesR(ref obj0);
    }

    public void 땄([In] 땛<딟> obj0) => ((List<땛<딟>>) obj0.딟.딟).Remove(obj0);

    public void 땄()
    {
      List<땛<딟>> 땛List = new List<땛<딟>>();
      this.GetAllNodesR(ref 땛List);
      this.딧();
      땛List.ForEach(new Action<땛<딟>>(this.딟));
    }

    public void 딧()
    {
      // ISSUE: unable to decompile the method.
    }
  }
}
