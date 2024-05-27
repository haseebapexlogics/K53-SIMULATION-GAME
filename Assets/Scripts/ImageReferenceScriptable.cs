using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ImageReferenceScriptable", order = 1)]
public class ImageReferenceScriptable : ScriptableObject
{
    public Sprite[] Sprites;

    // Start is called before the first frame update
    public Sprite Get_Image(string name)
    {
        foreach (Sprite sp in Sprites)
        {
            if (sp.name == name)
            {
                return sp;
            }
        }
        return null;
    }
    
}
