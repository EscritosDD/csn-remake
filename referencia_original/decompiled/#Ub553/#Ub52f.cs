// Decompiled with JetBrains decompiler
// Type: 땓.딯
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;
using UnityEngine;

namespace 땓
{
  public class 딯
  {
    public static void 딟([In] GameObject obj0, [In] Transform obj1)
    {
      if (Object.op_Equality((Object) obj1, (Object) null))
        return;
      Transform transform = (Transform) Object.Instantiate((Object) obj1);
      foreach (SkinnedMeshRenderer componentsInChild in ((Component) transform).GetComponentsInChildren<SkinnedMeshRenderer>())
        딯.딟(obj0, componentsInChild);
      Object.Destroy((Object) ((Component) transform).gameObject);
    }

    public static void 딟([In] GameObject obj0, [In] GameObject obj1)
    {
      if (Object.op_Equality((Object) obj1, (Object) null))
        return;
      GameObject gameObject = Object.Instantiate((Object) obj1) as GameObject;
      foreach (SkinnedMeshRenderer componentsInChild in gameObject.GetComponentsInChildren<SkinnedMeshRenderer>())
        딯.딟(obj0, componentsInChild);
      Object.Destroy((Object) gameObject.gameObject);
    }

    private static void 딟([In] GameObject obj0, [In] SkinnedMeshRenderer obj1)
    {
      GameObject gameObject = new GameObject(((Object) ((Component) obj1).gameObject).name);
      SkinnedMeshRenderer skinnedMeshRenderer = gameObject.AddComponent<SkinnedMeshRenderer>();
      Transform[] transformArray = new Transform[obj1.bones.Length];
      for (int index = 0; index < obj1.bones.Length; ++index)
        transformArray[index] = 딯.딟(((Object) obj1.bones[index]).name, obj0.transform);
      gameObject.transform.parent = obj0.transform;
      skinnedMeshRenderer.bones = transformArray;
      skinnedMeshRenderer.sharedMesh = obj1.sharedMesh;
      ((Renderer) skinnedMeshRenderer).materials = ((Renderer) obj1).materials;
    }

    private static Transform 딟([In] string obj0, [In] Transform obj1)
    {
      if (((Object) obj1).name == obj0)
        return ((Component) obj1).transform;
      foreach (Transform transform1 in obj1)
      {
        Transform transform2 = 딯.딟(obj0, transform1);
        if (Object.op_Inequality((Object) transform2, (Object) null))
          return transform2;
      }
      return (Transform) null;
    }
  }
}
