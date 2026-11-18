// Decompiled with JetBrains decompiler
// Type: LevelIconHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

public class LevelIconHandler : MonoBehaviour
{
  public string LevelID;
  public GameObject[] Nodes;
  public Transform NodeAnchor;
  public Vector3 NodeScale = new Vector3(1f / 625f, 1f / 625f, 1f);

  public void SetNodeState(int State)
  {
    GameObject gameObject = Object.Instantiate((Object) this.Nodes[State]) as GameObject;
    gameObject.transform.parent = this.NodeAnchor;
    gameObject.transform.localPosition = Vector3.zero;
    gameObject.transform.localScale = this.NodeScale;
  }
}
