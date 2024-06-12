using TMPro;
using UnityEngine;

namespace Infrastructure.ApplicationLoader
{
  public sealed class LoadingScreen : MonoBehaviour
  {
    public static LoadingScreen Instance;

    [SerializeField] private TMP_Text _errorText;
    [SerializeField] private LoadingProgressBar _progressBar;
    [SerializeField] private ApplicationLoader _applicationLoader;
    
    private void Awake()
    {
      Instance = this;
      _errorText.text = string.Empty;
      _progressBar.SetProgress(0.0f);
    }

    private void OnEnable() => 
      _applicationLoader.OnProgressChanged += OnProgressChanged;

    private void OnDisable() => 
      _applicationLoader.OnProgressChanged -= OnProgressChanged;

    private void OnProgressChanged(float progress) => 
      ReportProgress(progress);

    private void OnDestroy() => 
      Instance = null;

    public static void Show() => 
      Instance.gameObject.SetActive(true);

    public static void ReportProgress(float progress) => 
      Instance._progressBar.SetProgress(progress);

    public static void Hide() => 
      Instance.gameObject.SetActive(false);

    public static void ReportError(string message) => 
      Instance._errorText.text = message;
  }
}