// Decompiled with JetBrains decompiler
// Type: DebugPanelHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class DebugPanelHandler : MonoBehaviour
{
  private GameObject 딟;
  private MenuAnimatorHandler 딟;
  public GameObject Overlay;

  private void Start()
  {
  }

  public void Init(Transform StartPoint, Transform EndPoint)
  {
    this.딟 = ((Component) this).GetComponent<MenuAnimatorHandler>();
    this.딟 = Object.Instantiate((Object) this.Overlay, new Vector3(0.0f, 1.9f, 0.0f), Quaternion.identity) as GameObject;
    this.딟.StartPoint = StartPoint;
    this.딟.EndPoint = EndPoint;
  }

  private void OnButtonPressed(string Command)
  {
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (DebugPanelHandler.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      DebugPanelHandler.딟 = new Dictionary<string, int>(6)
      {
        {
          "LevelUp",
          0
        },
        {
          "LevelDown",
          1
        },
        {
          "UnlockBronze",
          2
        },
        {
          "UnlockSilver",
          3
        },
        {
          "UnlockGold",
          4
        },
        {
          "Back",
          5
        }
      };
    }
    int num;
    // ISSUE: reference to a compiler-generated field
    if (!DebugPanelHandler.딟.TryGetValue(key, out num))
      return;
    switch (num)
    {
      case 0:
        GuiComponent3D.딧();
        break;
      case 1:
        GuiComponent3D.땄();
        break;
      case 2:
        GlobalAppData.땽().딧(1);
        break;
      case 3:
        GlobalAppData.땽().딧(2);
        break;
      case 4:
        GlobalAppData.땽().딧(3);
        break;
      case 5:
        this.Close();
        break;
    }
  }

  public void Close()
  {
    if (Object.op_Inequality((Object) this.딟, (Object) null))
      this.딟.GetComponent<MenuOverlayHandler>().Close();
    this.딟.Close();
  }
}
