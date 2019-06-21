using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PDA1.UI
{
    /// <summary>UI panel for resetting the password on a user account (Part 1)</summary>
    public class UIPasswordResetPanel1 : UIPanel
    {

        public InputField inputField;

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

        public void SendResetCode()
        {
            // Validate inputs
            if (string.IsNullOrEmpty(inputField.text)) {
                errorText.text = "Please enter your e-mail address.";
                return;
            }

            // PHP GetUsernameFromEmail
            var response = DBContext.GetUsernameFromEmail(inputField.text);

            // Show error if no user found
            if (response == "No user found") {
                errorText.text = "Account does not exist.";
                return;
            }

            // Now we have username (retrieved using the entered email address)
            var username = response;

            // Feedback that something is happening
            errorText.text = "Sending reset code...";   // Not an error, lol.

            // Generate a reset code
            var resetCode = WebFunctions.Generate6CharResetCode();

            // Send reset email
            try {
                WebFunctions.SendResetEmail(inputField.text, username, resetCode);
            }
            catch (System.Exception ex)
            {
                errorText.text = "Ex: " + ex.Message;
                return;
            }


            // Go to next password reset panel
            // This is where the user will enter the code we sent to them, and their new password.
            UIController.main.SwitchToResetPanel2(username, resetCode);
        }

        // ------------------------------------------------- //


    }

}