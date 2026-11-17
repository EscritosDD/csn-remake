// Decompiled with JetBrains decompiler
// Type: 딧.떔
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace 딧
{
  internal class 떔
  {
    private string 딟;
    private string 땄;
    private List<떓> 딟 = new List<떓>();
    private List<떓> 땄 = new List<떓>();

    public 떔([In] string obj0, [In] string obj1)
    {
      this.딟 = obj0;
      this.땄 = obj1;
    }

    private 떓 딟<딟>([In] Type obj0, [In] Action<딟> obj1) where 딟 : 떓, new()
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      떔.딳<딟> 딳 = new 떔.딳<딟>();
      // ISSUE: reference to a compiler-generated field
      딳.딟 = obj0;
      // ISSUE: reference to a compiler-generated method
      떓 떓 = this.땄.FirstOrDefault<떓>(new Func<떓, bool>(딳.딟));
      if (떓 == null)
      {
        딟 딟 = new 딟();
        떓 = (떓) 딟;
        // ISSUE: reference to a compiler-generated field
        떓.딟(딳.딟);
        obj1(딟);
        this.땄.Add(떓);
      }
      return 떓;
    }

    internal 떓 딟([In] Type obj0_1)
    {
      if (obj0_1.IsPrimitive || (object) obj0_1 == (object) typeof (object))
        throw new InvalidOperationException();
      return this.딟<딛>(obj0_1, (Action<딛>) (obj0_2 => obj0_2.딟(string.Format("ReadType{0}", (object) this.땄.Count))));
    }

    internal string 땄([In] Type obj0)
    {
      if (obj0.IsAbstract)
        throw new InvalidOperationException();
      if ((object) obj0 == (object) typeof (object))
        return this.딟(this.딟());
      if (obj0.IsPrimitive)
        return this.딟(this.딧(obj0));
      if (obj0.IsEnum)
        return this.딟(this.딢(obj0));
      if ((object) obj0 == (object) typeof (string))
        return "ConvertToString";
      if ((object) obj0.GetInterface(typeof (IDictionary<,>).FullName) != null)
        return this.딟(this.땃(obj0));
      if (obj0.IsArray)
        return this.딟(this.땓(obj0));
      if ((object) obj0.GetInterface(typeof (ICollection<>).FullName) != null)
        return this.딟(this.딶(obj0));
      if ((object) obj0 == (object) typeof (DateTime))
        return "ConvertToDateTime";
      떓 떓 = obj0.IsSerializable ? this.딟(obj0) : throw new InvalidOperationException();
      return obj0.IsSealed ? this.딟(떓) : string.Format("DeserializeObject<{0}>", (object) 땹.딟(obj0));
    }

    internal 떓 딟() => this.딟<딣>(typeof (object), (Action<딣>) delegate { });

    internal 떓 딧([In] Type obj0) => this.딟<땔>(obj0, (Action<땔>) delegate { });

    internal 떓 딢([In] Type obj0) => this.딟<땁>(obj0, (Action<땁>) delegate { });

    internal 떓 땃([In] Type obj0) => this.딟<땷>(obj0, (Action<땷>) delegate { });

    internal 떓 딶([In] Type obj0) => this.딟<땘>(obj0, (Action<땘>) delegate { });

    internal 떓 땓([In] Type obj0) => this.딟<딸>(obj0, (Action<딸>) delegate { });

    internal string 딟([In] 떓 obj0)
    {
      if (string.IsNullOrEmpty(obj0.딢()))
      {
        obj0.땄(string.Format("action{0}", (object) this.딟.Count));
        this.딟.Add(obj0);
      }
      return obj0.딢();
    }

    private void 딟([In] 떓 obj0, [In] StringBuilder obj1, [In] int obj2)
    {
      obj0.땄(this, obj1, obj2);
      obj0.딟(true);
    }

    internal void 딟([In] StringBuilder obj0_1)
    {
      obj0_1.AppendLine(string.Format("namespace {0}", (object) this.땄));
      obj0_1.AppendLine("{");
      obj0_1.AppendLine(땹.딟(1) + string.Format("public class {0} : {1}", (object) this.딟, (object) 땹.딟(typeof (딗))));
      obj0_1.AppendLine(땹.딟(1) + "{");
      while (true)
      {
        떓 떓 = this.땄.FirstOrDefault<떓>((Func<떓, bool>) (obj0_4 => !obj0_4.땄()));
        if (떓 != null)
          this.딟(떓, obj0_1, 2);
        else
          break;
      }
      foreach (땝 땝 in this.딟)
        obj0_1.AppendLine(땹.딟(2) + string.Format("private {0} {1};", (object) 땹.딟(typeof (Func<,>).MakeGenericType(typeof (object), 땝.딟())), (object) 땝.딢()));
      obj0_1.AppendLine();
      obj0_1.AppendLine(땹.딟(2) + string.Format("public {0}()", (object) this.딟));
      obj0_1.AppendLine(땹.딟(2) + "{");
      foreach (떓 떓 in this.딟)
        떓.딟(this, obj0_1, 3);
      obj0_1.AppendLine();
      foreach (땝 땝 in this.땄)
      {
        if ((object) 땝.GetType() == (object) typeof (딛))
          obj0_1.AppendLine(땹.딟(3) + string.Format("AddDeserializer( typeof( {1} ), (o) => {0}( o ) );", (object) 땝.딢(), (object) 땹.딟(땝.딟())));
      }
      obj0_1.AppendLine(땹.딟(2) + "}");
      obj0_1.AppendLine(땹.딟(1) + "}");
      obj0_1.AppendLine("}");
    }
  }
}
