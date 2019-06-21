using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace PDA1.UI
{
    /// <summary>UI panel for game login.</summary>
    public class UILoginPanel : UIPanel
    {

        public InputField usernameField;
        public InputField passwordField;

        public Text errorText;

        // ------------------------------------------------- //

        private void Start()
        {
            errorText.text = string.Empty;
        }

        private void OnEnable()
        {
            errorText.text = string.Empty;
        }

        // ------------------------------------------------- //

        public void DoLogin()
        {

            var user = usernameField.text;
            var pass = passwordField.text;

            var response = DBContext.Login(usernameField.text, passwordField.text);

            if (response == "Success")
            {
                errorText.text = "Login Successful!";
            }
            else
            {
                errorText.text = response;
            }

        }

        // ------------------------------------------------- //


        // ------------------------------------------------- //


    }

}