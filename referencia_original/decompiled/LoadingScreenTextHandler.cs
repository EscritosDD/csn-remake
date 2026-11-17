// Decompiled with JetBrains decompiler
// Type: LoadingScreenTextHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

public class LoadingScreenTextHandler : MonoBehaviour
{
  private const float 딟 = 100f;
  private float 땄;

  private void Update()
  {
    this.땄 += Time.deltaTime * 100f;
    Vector3 vector3;
    // ISSUE: explicit constructor call
    ((Vector3) ref vector3).\u002Ector(0.0f, this.땄, 0.0f);
    ((Component) this).transform.rotation = Quaternion.Euler(vector3);
  }

  private void OnDestroy() => GlobalAppData.땄(((Component) this).gameObject);
}
