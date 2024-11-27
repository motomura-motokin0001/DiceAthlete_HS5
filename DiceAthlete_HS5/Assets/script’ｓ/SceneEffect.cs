using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class SceneEffect : MonoBehaviour
{
    public Image EffectImage;
    public Image Load;
    public Image LoadCircle;
    public string DestroySceneName;
    public float EffectIN = 1f;
    public float EffectOUT =1f;


    public void Start()
    {
        var sequence = DOTween.Sequence();

        sequence.Append(EffectImage.DOFade(1f,EffectIN));//フィードイン
        sequence.Join(Load.DOFade(0.8f,EffectIN));
        sequence.Join(LoadCircle.DOFade(0.8f,EffectIN));

        sequence.AppendInterval(0.3f);//待機

        sequence.Join(LoadCircle.transform.DORotate(Vector3.forward * 1800f, 2f, RotateMode.LocalAxisAdd));//ロードの演出

        sequence.AppendInterval(0.3f);//待機

        sequence.Append(EffectImage.DOFade(0f,EffectOUT+0.5f));//フィードアウト
        sequence.Join(LoadCircle.DOFade(0f,EffectOUT));
        sequence.Join(Load.DOFade(0f,EffectOUT).OnComplete(destroy));
    }


    void destroy()
    {
        SceneManager.UnloadSceneAsync(DestroySceneName);
        Debug.Log("destroy～");
    }

}
