// Decompiled with JetBrains decompiler
// Type: RageSvgPathElement
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;
using 땺;

public class RageSvgPathElement : ScriptableObject
{
  public 딥 Spline;
  public GameObject gO;
  public bool IsClosed;
  public bool IsLinear;

  private RageSvgPathElement()
  {
    this.Spline = (딥) null;
    this.gO = (GameObject) null;
    this.IsClosed = false;
    this.IsLinear = false;
  }

  public static RageSvgPathElement 딟() => ScriptableObject.CreateInstance(typeof (RageSvgPathElement)) as RageSvgPathElement;
}
