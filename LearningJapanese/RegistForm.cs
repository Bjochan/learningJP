using LearningJapanese.LogicClass;
using System;
using System.Data;
using System.Windows.Forms;

namespace LearningJapanese
{
    public partial class RegistForm : Form
    {
        public RegistForm()
        {
            InitializeComponent();
        }

        private void frmRegist_Load(object sender, EventArgs e)
        {

        }

        //[登録]ボタンを押す
        private void btnReg_Click(object sender, EventArgs e)
        {
            if (tbxNick.Text == "")
            {
                MessageBox.Show("すべて情報を入力してください");
                tbxNick.Focus();
                return;
            }

            if (tbxPass.Text =="")
            {
                MessageBox.Show("すべて情報を入力してください");
                tbxPass.Focus();
                return;
            }

            if(tbxMail.Text=="")
            {
                MessageBox.Show("すべて情報を入力してください");
                tbxMail.Focus();
                return;
            }

            //DB確認
            string StoreName = "SP_INSERT_USERS";
            DialogResult result = MessageBox.Show("登録して欲しいですか?", "確認", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                DataTable _mcheck = new DataConfig().getTable("select * from USERS where User_nick='" + tbxNick.Text + "'");

                if (_mcheck != null && _mcheck.Rows.Count >0)
                {
                    MessageBox.Show("ユーザが存在しました。");
                    tbxNick.Focus();
                    return;
                } 

                else
                {
                    DataConfig clins = new DataConfig();

                    string SQL = String.Format("exec " + StoreName + "0,N'" + tbxNick.Text + "', N'" + tbxPass.Text + "', N'" + tbxMail.Text + "', N'" + dtBirth.Text + "',N");
                    clins.Excute(SQL);
                    lblInf.Text = "登録に成功しました。";
                    btnReg.Enabled = false;
                }
            }           
        }

        //キャンセルの場合
        private void btnCnl_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}




