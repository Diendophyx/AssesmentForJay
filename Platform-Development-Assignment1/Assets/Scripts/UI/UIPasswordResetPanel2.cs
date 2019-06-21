using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PDA1.UI
{
    /// <summary>UI panel for resetting the password on a user account (Part 2)</summary>
    public class UIPasswordResetPanel2 : UIPanel
    {

        public InputField codeField;
        public InputField newPasswordField;
        public InputField verifyPasswordField;
        public Text infoText;

        public string TargetUsername = null;
        public string ExpectedResetCode = null;

        // ------------------------------------------------- //

        private void Start()
        {
            infoText.text = string.Empty;
        }

        private void OnEnable()
        {
            infoText.text = string.Empty;
        }

        // ------------------------------------------------- //

        public void DoPasswordReset()
        {

            // We MUST know the code to check against, and the username to work with.
            if (string.IsNullOrEmpty(TargetUsername) || string.IsNullOrEmpty(ExpectedResetCode)) {
                infoText.text = "Error: target user/code is null";
                return;
            }

            // Check revoery code
            if (string.IsNullOrEmpty(codeField.text) || codeField.text != ExpectedResetCode) {
                infoText.text = "Please enter the expected recovery code.";
                return;
            }

            // Check new password matches verify password
            if (string.IsNullOrEmpty(newPasswordField.text) || string.IsNullOrEmpty(verifyPasswordField.text)) {
                infoText.text = "Please enter your new password twice.";
                return;
            }

            if (newPasswordField.text != verifyPasswordField.text) {
                infoText.text = "The passwords do not match.";
                return;
            }


            // Do it!

            infoText.text = "Resetting password...";

            System.Threading.Thread.Sleep(1400);

            var result = DBContext.ResetPassword(TargetUsername, newPasswordField.text);

            if (result != "Success")
            {
                infoText.text = result;
                return;
            }


            // On done, reset!
            TargetUsername = null;
            ExpectedResetCode = null;

            // Return home to login
            UIController.main.SwitchToLoginPanel(TargetUsername);
    }

    // ------------------------------------------------- //

}

}