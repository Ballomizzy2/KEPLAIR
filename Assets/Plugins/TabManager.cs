using UnityEngine;
using System.Runtime.InteropServices;

public class TabManager : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void OpenUnfocusedTab(string url);

    public static void OpenURLUnfocused(string url)
    {
#if UNITY_WEBGL && !UNITY_EDITOR
    OpenUnfocusedTab(url); //this part will be work on build
#else
        Application.OpenURL(url); // this part is for editor
#endif
    }
}


