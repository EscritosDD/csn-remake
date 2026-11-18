// Decompiled with JetBrains decompiler
// Type: TestCoreCollisionEvents
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class TestCoreCollisionEvents : MonoBehaviour
{
  public FSBodyComponent AttachedBody;
  public FSShapeComponent AttachedShape;
  private GUIText 딟;
  private bool 딟;
  private List<땥.떆> 딟;
  private string 딟 = "\nContact Information:\nrestitution: {0}\ntangent speed: {1}\ncontact points: {2}\ncontact normal: {3}\nlocal points: {4}\ndot: {5}\n";

  private void Start()
  {
    this.딟 = new List<땥.떆>();
    this.딟 = ((Component) this).GetComponent<GUIText>();
  }

  private void Update()
  {
    this.Init();
    if (this.딟.Count < 1)
    {
      this.딟.text = "Contact: null";
    }
    else
    {
      string empty = string.Empty;
      float num1 = 0.0f;
      foreach (땥.떆 떆 in this.딟)
      {
        bool flag = 떆.떎();
        string str1 = "none";
        string str2 = "none";
        string str3 = "none";
        float num2 = 0.0f;
        float num3 = 0.0f;
        if (flag)
        {
          땥.떁 떁;
          땥.땂<땥.떁> 땂;
          떆.딟(out 떁, out 땂);
          str1 = string.Format("p0[ {0}, {1} ] p1[ {2}, {3} ]", (object) 땂.딟(0).딟, (object) 땂.딟(0).땄, (object) 땂.딟(1).딟, (object) 땂.딟(1).땄);
          str2 = string.Format("[ {0}, {1} ]", (object) 떁.딟, (object) 떁.땄);
          땥.땂<땺.땕> 딟 = 떆.딟.딟;
          str3 = string.Format("nimpulse[ {0}, {1} ] tanimpulse[ {2}, {3} ]", (object) (float) ((double) 딟.딟(0).딟 / (double) Time.fixedDeltaTime), (object) (float) ((double) 딟.딟(1).딟 / (double) Time.fixedDeltaTime), (object) (float) ((double) 딟.딟(0).땄 / (double) Time.fixedDeltaTime), (object) (float) ((double) 딟.딟(1).땄 / (double) Time.fixedDeltaTime));
          num2 = 땥.떁.딶(땥.떁.땄(-this.AttachedBody.get_PhysicsBody().땼() + 땂.딟(0)), 떁);
          num3 = 땥.떁.딶(땥.떁.땄(-this.AttachedBody.get_PhysicsBody().땼() + 땂.딟(1)), 떁);
          num1 += (float) (1.0 * ((double) 딟.딟(0).딟 / (double) Time.fixedDeltaTime) / 9.80000019073486);
          num1 += (float) (1.0 * ((double) 딟.딟(1).딟 / (double) Time.fixedDeltaTime) / 9.80000019073486);
        }
        empty += string.Format(this.딟, (object) 떆.땄(), (object) 떆.딧(), (object) str1, (object) str2, (object) str3, (object) num2, (object) num3);
      }
      for (int index = 0; index < this.딟.Count; ++index)
      {
        if (!this.딟[index].떎())
        {
          this.딟.RemoveAt(index);
          index = Mathf.Max(0, index - 1);
        }
      }
      float num4 = this.AttachedBody.get_PhysicsBody().딱();
      this.딟.text = "TOTAL WEIGHT: " + ((num1 - num4) * 0.5f + num4).ToString() + "Kg";
      this.딟.text += empty;
    }
  }

  private void OnDrawGizmos()
  {
    if (this.딟 == null)
      return;
    foreach (땥.떆 떆 in this.딟)
    {
      if (!떆.떎())
        break;
      땥.떁 떁;
      땥.땂<땥.떁> 땂;
      떆.딟(out 떁, out 땂);
      Vector3 vector3_1 = 딝.딷.딟(땂.딟(0));
      Vector3 vector3_2 = 딝.딷.딟(땂.딟(1));
      Vector3 vector3_3 = 딝.딷.딟(떁);
      Gizmos.color = Color.red;
      Gizmos.DrawWireSphere(vector3_1, 0.15f);
      Gizmos.DrawLine(vector3_1, Vector3.op_Addition(vector3_1, Vector3.op_Multiply(vector3_3, 2f)));
      Gizmos.color = Color.yellow;
      Gizmos.DrawWireSphere(vector3_2, 0.15f);
      Gizmos.DrawLine(vector3_2, Vector3.op_Addition(vector3_2, Vector3.op_Multiply(vector3_3, 2f)));
    }
  }

  private void Init()
  {
    if (this.딟)
      return;
    this.AttachedBody.get_PhysicsBody().딟(new 딝.딣(this.OnCollisionEvent));
    Debug.Log((object) this.AttachedBody.get_PhysicsBody().딱());
    this.딟 = true;
  }

  private bool OnCollisionEvent(땥.떀 fixtureA, 땥.떀 fixtureB, 땥.떆 contact)
  {
    if (!this.딟.Contains(contact))
      this.딟.Add(contact);
    return true;
  }
}
