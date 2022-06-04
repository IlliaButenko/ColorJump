using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using LitJson;
using UnityEngine.SceneManagement;

public class UserData {
    #region ***** DATA *****

    //   public  string device_token;
    public string username;
    public string email_address;
    public string name;
    public string password;
    public string verification_code;
    public string balance;
    public string level;

    #endregion
}

public class Login : MonoBehaviour {
    UserData userData = new UserData();

    public TMP_Text info_errorText;

    public GameObject loginPanel;
    public GameObject signUpPanel;

    public TMP_InputField signup_emailText;
    public TMP_InputField signup_nameText;
    public TMP_InputField signup_passwordText;
    public TMP_InputField signup_confirmPasswordText;

    public TMP_InputField login_Email_usernameText;
    public TMP_InputField login_passwordText;

    public int authMode = 0;
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    IEnumerator iRequest(UnityWebRequest www) {
        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError) {
            Debug.Log(www.error);
            info_errorText.transform.GetComponent<TextMeshProUGUI>().SetText("Network Error." + www.error);
            yield break;
        }
        string resultData = www.downloadHandler.text;

        if (string.IsNullOrEmpty(resultData)) {
            Debug.Log("Result Data Empty");
            info_errorText.transform.GetComponent<TextMeshProUGUI>().SetText("Failed");
            yield break;
        }
        Debug.Log(resultData);
        info_errorText.text = "";
        JsonData json = JsonMapper.ToObject(resultData);
        string response = json["success"].ToString();

        if (response != "1") {
            if (authMode == 0) {
                if (response == "-1") {
                    info_errorText.transform.GetComponent<TextMeshProUGUI>().SetText("Sign Up Failed");
                } else if (response == "0") {
                    info_errorText.transform.GetComponent<TextMeshProUGUI>().SetText("UserName already exists.");
                }
            } else if (authMode == 1) {
                if (response == "-1") {
                    info_errorText.transform.GetComponent<TextMeshProUGUI>().SetText("Login Failed");
                } else if (response == "0") {
                    info_errorText.transform.GetComponent<TextMeshProUGUI>().SetText("Password Wrong.");
                }
            }
        } else if (response == "1") {
            if (authMode == 0) {
                signUpPanel.SetActive(false);
                loginPanel.SetActive(true);
                info_errorText.transform.GetComponent<TextMeshProUGUI>().SetText("Sign Up Success! Please log in.");
            }
            if (authMode == 1) {
                info_errorText.transform.GetComponent<TextMeshProUGUI>().SetText("Login Success.");
                SceneManager.LoadScene("Main Scene");
            }
        }
    }

    public void SignUp() {
        info_errorText.text = "";
        authMode = 0;
        if (signup_passwordText.text != signup_confirmPasswordText.text) {
            info_errorText.text = "Passwords do not match";
        } else if (signup_nameText.text != "" && signup_emailText.text != "" && signup_passwordText.text != "" && signup_confirmPasswordText.text != "") {
            info_errorText.text = "";
            userData = new UserData();
            userData.username = signup_nameText.text;
            userData.email_address = signup_emailText.text;
            userData.password = signup_passwordText.text;

            PlayerPrefs.SetString("_UserName", userData.username);
            PlayerPrefs.SetString("_PlayerEmail", userData.email_address);
            PlayerPrefs.SetString("_PlayerPass", userData.password);

            WWWForm formData = new WWWForm();
            formData.AddField("username", userData.username);
            formData.AddField("email_address", userData.email_address);
            formData.AddField("password", userData.password);

            string requestURL = Global.GetDomain() + "/api/signup";

            UnityWebRequest www = UnityWebRequest.Post(requestURL, formData);
            www.SetRequestHeader("Accept", "application/json");
            www.uploadHandler.contentType = "application/json";
            StartCoroutine(iRequest(www));
        }
    }

    public void LoginPart() {

        info_errorText.text = "";
        authMode = 1;
        if (login_Email_usernameText.text != "" && login_passwordText.text != "") {
            info_errorText.text = "";
            userData = new UserData();
            userData.email_address = login_Email_usernameText.text;
            userData.password = login_passwordText.text;

            WWWForm formData = new WWWForm();
            formData.AddField("email_address", userData.email_address);
            formData.AddField("password", userData.password);

            string requestURL = Global.GetDomain() + "/api/login";

            UnityWebRequest www = UnityWebRequest.Post(requestURL, formData);
            www.SetRequestHeader("Accept", "application/json");
            www.uploadHandler.contentType = "application/json";
            StartCoroutine(iRequest(www));

        } else {
            info_errorText.text = "Enter email or password";
        }
    }

}
