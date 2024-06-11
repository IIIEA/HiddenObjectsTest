using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace WebRequestSystem
{
  public class AssetLoader
  {
    public async UniTask<string> LoadTextAsync(string url)
    {
      UnityWebRequest www = UnityWebRequest.Get(url);
      
      await www.SendWebRequest().ToUniTask();
      
      if (www.result is UnityWebRequest.Result.ConnectionError or UnityWebRequest.Result.ProtocolError)
      {
        Debug.LogError(www.error);

        return string.Empty;
      }

      string jsonText = www.downloadHandler.text;

      return jsonText;
    }

    public async UniTask<Sprite> LoadSpriteAsync(string url)
    {
      UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
      
      await www.SendWebRequest().ToUniTask();
      
      if (www.result is UnityWebRequest.Result.ConnectionError or UnityWebRequest.Result.ProtocolError)
      {
        Debug.LogError(www.error);

        return default;
      }

      var texture = ((DownloadHandlerTexture)www.downloadHandler).texture;
      var sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
      
      return sprite;
    }
  }
}