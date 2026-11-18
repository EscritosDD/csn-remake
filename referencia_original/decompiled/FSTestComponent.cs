// Decompiled with JetBrains decompiler
// Type: FSTestComponent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class FSTestComponent : MonoBehaviour
{
  private 딝.땲 딟;
  private List<딝.땲> 딟 = new List<딝.땲>();
  private int 딟;

  private void Start()
  {
    this.딟.Add((딝.땲) new 딝.땼(((Component) this).transform));
    this.딟.Add((딝.땲) new 딝.땽(((Component) this).transform));
    this.딟.Add((딝.땲) new 딝.딦(((Component) this).transform));
    this.딟.Add((딝.땲) new 딝.땋(((Component) this).transform));
    this.딟.Add((딝.땲) new 딝.땤(((Component) this).transform));
    this.딟 = this.딟[this.딟];
    this.딟.딟();
  }

  private void Update()
  {
    if (this.딟 != null)
      this.딟.땄();
    if (Input.GetKeyDown((KeyCode) 276))
    {
      this.ChangeTest(-1);
    }
    else
    {
      if (!Input.GetKeyDown((KeyCode) 275))
        return;
      this.ChangeTest(1);
    }
  }

  private void OnGUI()
  {
    if (this.딟 == null)
      return;
    this.딟.땓();
  }

  private void ChangeTest(int val)
  {
    this.딟.딧();
    this.딟 += val;
    if (this.딟 < 0)
      this.딟 = this.딟.Count - 1;
    if (this.딟 >= this.딟.Count)
      this.딟 = 0;
    this.딟 = this.딟[this.딟];
    this.딟.딟();
  }
}
