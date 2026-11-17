// Decompiled with JetBrains decompiler
// Type: 땥.딮
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Xml;
using System.Xml.Serialization;

namespace 땥
{
  public class 딮
  {
    private List<딺> 딟 = new List<딺>();
    private List<떀> 딟 = new List<떀>();
    private List<땺.땏> 딟 = new List<땺.땏>();
    private XmlWriter 딟;

    private void 딟([In] 땺.땏 obj0)
    {
      this.딟.WriteStartElement("Shape");
      this.딟.WriteAttributeString("Type", obj0.딢().ToString());
      switch (obj0.딢())
      {
        case 땺.땙.땄:
          땺.땶 땶 = (땺.땶) obj0;
          this.딟.WriteElementString("Radius", 땶.딶().ToString());
          this.딟("Position", 땶.딢());
          break;
        case 땺.땙.딧:
          땺.땖 땖 = (땺.땖) obj0;
          this.딟("Vertex1", 땖.딢());
          this.딟("Vertex2", 땖.땃());
          break;
        case 땺.땙.딢:
          땺.떅 떅 = (땺.떅) obj0;
          this.딟.WriteStartElement("Vertices");
          foreach (떁 떁 in (List<떁>) 떅.땄)
            this.딟("Vertex", 떁);
          this.딟.WriteEndElement();
          this.딟("Centroid", ((땺.땏) 떅).딟.딟);
          break;
        default:
          throw new Exception();
      }
      this.딟.WriteEndElement();
    }

    private void 딟([In] 떀 obj0)
    {
      this.딟.WriteStartElement("Fixture");
      this.딟.WriteElementString("Shape", this.땄(obj0.땃()).ToString());
      this.딟.WriteElementString("Density", obj0.땃().땃().ToString());
      this.딟.WriteStartElement("FilterData");
      this.딟.WriteElementString("CategoryBits", ((int) obj0.딧()).ToString());
      this.딟.WriteElementString("MaskBits", ((int) obj0.땄()).ToString());
      this.딟.WriteElementString("GroupIndex", obj0.딟().ToString());
      this.딟.WriteEndElement();
      this.딟.WriteElementString("Friction", obj0.떎().ToString());
      this.딟.WriteElementString("IsSensor", obj0.딶().ToString());
      this.딟.WriteElementString("Restitution", obj0.떂().ToString());
      if (obj0.땺() != null)
      {
        this.딟.WriteStartElement("UserData");
        this.딟(obj0.땺().GetType(), obj0.땺());
        this.딟.WriteEndElement();
      }
      this.딟.WriteEndElement();
    }

    private void 딟([In] 딺 obj0)
    {
      this.딟.WriteStartElement("Body");
      this.딟.WriteAttributeString("Type", obj0.딧().ToString());
      this.딟.WriteElementString("Active", obj0.떎().ToString());
      this.딟.WriteElementString("AllowSleep", obj0.땥().ToString());
      this.딟.WriteElementString("Angle", obj0.땢().ToString());
      this.딟.WriteElementString("AngularDamping", obj0.땓().ToString());
      this.딟.WriteElementString("AngularVelocity", obj0.땃().ToString());
      this.딟.WriteElementString("Awake", obj0.딝().ToString());
      this.딟.WriteElementString("Bullet", obj0.땺().ToString());
      this.딟.WriteElementString("FixedRotation", obj0.떂().ToString());
      this.딟.WriteElementString("LinearDamping", obj0.딶().ToString());
      this.딟("LinearVelocity", obj0.딢());
      this.딟("Position", obj0.땼());
      if (obj0.땋() != null)
      {
        this.딟.WriteStartElement("UserData");
        this.딟(obj0.땋().GetType(), obj0.땋());
        this.딟.WriteEndElement();
      }
      this.딟.WriteStartElement("Fixtures");
      for (int index = 0; index < obj0.딦().Count; ++index)
        this.딟.WriteElementString("ID", this.땄(obj0.딦()[index]).ToString());
      this.딟.WriteEndElement();
      this.딟.WriteEndElement();
    }

    private void 딟([In] 딝.땺 obj0)
    {
      if (obj0.딝())
        return;
      this.딟.WriteStartElement("Joint");
      this.딟.WriteAttributeString("Type", obj0.딧().ToString());
      this.딟("BodyA", this.땄(obj0.딢()));
      this.딟("BodyB", this.땄(obj0.땃()));
      this.딟("CollideConnected", obj0.땺());
      this.딟("Breakpoint", obj0.딟);
      if (obj0.딶() != null)
      {
        this.딟.WriteStartElement("UserData");
        this.딟(obj0.딶().GetType(), obj0.딶());
        this.딟.WriteEndElement();
      }
      switch (obj0.딧())
      {
        case 딝.딢.딟:
          떒 떒 = (떒) obj0;
          this.딟("EnableLimit", 떒.딶());
          this.딟("EnableMotor", 떒.땥());
          this.딟("LocalAnchorA", 떒.딟);
          this.딟("LocalAnchorB", 떒.땄);
          this.딟("LowerAngle", 떒.땓());
          this.딟("MaxMotorTorque", 떒.떎());
          this.딟("MotorSpeed", 떒.딝());
          this.딟("ReferenceAngle", 떒.딧());
          this.딟("UpperAngle", 떒.땺());
          break;
        case 딝.딢.땄:
          땬 땬 = (땬) obj0;
          this.딟("EnableLimit", 땬.땃());
          this.딟("EnableMotor", 땬.땺());
          this.딟("LocalAnchorA", 땬.딟);
          this.딟("LocalAnchorB", 땬.땄);
          this.딟("LocalXAxis1", 땬.떂());
          this.딟("LowerTranslation", 땬.딶());
          this.딟("UpperTranslation", 땬.땓());
          this.딟("MaxMotorForce", 땬.딝());
          this.딟("MotorSpeed", 땬.땥());
          break;
        case 딝.딢.딧:
          땧 땧 = (땧) obj0;
          this.딟("DampingRatio", 땧.땃());
          this.딟("FrequencyHz", 땧.딢());
          this.딟("Length", 땧.딧());
          this.딟("LocalAnchorA", 땧.딟);
          this.딟("LocalAnchorB", 땧.땄);
          break;
        case 딝.딢.땃:
          throw new Exception("Gear joint not supported by serialization");
        case 딝.딢.땓:
          딝.땄 땄 = (딝.땄) obj0;
          this.딟("LocalAnchorA", 땄.딟);
          this.딟("LocalAnchorB", 땄.땄);
          break;
        case 딝.딢.땺:
          딬 딬 = (딬) obj0;
          this.딟("LocalAnchorA", 딬.딟);
          this.딟("LocalAnchorB", 딬.땄);
          this.딟("MaxForce", 딬.딧());
          this.딟("MaxTorque", 딬.딢());
          break;
        case 딝.딢.땥:
          딝.딟 딟 = (딝.딟) obj0;
          this.딟("DampingRatio", 딟.딶());
          this.딟("FrequencyHz", 딟.땃());
          this.딟("MaxLength", 딟.딧());
          this.딟("MinLength", 딟.딢());
          this.딟("LocalAnchorA", 딟.딟);
          this.딟("LocalAnchorB", 딟.땄);
          break;
        case 딝.딢.딝:
          딼 딼 = (딼) obj0;
          this.딟("BiasFactor", 딼.딟);
          this.딟("MaxImpulse", 딼.땄);
          this.딟("Softness", 딼.딧);
          this.딟("TargetAngle", 딼.딧());
          break;
        case 딝.딢.떎:
          땮 땮 = (땮) obj0;
          this.딟("LocalAnchorA", 땮.땃());
          this.딟("LocalAnchorB", 땮.딶());
          this.딟("MaxLength", 땮.딧());
          break;
        default:
          throw new Exception("Joint not supported");
      }
      this.딟.WriteEndElement();
    }

    private void 딟([In] Type obj0, [In] object obj1)
    {
      this.딟.WriteElementString("Type", obj0.FullName);
      this.딟.WriteStartElement("Value");
      XmlSerializer xmlSerializer = new XmlSerializer(obj0);
      XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
      namespaces.Add(string.Empty, string.Empty);
      xmlSerializer.Serialize(this.딟, obj1, namespaces);
      this.딟.WriteEndElement();
    }

    private void 딟([In] string obj0, [In] 떁 obj1) => this.딟.WriteElementString(obj0, obj1.딟.ToString() + " " + (object) obj1.땄);

    private void 딟([In] string obj0, [In] int obj1) => this.딟.WriteElementString(obj0, obj1.ToString());

    private void 딟([In] string obj0, [In] bool obj1) => this.딟.WriteElementString(obj0, obj1.ToString());

    private void 딟([In] string obj0, [In] float obj1) => this.딟.WriteElementString(obj0, obj1.ToString());

    public void 딟([In] 땱 obj0, [In] Stream obj1)
    {
      this.딟 = XmlWriter.Create(obj1, new XmlWriterSettings()
      {
        Indent = true,
        NewLineOnAttributes = false,
        OmitXmlDeclaration = true
      });
      this.딟.WriteStartElement("World");
      this.딟.WriteAttributeString("Version", "2");
      this.딟("Gravity", obj0.딟);
      this.딟.WriteStartElement("Shapes");
      for (int index1 = 0; index1 < obj0.떂().Count; ++index1)
      {
        딺 딺 = obj0.떂()[index1];
        for (int index2 = 0; index2 < 딺.딦().Count; ++index2)
        {
          떀 떀 = 딺.딦()[index2];
          bool flag = false;
          for (int index3 = 0; index3 < this.딟.Count; ++index3)
          {
            땺.땏 땏 = this.딟[index3];
            if (떀.땃().딟(땏))
            {
              flag = true;
              break;
            }
          }
          if (!flag)
          {
            this.딟(떀.땃());
            this.딟.Add(떀.땃());
          }
        }
      }
      this.딟.WriteEndElement();
      this.딟.WriteStartElement("Fixtures");
      for (int index4 = 0; index4 < obj0.떂().Count; ++index4)
      {
        딺 딺 = obj0.떂()[index4];
        for (int index5 = 0; index5 < 딺.딦().Count; ++index5)
        {
          떀 떀1 = 딺.딦()[index5];
          bool flag = false;
          for (int index6 = 0; index6 < this.딟.Count; ++index6)
          {
            떀 떀2 = this.딟[index6];
            if (떀1.딢(떀2))
            {
              flag = true;
              break;
            }
          }
          if (!flag)
          {
            this.딟(떀1);
            this.딟.Add(떀1);
          }
        }
      }
      this.딟.WriteEndElement();
      this.딟.WriteStartElement("Bodies");
      for (int index = 0; index < obj0.떂().Count; ++index)
      {
        딺 딺 = obj0.떂()[index];
        this.딟.Add(딺);
        this.딟(딺);
      }
      this.딟.WriteEndElement();
      this.딟.WriteStartElement("Joints");
      for (int index = 0; index < obj0.땭().Count; ++index)
        this.딟(obj0.땭()[index]);
      this.딟.WriteEndElement();
      this.딟.WriteEndElement();
      this.딟.Flush();
      this.딟.Close();
    }

    private int 땄([In] 딺 obj0)
    {
      for (int index = 0; index < this.딟.Count; ++index)
      {
        if (this.딟[index] == obj0)
          return index;
      }
      return -1;
    }

    private int 땄([In] 떀 obj0)
    {
      for (int index = 0; index < this.딟.Count; ++index)
      {
        if (this.딟[index].딢(obj0))
          return index;
      }
      return -1;
    }

    private int 땄([In] 땺.땏 obj0)
    {
      for (int index = 0; index < this.딟.Count; ++index)
      {
        if (this.딟[index].딟(obj0))
          return index;
      }
      return -1;
    }
  }
}
