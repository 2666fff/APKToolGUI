using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace AutoAPKTool
{
    public partial class MD5CalculatorForm : Form
    {
        public MD5CalculatorForm()
        {
            InitializeComponent();
            this.Load += MD5CalculatorForm_Load;
        }

        private void MD5CalculatorForm_Load(object sender, EventArgs e)
        {
            inputTextBox.Focus();
            inputTextBox.Select();
        }

        private void inputTextBox_TextChanged(object sender, EventArgs e)
        {
            CalculateMD5();
        }

        private void CalculateMD5()
        {
            var inputText = inputTextBox.Text;
            if (string.IsNullOrEmpty(inputText))
            {
                outputTextBox.Text = "";
                return;
            }

            try
            {
                using (var md5 = MD5.Create())
                {
                    var inputBytes = Encoding.UTF8.GetBytes(inputText);
                    var hashBytes = md5.ComputeHash(inputBytes);
                    var sb = new StringBuilder();
                    foreach (var b in hashBytes)
                    {
                        sb.Append(b.ToString("x2"));
                    }
                    outputTextBox.Text = sb.ToString();
                }
            }
            catch (Exception ex)
            {
                outputTextBox.Text = $"错误: {ex.Message}";
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            inputTextBox.Clear();
            outputTextBox.Clear();
        }
    }
}
