// Decompiled with JetBrains decompiler
// Type: RageSvgObject
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

public class RageSvgObject : ScriptableObject
{
  public string Id;
  public List<RageSvgPathElement> Paths;
  public Transform Parent;
  public int PointIdx;
  public Vector3 CursorPos;
  public int GroupId;
  public int PathId;
  public RageSvgStyle Style;
  public RageSvgGradient Gradient;
  public string StyleString;
  public string TransformString;

  private RageSvgObject()
  {
    this.Id = string.Empty;
    this.Paths = new List<RageSvgPathElement>();
    this.Parent = (Transform) null;
    this.PointIdx = 0;
    this.CursorPos = Vector3.zero;
    this.GroupId = 0;
    this.PathId = 0;
    this.Style = RageSvgStyle.딟();
    this.Gradient = (RageSvgGradient) null;
    this.StyleString = string.Empty;
  }

  [SpecialName]
  public int 딟() => this.Paths.Count - 1;

  [SpecialName]
  public RageSvgPathElement 땄() => this.딟() < 0 ? this.Paths[0] : this.Paths[this.딟()];

  public static RageSvgObject 딧() => ScriptableObject.CreateInstance(typeof (RageSvgObject)) as RageSvgObject;

  public void 딟([In] RageSvgPathElement obj0) => this.Paths.Add(obj0);
}
