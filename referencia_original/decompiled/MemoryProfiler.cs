// Decompiled with JetBrains decompiler
// Type: MemoryProfiler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Runtime.InteropServices;
using UnityEngine;
using 땓;

public class MemoryProfiler : MonoBehaviour
{
  private static int 딟;
  private static int 땄;
  private static int 딧;
  private static int 딢;
  private static int 땃;
  private static bool 딟;
  private static bool 땄;
  private static bool 딧;
  private static Rect 딟 = new Rect(0.0f, 0.0f, 200f, 240f);

  private void OnGUI() => MemoryProfiler.딟 = GUILayout.Window(1, MemoryProfiler.딟, new GUI.WindowFunction((object) this, __methodptr(WindowFunc)), "Profiler", new GUILayoutOption[0]);

  private void WindowFunc(int id)
  {
    GUILayout.Label("Textures " + MemoryProfiler.딟.ToString(), new GUILayoutOption[0]);
    GUILayout.Label("Mesh " + MemoryProfiler.땄.ToString(), new GUILayoutOption[0]);
    GUILayout.Label("Animation " + MemoryProfiler.딧.ToString(), new GUILayoutOption[0]);
    GUILayout.Label("Audio " + MemoryProfiler.딢.ToString(), new GUILayoutOption[0]);
    GUILayout.Label("GC " + MemoryProfiler.땃.ToString(), new GUILayoutOption[0]);
    if (GUILayout.Button("Update", new GUILayoutOption[0]))
      MemoryProfiler.딟 = true;
    if (GUILayout.Button("Dump", new GUILayoutOption[0]))
      MemoryProfiler.땄 = true;
    if (GUILayout.Button("Dump Images", new GUILayoutOption[0]))
      MemoryProfiler.딧 = true;
    GUI.DragWindow();
  }

  private void Update()
  {
    if (MemoryProfiler.딟)
    {
      MemoryProfiler.딟 = MemoryProfiler.딟<Texture>();
      MemoryProfiler.땄 = MemoryProfiler.딟<Mesh>();
      MemoryProfiler.딧 = MemoryProfiler.딟<AnimationClip>();
      MemoryProfiler.딢 = MemoryProfiler.딟<AudioClip>();
      GC.Collect();
      MemoryProfiler.땃 = (int) GC.GetTotalMemory(false);
      MemoryProfiler.딟 = false;
    }
    if (MemoryProfiler.땄)
    {
      this.DumpMemory();
      MemoryProfiler.땄 = false;
    }
    if (!MemoryProfiler.딧)
      return;
    this.DumpImages();
    MemoryProfiler.딧 = false;
  }

  private void DumpImages()
  {
  }

  private void DumpMemory()
  {
    MemoryProfiler.딟<Texture>("TEXTURE MEMORY");
    MemoryProfiler.딟<Mesh>("MESH MEMORY");
    MemoryProfiler.딟<AudioClip>("AUDIO MEMORY");
  }

  private static int 딟<딟>() where 딟 : Object
  {
    int num = 0;
    foreach (Object @object in Resources.FindObjectsOfTypeAll(typeof (딟)))
      num += Profiler.GetRuntimeMemorySize(@object);
    return num;
  }

  public static void 딟<딟>([In] string obj0) where 딟 : Object
  {
    int num = 0;
    Object[] objectsOfTypeAll = Resources.FindObjectsOfTypeAll(typeof (딟));
    딮[] array = new 딮[objectsOfTypeAll.Length];
    for (int index = 0; index < objectsOfTypeAll.Length; ++index)
    {
      array[index] = new 딮();
      array[index].딟 = !string.IsNullOrEmpty(objectsOfTypeAll[index].name) ? objectsOfTypeAll[index].name : "Unnamed";
      int runtimeMemorySize = Profiler.GetRuntimeMemorySize(objectsOfTypeAll[index]);
      array[index].딟 = runtimeMemorySize;
      num += runtimeMemorySize;
    }
    Array.Sort<딮>(array);
    string str = obj0 + "\n";
    for (int index = 0; index < array.Length; ++index)
      str = str + array[index].딟 + " - " + (object) array[index].딟 + "\n";
    Debug.Log((object) (str + "\nTOTAL MEMORY: " + (object) num + "\n\n\n"));
  }
}
