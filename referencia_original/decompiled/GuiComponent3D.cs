// Decompiled with JetBrains decompiler
// Type: GuiComponent3D
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

[AddComponentMenu("")]
public class GuiComponent3D : MonoBehaviour
{
  private static Stack<Collider> 딟 = new Stack<Collider>();
  private static bool 딟;
  private static bool 땄;
  private static bool 딧;
  private static GuiComponent3D 딟;
  private static GuiComponent3D 땄;
  private static GuiComponent3D 딧;
  private static bool 딢 = false;
  public GuiComponent3D NextComponent;

  private void OnEnable()
  {
    if (!Object.op_Inequality((Object) this.NextComponent, (Object) null))
      return;
    if (Object.op_Inequality((Object) this.NextComponent.get_PrevComponent(), (Object) null))
    {
      Debug.LogWarning((object) (((Object) this.NextComponent).name + " has multiple components which tab to it"));
    }
    else
    {
      // ISSUE: reference to a compiler-generated method
      this.NextComponent.set_PrevComponent(this);
    }
  }

  public virtual void OnDown(Vector3 Position)
  {
  }

  public virtual void OnRightButtonDown(Vector3 Position)
  {
  }

  public virtual void OnUp(Vector3 Position)
  {
  }

  public virtual void OnRightButtonUp(Vector3 Position)
  {
  }

  public virtual void OnHeld(Vector3 Position)
  {
  }

  public virtual void OnPressed(Vector3 Position)
  {
  }

  public virtual void OnGainedFocus()
  {
  }

  public virtual void OnLostFocus()
  {
  }

  public static void 딟([In] Vector3 obj0, [In] Collider obj1)
  {
    GuiComponent3D.딟.Push(obj1);
    Ray ray = Camera.main.ScreenPointToRay(obj0);
    Collider collider = (Collider) null;
    float num = 1000f;
    foreach (RaycastHit raycastHit in Physics.RaycastAll(ray))
    {
      if (!GuiComponent3D.딟.Contains(((RaycastHit) ref raycastHit).collider) && (double) ((RaycastHit) ref raycastHit).distance < (double) num)
      {
        collider = ((RaycastHit) ref raycastHit).collider;
        num = ((RaycastHit) ref raycastHit).distance;
      }
    }
    if (Object.op_Inequality((Object) collider, (Object) null))
    {
      GuiComponent3D.딟 = ((Component) collider).GetComponent<GuiComponent3D>();
      if (Object.op_Inequality((Object) GuiComponent3D.딟, (Object) null))
      {
        GuiComponent3D.딟.OnDown(obj0);
        GuiComponent3D.딟.OnPressed(obj0);
        GuiComponent3D.딟.OnUp(obj0);
        GuiComponent3D.딟 = (GuiComponent3D) null;
      }
    }
    GuiComponent3D.딟.Pop();
  }

  public static void 딟()
  {
    Vector3 mousePosition = Input.mousePosition;
    Camera camera = !Object.op_Inequality((Object) Camera.main, (Object) null) ? Camera.allCameras[0] : Camera.main;
    if (Input.GetKeyDown((KeyCode) 9) && Object.op_Inequality((Object) GuiComponent3D.땃(), (Object) null))
    {
      if (Input.GetKey((KeyCode) 304) || Input.GetKey((KeyCode) 303))
      {
        if (Object.op_Inequality((Object) GuiComponent3D.땃().get_PrevComponent(), (Object) null))
          GuiComponent3D.딟(GuiComponent3D.땃().get_PrevComponent());
      }
      else if (Object.op_Inequality((Object) GuiComponent3D.땃().NextComponent, (Object) null))
        GuiComponent3D.딟(GuiComponent3D.땃().NextComponent);
    }
    if (Input.GetKeyDown((KeyCode) 8) && 딶.딡.땴() != null && Object.op_Inequality((Object) 딶.딡.땴().땢(), (Object) null))
      딶.딡.땴().땢().OnUndoButtonPressed();
    if (Input.GetKeyDown((KeyCode) 9) && 딶.딡.땴() != null && 딶.딡.땴().딷() != null)
      딶.딡.땴().딷().땝();
    if (Input.GetKeyDown((KeyCode) 292))
      GlobalAppData.땤();
    if (GlobalAppData.딱() && Input.GetKeyDown((KeyCode) 27))
      GlobalAppData.땤();
    bool flag1 = Input.GetKey((KeyCode) 306) && Input.GetKey((KeyCode) 304);
    if (GlobalAppData.딧().AllowDebugInput)
      GuiComponent3D.딟(flag1);
    if (Input.GetMouseButtonDown(0))
    {
      GuiComponent3D.땄 = true;
      RaycastHit raycastHit;
      if (Physics.Raycast(camera.ScreenPointToRay(mousePosition), ref raycastHit))
      {
        GuiComponent3D.딟 = ((Component) ((RaycastHit) ref raycastHit).collider).GetComponent<GuiComponent3D>();
        if (Object.op_Inequality((Object) GuiComponent3D.딟, (Object) null))
          GuiComponent3D.딟.OnDown(Input.mousePosition);
      }
      else
        GuiComponent3D.딟 = (GuiComponent3D) null;
    }
    if (GuiComponent3D.땄)
    {
      if (!Input.GetMouseButton(0))
      {
        GuiComponent3D.땄 = false;
        bool flag2 = true;
        if (Object.op_Inequality((Object) GuiComponent3D.딟, (Object) null))
        {
          RaycastHit raycastHit;
          if (Physics.Raycast(camera.ScreenPointToRay(mousePosition), ref raycastHit))
          {
            GuiComponent3D component = ((Component) ((RaycastHit) ref raycastHit).collider).GetComponent<GuiComponent3D>();
            if (Object.op_Equality((Object) component, (Object) GuiComponent3D.딟))
            {
              component.OnPressed(mousePosition);
              GuiComponent3D.딟(component);
              flag2 = false;
            }
          }
          GuiComponent3D.딟.OnUp(mousePosition);
          GuiComponent3D.딟 = (GuiComponent3D) null;
        }
        if (flag2)
          GuiComponent3D.딟((GuiComponent3D) null);
      }
      else if (Object.op_Inequality((Object) GuiComponent3D.딟, (Object) null))
        GuiComponent3D.딟.OnHeld(mousePosition);
    }
    if (Input.GetMouseButtonDown(1))
    {
      GuiComponent3D.딧 = true;
      RaycastHit raycastHit;
      if (Physics.Raycast(camera.ScreenPointToRay(mousePosition), ref raycastHit))
      {
        GuiComponent3D.땄 = ((Component) ((RaycastHit) ref raycastHit).collider).GetComponent<GuiComponent3D>();
        if (Object.op_Inequality((Object) GuiComponent3D.땄, (Object) null))
          GuiComponent3D.땄.OnRightButtonDown(Input.mousePosition);
      }
    }
    if (GuiComponent3D.딧 && !Input.GetMouseButton(1))
    {
      Screen.lockCursor = false;
      GuiComponent3D.딧 = false;
      if (Object.op_Inequality((Object) GuiComponent3D.땄, (Object) null))
        GuiComponent3D.땄.OnRightButtonUp(mousePosition);
    }
    if (Object.op_Inequality((Object) GuiComponent3D.딧, (Object) null))
    {
      GuiComponent3D.딟(GuiComponent3D.딧);
      GuiComponent3D.딧 = (GuiComponent3D) null;
    }
    if (!GuiComponent3D.딢)
      return;
    GuiComponent3D.딢();
  }

  private static void 딟([In] bool obj0)
  {
    bool flag = false;
    if (obj0)
    {
      if (Input.GetKeyDown((KeyCode) 100))
        딢.딳.딟();
      if (Input.GetKeyDown((KeyCode) 117))
        GlobalAppData.땽().땠();
      if (Input.GetKeyDown((KeyCode) 108))
        GlobalAppData.떏().땭();
      if (Input.GetKeyDown((KeyCode) 104))
      {
        Debug.Log((object) "Toggle HUD Visibility");
        딶.딡.땴().땢().ToggleHUDVisible();
      }
      if (Input.GetKeyDown((KeyCode) 97))
      {
        Debug.Log((object) "Restarting AI turn");
        딶.딡.땴().떁().떂();
      }
      if (Input.GetKeyDown((KeyCode) 107))
      {
        Debug.Log((object) "Kill all enemies");
        딶.딡.땴().땼().땄(딶.딡.땴().땼().딝() != 1 ? 1 : 0);
      }
      if (Input.GetKeyDown((KeyCode) 293))
        딶.딡.땴().땃();
      if (Input.GetKeyDown((KeyCode) 292))
        딶.딡.땴().딶();
      if (Input.GetKeyDown((KeyCode) 291))
        딧.딪.딟();
      if (Input.GetKeyDown((KeyCode) 270))
        GuiComponent3D.딧();
      if (Input.GetKeyDown((KeyCode) 269))
        GuiComponent3D.땄();
      if (Input.GetKeyDown((KeyCode) 114))
      {
        BaseMenuHandler.딟.DeactivateMenu();
        FrontendHub.딟.LootRewardScreen.ActivateMenu();
      }
      if (Input.GetKeyDown((KeyCode) 109))
        GlobalAppData.땽().땴();
      if (Input.GetKeyDown((KeyCode) 111))
        딶.딡.딟((string) null);
      if (Input.GetKeyDown((KeyCode) 116) || Input.touchCount >= 3)
      {
        flag = true;
        if (!GuiComponent3D.딟)
        {
          int num1 = 0;
          int num2 = 0;
          foreach (Texture2D texture2D in Resources.FindObjectsOfTypeAll(typeof (Texture2D)))
          {
            if (texture2D.mipmapCount <= 1)
            {
              int num3;
              int num4;
              if (!Mathf.IsPowerOfTwo(((Texture) texture2D).width) || !Mathf.IsPowerOfTwo(((Texture) texture2D).height))
              {
                int num5 = !Mathf.IsPowerOfTwo(((Texture) texture2D).width) ? Mathf.NextPowerOfTwo(((Texture) texture2D).width) : ((Texture) texture2D).width;
                int num6 = !Mathf.IsPowerOfTwo(((Texture) texture2D).height) ? Mathf.NextPowerOfTwo(((Texture) texture2D).height) : ((Texture) texture2D).height;
                num3 = num5 * num6 * 4;
                num4 = num5 * num6 / 2;
              }
              else
              {
                num3 = ((Texture) texture2D).width * ((Texture) texture2D).height / 2;
                num4 = ((Texture) texture2D).width * ((Texture) texture2D).height / 2;
              }
              num1 += num3;
              num2 += num4;
            }
          }
          Debug.Log((object) ("TextureMemCurrent " + (object) num1));
          Debug.Log((object) ("TextureMemBest " + (object) num2));
        }
      }
    }
    GuiComponent3D.딟 = flag;
  }

  public static void 땄()
  {
    GenericGameplayData genericData = GlobalAppData.딢().GenericData;
    GlobalAppData.땽().딟(-GlobalAppData.땽().딣(), genericData.딟());
    GlobalAppData.땽().땄(false);
  }

  public static void 딧()
  {
    GenericGameplayData genericData = GlobalAppData.딢().GenericData;
    int num1;
    int index1 = genericData.땄(GlobalAppData.땽().딣(), out num1);
    int num2 = genericData.PlayerLevels[index1].RequiredXP - num1;
    int num3;
    if (num2 <= 5)
    {
      int index2 = index1 + 1;
      if (index2 < genericData.PlayerLevels.Length)
      {
        int requiredXp = genericData.PlayerLevels[index2].RequiredXP;
        num3 = num2 + (requiredXp - 5);
      }
      else
        num3 = 0;
    }
    else
      num3 = num2 - 5;
    GlobalAppData.땽().딟(num3, genericData.딟());
    GlobalAppData.땽().땄(false);
  }

  public static void 딟([In] GuiComponent3D obj0)
  {
    if (Object.op_Equality((Object) obj0, (Object) GuiComponent3D.땃()))
      return;
    GuiComponent3D guiComponent3D = GuiComponent3D.땃();
    // ISSUE: reference to a compiler-generated method
    GuiComponent3D.딢((GuiComponent3D) null);
    if (Object.op_Inequality((Object) guiComponent3D, (Object) null))
      guiComponent3D.OnLostFocus();
    // ISSUE: reference to a compiler-generated method
    GuiComponent3D.딢(obj0);
    if (!Object.op_Inequality((Object) GuiComponent3D.땃(), (Object) null))
      return;
    GuiComponent3D.땃().OnGainedFocus();
  }

  public static void 땄([In] GuiComponent3D obj0) => GuiComponent3D.딧 = obj0;

  public static bool 딧([In] GuiComponent3D obj0) => Object.op_Inequality((Object) GuiComponent3D.땃(), (Object) null) && Object.op_Equality((Object) GuiComponent3D.땃(), (Object) obj0);

  private static void 딢()
  {
    Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    Vector3 vector3_1;
    // ISSUE: explicit constructor call
    ((Vector3) ref vector3_1).\u002Ector(-1f, (float) (worldPoint.y - 1.0), (float) worldPoint.z);
    Vector3 vector3_2;
    // ISSUE: explicit constructor call
    ((Vector3) ref vector3_2).\u002Ector(1f, (float) (worldPoint.y - 1.0), (float) worldPoint.z);
    DebugRenderer.딟(vector3_1, vector3_2, "MousePosition");
    Vector3 vector3_3;
    // ISSUE: explicit constructor call
    ((Vector3) ref vector3_3).\u002Ector((float) worldPoint.x, (float) (worldPoint.y - 1.0), -1f);
    Vector3 vector3_4;
    // ISSUE: explicit constructor call
    ((Vector3) ref vector3_4).\u002Ector((float) worldPoint.x, (float) (worldPoint.y - 1.0), 1f);
    DebugRenderer.딟(vector3_3, vector3_4, "MousePosition");
  }

  [CompilerGenerated]
  [SpecialName]
  public static GuiComponent3D 땃() => GuiComponent3D.딢;

  [CompilerGenerated]
  [SpecialName]
  public GuiComponent3D get_PrevComponent() => this.땃;
}
