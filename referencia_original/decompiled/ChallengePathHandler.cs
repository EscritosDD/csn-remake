// Decompiled with JetBrains decompiler
// Type: ChallengePathHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

public class ChallengePathHandler : MonoBehaviour
{
  public GameObject DotPrefab;
  public GameObject GoldDotPrefab;
  public GameObject LockedDotPrefab;
  public Transform StartPosition;
  public Transform EndPosition;
  public float PathBufferValue;
  public float DotFrequency;

  public void SetState(ChallengePathHandler.딙 State)
  {
    switch (State)
    {
      case ChallengePathHandler.딙.딟:
        this.CreateDottedPath(this.LockedDotPrefab);
        break;
      case ChallengePathHandler.딙.땄:
        this.CreateDottedPath(this.DotPrefab);
        break;
      case ChallengePathHandler.딙.딧:
        this.CreateDottedPath(this.GoldDotPrefab);
        break;
    }
  }

  private void CreateDottedPath(GameObject Prefab)
  {
    if (Object.op_Equality((Object) Prefab, (Object) null))
      return;
    Vector3 vector3_1 = Vector3.op_Subtraction(this.EndPosition.position, this.StartPosition.position);
    float magnitude = ((Vector3) ref vector3_1).magnitude;
    float num1 = magnitude - this.PathBufferValue * 2f;
    int num2 = Mathf.FloorToInt(num1 / this.DotFrequency) + 1;
    float num3 = num1 - (float) (num2 - 1) * this.DotFrequency;
    float num4 = 0.0f;
    for (int index = 0; index < num2; ++index)
    {
      Vector3 vector3_2 = Vector3.Lerp(this.StartPosition.position, this.EndPosition.position, (this.PathBufferValue + num3 / 2f + num4) / magnitude);
      GameObject gameObject = Object.Instantiate((Object) Prefab) as GameObject;
      gameObject.transform.parent = this.StartPosition;
      gameObject.transform.position = vector3_2;
      num4 += this.DotFrequency;
    }
  }

  private void OnDestroy()
  {
    this.DotPrefab = (GameObject) null;
    this.GoldDotPrefab = (GameObject) null;
    this.LockedDotPrefab = (GameObject) null;
  }

  public enum 딙
  {
    딟,
    땄,
    딧,
    딢,
    땃,
  }
}
