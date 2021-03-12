using TMPro;
using UnityEngine;

public class DamageLogText : MonoBehaviour
{
    private TMP_Text textElement;
    [SerializeField] private string unitId;

    private UnityUtilities.Countdown timer = new UnityUtilities.Countdown(false, 0.6f);

    void Awake()
    {
        textElement = GetComponent<TMP_Text>();
        DamageLogger.OnDamageDealt += ShowText;
        textElement.text = "";
    }

    void FixedUpdate() {
        if(timer.Progress())
        {
            textElement.text = "";
        }
    }

    private void ShowText(string u, int i)
    {
        if(unitId.Equals(u))
        {
            LeanTween.scale(gameObject, Vector3.one * 2, 0.6f).setEasePunch().setOnComplete(ResetScale);
            textElement.text = i > 0? "+" + i.ToString() : i.ToString();
            timer.Reset();
        }
    }

    private void ResetScale()
    {
        transform.localScale = Vector3.one;
    }

    public void SetId(string unitId) => this.unitId = unitId;
}