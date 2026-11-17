// Decompiled with JetBrains decompiler
// Type: 딟.땢
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Runtime.InteropServices;

namespace 딟
{
  [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
  public sealed class 땢 : Attribute
  {
    public bool AllowBlank { get; [param: In] set; }

    public bool IsManifestUnique { get; [param: In] set; }

    public bool IsGameDataUnique { get; [param: In] set; }

    public Type LinkType { get; [param: In] set; }
  }
}
