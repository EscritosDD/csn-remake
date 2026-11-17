// Decompiled with JetBrains decompiler
// Type: 딧.딠
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace 딧
{
  internal class 딠
  {
    private string 딟;
    private string 땄;
    private List<떍> 딟 = new List<떍>();
    private List<떍> 땄 = new List<떍>();

    public 딠([In] string obj0, [In] string obj1)
    {
      this.딟 = obj0;
      this.땄 = obj1;
    }

    private 떍 딟<딟>([In] Type obj0, [In] Action<땝> obj1) where 딟 : 떍, new()
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      딠.딿<딟> 딿 = new 딠.딿<딟>();
      // ISSUE: reference to a compiler-generated field
      딿.딟 = obj0;
      // ISSUE: reference to a compiler-generated method
      떍 떍 = this.딟.FirstOrDefault<떍>(new Func<떍, bool>(딿.딟));
      if (떍 == null)
      {
        떍 = (떍) new 딟();
        // ISSUE: reference to a compiler-generated field
        떍.딟(딿.딟);
        obj1((땝) 떍);
        this.딟.Add(떍);
      }
      return 떍;
    }

    internal 떍 딟([In] Type obj0_1) => this.딟<딡>(obj0_1, (Action<땝>) (obj0_2 => obj0_2.딟("WriteType")));

    internal 떍 땄([In] Type obj0) => this.딟<딞>(obj0, (Action<땝>) delegate { });

    internal 떍 딧([In] Type obj0) => this.딟<땀>(obj0, (Action<땝>) delegate { });

    internal 떍 딢([In] Type obj0) => this.딟<딖>(obj0, (Action<땝>) delegate { });

    internal 떍 땃([In] Type obj0) => this.딟<딩>(obj0, (Action<땝>) delegate { });

    internal 떍 딶([In] Type obj0) => this.딟<떋>(obj0, (Action<땝>) delegate { });

    internal 떍 땓([In] Type obj0) => this.딟<딴>(obj0, (Action<땝>) delegate { });

    private void 딟([In] 떍 obj0, [In] StringBuilder obj1, [In] int obj2)
    {
      obj0.땄(this, obj1, obj2);
      obj0.딟(true);
    }

    internal void 딟([In] StringBuilder obj0_1)
    {
      obj0_1.AppendLine(string.Format("namespace {0}", (object) this.땄));
      obj0_1.AppendLine("{");
      obj0_1.AppendLine(땹.딟(1) + string.Format("public class {0} : {1}", (object) this.딟, (object) typeof (딾).FullName));
      obj0_1.AppendLine(땹.딟(1) + "{");
      while (true)
      {
        떍 떍 = this.딟.FirstOrDefault<떍>((Func<떍, bool>) (obj0_4 => !obj0_4.땄()));
        if (떍 != null)
          this.딟(떍, obj0_1, 2);
        else
          break;
      }
      this.딟(obj0_1, 2);
      this.땄(obj0_1, 2);
      obj0_1.AppendLine(땹.딟(1) + "}");
      obj0_1.AppendLine("}");
    }

    private void 딟([In] StringBuilder obj0, [In] int obj1)
    {
      foreach (떍 떍 in this.땄)
        obj0.AppendLine(땹.딟(obj1) + string.Format("{0} {1};", (object) 땹.딟(typeof (Action<,>).MakeGenericType(typeof (StringBuilder), 떍.딟())), (object) 떍.딢()));
      obj0.AppendLine();
    }

    private void 땄([In] StringBuilder obj0, [In] int obj1)
    {
      obj0.AppendLine(땹.딟(obj1) + string.Format("public {0}()", (object) this.딟));
      obj0.AppendLine(땹.딟(obj1) + "{");
      foreach (떍 떍 in this.땄)
        떍.딟(this, obj0, obj1 + 1);
      obj0.AppendLine();
      foreach (땝 땝 in this.딟)
      {
        if ((object) 땝.GetType() == (object) typeof (딡))
        {
          string str = this.딟(땝.딟(), true);
          obj0.AppendLine(땹.딟(obj1 + 1) + string.Format("AddSerializer( typeof( {1} ), ( sb, v ) => {0}( sb, v as {1} ) );", (object) str, (object) 땹.딟(땝.딟())));
        }
      }
      obj0.AppendLine(땹.딟(obj1) + "}");
    }

    internal string 딟([In] Type obj0, [In] bool obj1)
    {
      if ((object) obj0 == (object) typeof (object))
        return "SerializeObject";
      if ((object) obj0 == (object) typeof (bool))
        return "SerializeBool";
      if (obj0.IsEnum)
        return this.딟(this.딢(obj0));
      if (obj0.IsPrimitive)
        return this.딟(this.땃(obj0));
      if ((object) obj0 == (object) typeof (string))
        return "SerializeString";
      if (obj0.IsArray)
        return this.딟(this.땓(obj0));
      if ((object) obj0.GetInterface(typeof (IDictionary<,>).FullName) != null)
        return this.딟(this.땄(obj0));
      if (typeof (IDictionary).IsAssignableFrom(obj0))
        return "SerializeDictionary";
      if ((object) obj0.GetInterface(typeof (IEnumerable<>).FullName) != null)
        return this.딟(this.딧(obj0));
      if (typeof (IEnumerable).IsAssignableFrom(obj0))
        return "SerializeEnumerable";
      if (!obj0.IsSerializable)
        throw new NotImplementedException();
      if (obj0.IsValueType)
        return this.딟(this.딶(obj0));
      떍 떍 = this.딟(obj0);
      return obj0.IsSealed || obj1 ? this.딟(떍) : "SerializeObject";
    }

    internal string 딟([In] 떍 obj0)
    {
      if (string.IsNullOrEmpty(obj0.딢()))
      {
        obj0.땄(string.Format("action{0}", (object) this.땄.Count));
        this.땄.Add(obj0);
      }
      return obj0.딢();
    }
  }
}
