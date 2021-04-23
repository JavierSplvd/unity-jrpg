using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class StatusEffectsHUD : MonoBehaviour {
    private Image[] children;
    [SerializeField] private UnitSO unit;

    void Awake() {
        children = transform.GetComponentsInChildren<Image>();
        AttackState.OnUpdateStatus += UpdateIfId;
    }

    public void Init(UnitSO unit) {
        this.unit = unit;
        UpdateStatusImages();
    }

    public void UpdateIfId(string[] someIds)
    {
        if(someIds.Contains(unit.unitId))
        {
            UpdateStatusImages();
        }
    }

    private void UpdateStatusImages() {
        children.ToList().ForEach(it => it.color = new Color(0, 0, 0, 0));

        for (int i = 0; i < unit.currentStatusEffect.Length; i++) {
            children[i].color = Color.white;
            children[i].sprite = Resources.Load<Sprite>(unit.currentStatusEffect[i].ToString());
        }
    }
}