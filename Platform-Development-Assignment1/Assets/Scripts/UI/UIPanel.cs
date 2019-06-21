using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace PDA1.UI
{
    /// <summary>Base class that implements common behaviours.</summary>
    public class UIPanel : MonoBehaviour
    {



        // ------------------------------------------------- //

        /// <summary>Makes this panel visible. Can be overriden to extend functionality.</summary>
        public virtual void Show()
        {
            gameObject.SetActive(true);
        }

        /// <summary>Makes this panel invisible. Can be overriden to extend functionality.</summary>
        public virtual void Hide()
        {
            gameObject.SetActive(false);
        }

        // ------------------------------------------------- //

    }

}