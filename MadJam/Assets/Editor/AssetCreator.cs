using UnityEngine;
using UnityEditor;
public class AssetCreator
{
  [MenuItem("Assets/Create/Conversation Data")]
  public static void CreateConversationData ()
  {
    ScriptableObjectUtility.CreateAsset<ConversationData> ();
  }

  [MenuItem("Assets/Create/World")]
  public static void CreateWorld ()
  {
    ScriptableObjectUtility.CreateAsset<WorldData> ();
  }
}