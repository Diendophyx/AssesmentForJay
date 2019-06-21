using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PDA1.UI
{
    /// <summary>Provides top-level functionality for handling and switching panels.</summary>
    public class UIController : MonoBehaviour
    {

        public static UIController main { get; private set; }

        // ------------------------------------------------- //

        public UILoginPanel _LoginPanel;

        public UISignUpPanel _SignUpPanel;

        public UIPasswordResetPanel1 _PasswordResetPanel1;

        public UIPasswordResetPanel2 _PasswordResetPanel2;


        // ------------------------------------------------- //

        private UIController()
        {
            if (main == null)
                main = this;
        }

        // ------------------------------------------------- //

        private void Start()
        {
            SwitchToLoginPanel();
        }

        // ------------------------------------------------- //

        // Ideally, I'd use a single method that accepts an enum parameter
        // to determine which panel to show, but the Button component on
        // 

        public void SwitchToSignUpPanel()
        {
            HideAllPanels();
            _SignUpPanel.Show();
        }

        public void SwitchToResetPanel1()
        {
            HideAllPanels();
            _PasswordResetPanel1.Show();
        }

        public void SwitchToResetPanel2(string username, string expectedResetCode)
        {
            HideAllPanels();
            _PasswordResetPanel2.Show();
            _PasswordResetPanel2.TargetUsername = username;
            _PasswordResetPanel2.ExpectedResetCode = expectedResetCode;
        }

        public void SwitchToLoginPanel(string username = null)
        {
            HideAllPanels();

            _LoginPanel.Show();

            // If a username was provided, auto put it in the username field.
            // Then set focus on the password field, so the user can immediately enter it.
            if (username != null) {
                _LoginPanel.usernameField.text = username;
                _LoginPanel.passwordField.Select();
                _LoginPanel.passwordField.ActivateInputField();
            }

        }

        // ------------------------------------------------- //

        public void HideAllPanels()
        {

            _LoginPanel.Hide();
            _SignUpPanel.Hide();
            _PasswordResetPanel1.Hide();
            _PasswordResetPanel2.Hide();

        }

        // ------------------------------------------------- //

    }

}