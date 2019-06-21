using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PDA1.UI
{
    /// <summary>UI panel for registering an account.</summary>
    public class UISignUpPanel : UIPanel
    {

        public InputField emailField;
        public InputField usernameField;
        public InputField passwordField;
        public InputField verifyPasswordField;

        public Text errorText;

        // ------------------------------------------------- //

        private void OnEnable()
        {
            Clear();
        }

        private void Clear()
        {
            emailField.text = string.Empty;
            usernameField.text = string.Empty;
            passwordField.text = string.Empty;
            verifyPasswordField.text = string.Empty;
            errorText.text = string.Empty;
        }

        // ------------------------------------------------- //

        public void DoSignUp()
        {
            // Do validation
            if (string.IsNullOrEmpty(emailField.text) ||
                string.IsNullOrEmpty(usernameField.text) ||
                string.IsNullOrEmpty(passwordField.text) ||
                string.IsNullOrEmpty(verifyPasswordField.text)) {
                errorText.text = "All fields must be filled out.";
                return;
            }

            if (passwordField.text != verifyPasswordField.text) {
                errorText.text = "The entered passwords do not match.";
                return;
            }

            // K, GO!
            Debug.Log("Doing sign up...");
            var response = DBContext.CreateUser(usernameField.text, passwordField.text, emailField.text);

            // If successful, switch to login panel with the username already filled.
            if (response == "Success")
                UIController.main.SwitchToLoginPanel(usernameField.text);
            else
            {
                errorText.text = "Error. " + response;
               // Debug.LogError("Failed to create user: \"" + response + "\"");
            }

        }

        // ------------------------------------------------- //

    }

}