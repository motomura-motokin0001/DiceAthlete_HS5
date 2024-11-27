using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour
{
    [Header("シーンのアンロードの対象シーン")]
    public string DestroySceneName;
    [Header("呼び出すシーン")]
    public string SceneLoadName;
    [Header("ロード中に呼ぶ出すシーン")]
    public string EffectSceneName;
    [Header("何秒後にロードするか？(s) ロードシーンと合わせる")]
    public float StockTime = 2f;
    public void SceneLoad()
    {
        
        SceneManager.LoadScene(EffectSceneName,LoadSceneMode.Additive);
        
        StartCoroutine(IE());
    }

IEnumerator IE()
{
    Debug.Log("IE");
    yield return new WaitForSeconds(StockTime);
    SceneManager.LoadScene(SceneLoadName,LoadSceneMode.Additive);
    SceneManager.UnloadSceneAsync(DestroySceneName);
    
    Debug.Log("complete!!");
}
}
