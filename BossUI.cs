using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Enemies.Bosses.UI
{
    public enum DashAlert
    {
        None,
        Up,
        Down
    }

    public class BossUI : MonoBehaviour
    {
        [SerializeField]
        private GameObject healthBar = default;

        [SerializeField]
        private GameObject alertUp = default;

        [SerializeField]
        private GameObject alertDown = default;

        private Image healthBarFiller = default;

        // Start is called before the first frame update
        void Start()
        {
            if (healthBar)
            {
                healthBar.SetActive(true);
                // The health bar must contain a child named Filler with an Image component
                Transform fillerTransform = healthBar.transform.Find("Filler");
                healthBarFiller = fillerTransform.GetComponent<Image>();
            }
        }

        public void UpdateHealthBar(float scale)
        {
            if (healthBarFiller)
            {
                Vector3 healthBarFillerScale = healthBarFiller.transform.localScale;
                healthBarFillerScale.x = scale;

                healthBarFiller.transform.localScale = healthBarFillerScale;
            }
        }

        public void ShowAlert(DashAlert dashAlert)
        {
            if(dashAlert == DashAlert.Up)
            {
                alertUp.SetActive(true);
            }
            else if(dashAlert == DashAlert.Down)
            {
                alertDown.SetActive(true);
            }
        }

        public void HideAlert(DashAlert dashAlert)
        {
            if (dashAlert == DashAlert.Up)
            {
                alertUp.SetActive(false);
            }
            else if (dashAlert == DashAlert.Down)
            {
                alertDown.SetActive(false);
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}