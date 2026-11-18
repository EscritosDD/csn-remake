// Decompiled with JetBrains decompiler
// Type: 땺.땠
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;

namespace 땺
{
  public abstract class 땠
  {
    private static readonly XmlReaderSettings 딟 = new XmlReaderSettings()
    {
      ProhibitDtd = false,
      XmlResolver = (XmlResolver) null,
      IgnoreComments = true,
      IgnoreProcessingInstructions = true
    };

    public static XmlNode 딟([In] string obj0) => 땠.딟((Stream) new MemoryStream(Encoding.Default.GetBytes(obj0)));

    public static XmlNode 딟([In] Stream obj0)
    {
      XmlReader xmlReader = XmlReader.Create(obj0, 땠.딟);
      XmlDocument xmlDocument = new XmlDocument();
      int content = (int) xmlReader.MoveToContent();
      xmlDocument.Load(xmlReader);
      return (XmlNode) xmlDocument;
    }
  }
}
