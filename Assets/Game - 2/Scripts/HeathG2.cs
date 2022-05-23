using UnityEngine;
using UnityEngine.UI;
class HeathG2 : MonoBehaviour
{
    [SerializeField] int hp;
    [SerializeField] Image imageHP;
    [SerializeField] PlayerG2 player;
    int HP
    {
        get => hp;
        set
        {
            hp -= value;
            imageHP.fillAmount -= (float)value / 10 * 3;
            if (hp <= 0) player.OnDestroy();
        }
    }
    public void Damage(int dps) => HP = dps;
}