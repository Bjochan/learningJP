using LearningJapanese.LogicClass;
using LearningJapanese.Properties;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace LearningJapanese
{
    public partial class LoginForm : Form
    {
        clsLogin objLogin = new clsLogin();
        string strServerIP = Login_Settings.Default.strServerIP;
        string ip = "";

        public LoginForm()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            Get_IDPass();
        }

        private void Get_IDPass()
        {
            string str = Login_Settings.Default.strID;
            if (str != "")
                txtUsernick.Text = objLogin.DecryptString(str);
            lblVer.Text += Login_Settings.Default.strVersion;
            lblStatus.Text = "";
            setColor(1);
        }

        private void setColor(int tpe)
        {
            switch (tpe)
            {
                case 0:
                    lblStatus.ForeColor = Color.FromArgb(250, 60, 5);
                    break;

                case 1:
                    lblStatus.ForeColor = Color.White;
                    break;

                case 2:
                    lblStatus.ForeColor = Color.FromArgb(3, 173, 3);
                    break;
            }
        }

        private void Set_Focus()
        {
            if (txtUsernick.Text == "") txtUsernick.Focus();
            else txtPass.Focus();
        }

        private bool checkConnect(string ipServer)
        {
            try
            {
                System.Net.Sockets.TcpClient clnt = new System.Net.Sockets.TcpClient(ipServer, 80);
                clnt.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        private void Runconnect()
        {
            try
            {
                if (checkConnect(strServerIP))
                {
                    ip = strServerIP;
                }
                else
                    MessageBox.Show("サーバーと接続できません。ネットワークを再確認または終了して再起動してください。");

            }

            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

            btnLogin.Text = "ログイン";
            btnLogin.ForeColor = Color.Black;
            btnLogin.Font = new Font(btnLogin.Font, FontStyle.Regular);
        }

        //ユーザニックネームを入力
        private void txtUsernick_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter & txtUsernick.Text.Trim() != "")
                txtPass.Focus();
        }

        //パスワードを入力
        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtPass.Text.Trim() != "")
            {
                btnLogin_Click(sender, e);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            string ID = txtUsernick.Text;
            string Pass = txtPass.Text;
            if (ID != "" & Pass != "")
            {
                btnLogin.Text = "ローディング...";
                btnLogin.ForeColor = Color.Red;
                btnLogin.Font = new Font(btnLogin.Font, FontStyle.Bold);
                btnLogin.Refresh();
                bool blCheck = false;
                try
                {
                    User obj = new User();
                    DataTable dt = obj.GetInfoUser(ID, Pass);
                    if (dt.Rows.Count > 0 && dt.Rows[0]["User_nick"].ToString() == ID && dt.Rows[0]["User_Pass"].ToString() == Pass)
                    {
                        blCheck = true;
                        GlobalVariables.User = dt.Rows[0]["User_nick"].ToString();
                        GlobalVariables.userName = dt.Rows[0]["User_name"].ToString();
                        GlobalVariables.IsAdmin = int.Parse(dt.Rows[0]["isadmin"].ToString());
                        GlobalVariables.ApplicationName = dt.Rows[0]["Appname"].ToString();
                        GlobalVariables.Version = dt.Rows[0]["version"].ToString();
                    }
                    else
                    {
                        blCheck = false;
                    }
                    if (blCheck == true)
                    {
                        save_IDPass(ID);
                        this.Hide();
                        MainForm mainForm = new MainForm();
                        mainForm.Show();
                    }
                    else
                    {
                        this.Cursor = Cursors.Default;
                        setColor(0);
                        lblStatus.Text = "ユーザーIDまたはパスワードは正しくありません。再入力してください。";
                        Set_Focus();
                    }
                }
                catch
                {
                    this.Cursor = Cursors.Default;
                    setColor(0);
                    lblStatus.Text = "エラーが発生しています。ログインできません。";
                    Set_Focus();
                }
            }
            else
            {
                if (ID == "")   //ニックネームまたはパスワードの未入力場合
                {
                    this.Cursor = Cursors.Default;
                    setColor(0);
                    lblStatus.Text = "ニックネームを入力してください。";
                    txtUsernick.Focus();
                }

                if (Pass == "")   //ニックネームまたはパスワードの未入力場合
                {
                    this.Cursor = Cursors.Default;
                    setColor(0);
                    lblStatus.Text = "パスワードを入力してください。";
                    txtPass.Focus();
                }
            }
        }

        private void save_IDPass(string iD)
        {
            Login_Settings.Default.strID = objLogin.EncryptString(iD);
            Login_Settings.Default.Save();
        }

        //新規登録
        private void lblRegist_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegistForm regForm = new RegistForm();
            regForm.ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
