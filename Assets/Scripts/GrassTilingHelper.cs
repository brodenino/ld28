using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

[ExecuteInEditMode]
class GrassTilingHelper : MonoBehaviour
{
    Vector3 prevScale = Vector3.zero;


    void Update()
    {
#if UNITY_EDITOR
        if (!EditorApplication.isPlayingOrWillChangePlaymode)
        {
            if (transform.localScale != prevScale)
            {
                prevScale = transform.localScale;

                var material = new Material(renderer.sharedMaterial);
                var texScale = new Vector2(transform.localScale.x, 0) * 2;

                material.SetTextureScale("_MainTex", texScale);
                renderer.material = material;

                EditorUtility.SetDirty(this);
            }
        }
#endif
    }
}
