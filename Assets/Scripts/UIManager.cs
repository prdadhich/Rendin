using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public CanvasGroup scanPanel;
    public CanvasGroup formPanel;
    public CanvasGroup reviewPanel;

    public TMP_InputField input;
    public ReviewManager reviewManager;

    UIState state = UIState.Scan;
    DefectMarker currentMarker;

    void Awake()
    {
        Instance = this;
        SetState(UIState.Scan);
    }

    void SetState(UIState newState)
    {
        state = newState;

        SetPanel(scanPanel, state == UIState.Scan);
        SetPanel(formPanel, state == UIState.Form);
        SetPanel(reviewPanel, state == UIState.Review);
    }

    void SetPanel(CanvasGroup cg, bool on)
    {
        cg.alpha = on ? 1 : 0;
        cg.interactable = on;
        cg.blocksRaycasts = on;
    }

    public bool IsScanMode => state == UIState.Scan;

    // Called from AR tap
    public void OpenForm(DefectMarker marker)
    {
        currentMarker = marker;
        input.text = "";
        SetState(UIState.Form);
    }

    // Called by Save button
    public void Save()
    {
        var d = new Defect();
        d.pose = currentMarker.pose;
        d.note = input.text;
        d.photo = ScreenCapture.CaptureScreenshotAsTexture();

        DefectStore.Instance.defects.Add(d);

        SetState(UIState.Scan);
    }

    // Called by Review button
    public void ToggleReview()
    {
        if (state == UIState.Review)
        {
            SetState(UIState.Scan);
        }
        else
        {
            SetState(UIState.Review);
            reviewManager.Populate();
        }
    }

}
