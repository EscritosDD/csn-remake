// Decompiled with JetBrains decompiler
// Type: 땓.떁
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 땓
{
  public class 떁 : IDisposable
  {
    private UnitOrientationHandler 딟;
    private float 딟;

    public 떁([In] 딶.딡 obj0, [In] 땦 obj1)
    {
      UnitOrientationHandler orientationHandler = (UnitOrientationHandler) Object.Instantiate((Object) GlobalAppData.딟.GameAssets.UnitOrientationWidget);
      ((Component) orientationHandler).transform.position = Vector3.op_Addition(((Component) obj0.땓().get_Tiles()[obj1.땴().땃, obj1.땴().딶]).transform.position, new Vector3(0.0f, 0.02f, 0.0f));
      foreach (GameObject greyOuterTriangle in orientationHandler.GreyOuterTriangles)
        greyOuterTriangle.SetActive(false);
      this.딟 = orientationHandler;
      this.땄(땊.땄(obj1.땴().딟));
    }

    public void Dispose() => Object.Destroy((Object) ((Component) this.딟).gameObject);

    private void 딟()
    {
      if (!Object.op_Inequality((Object) this.딟, (Object) null))
        return;
      this.딟.CharacterFacingInner.transform.localRotation = Quaternion.Euler(0.0f, this.딟, 0.0f);
      this.딟(this.딟);
    }

    private void 딟([In] float obj0)
    {
      int index = (double) obj0 <= -45.0 || (double) obj0 >= 45.0 ? ((double) obj0 <= 45.0 || (double) obj0 >= 135.0 ? ((double) obj0 <= 135.0 || (double) obj0 >= 225.0 ? 3 : 2) : 1) : 0;
      this.땄();
      this.딟.GreyOuterTriangles[index].SetActive(true);
      this.딟.BlueOuterTriangles[index].SetActive(false);
    }

    private void 땄()
    {
      foreach (GameObject greyOuterTriangle in this.딟.GreyOuterTriangles)
        greyOuterTriangle.SetActive(false);
      foreach (GameObject blueOuterTriangle in this.딟.BlueOuterTriangles)
        blueOuterTriangle.SetActive(true);
    }

    [SpecialName]
    public float 딧() => this.딟;

    [SpecialName]
    public void 땄([In] float obj0)
    {
      this.딟 = obj0;
      this.딟();
    }
  }
}
