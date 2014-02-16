using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuickSearch
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

		private void Form1_Load(object sender, EventArgs e)
		{
			// 起動時のフォーカス設定
			ActiveControl = textBoxSearch;
		}

        private void button1_Click(object sender, EventArgs e)
        {
			SearchWord(textBoxSearch.Text);
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
				SearchWord(textBoxSearch.Text);
            }
			else if (e.KeyCode == System.Windows.Forms.Keys.Escape)
			{
				SearchResultVisible(false);
			}
        }

		private void Form1_Activated(object sender, EventArgs e)
		{
			textBoxSearch.Focus();
			SearchResultVisible(true);
		}

		private void Form1_Deactivate(object sender, EventArgs e)
		{
			SearchResultVisible(false);
		}

		/// <summary>
		/// ワード検索
		/// </summary>
		private void SearchWord(string word)
		{
			webBrowser.Navigate("http://eow.alc.co.jp/" + word + "#resultsList_contextmenu");
			SearchResultVisible(true);
			webBrowser.DocumentCompleted += (sender, e) =>
			{
				try { webBrowser.Navigate("#resultsList_contextmenu"); }
				catch { }
			};
		}

		/// <summary>
		/// 検索結果の表示切替
		/// </summary>
		private void SearchResultVisible(bool visible)
		{
			webBrowser.Visible = visible;

			if (webBrowser.Visible)
			{
				ClientSize = new Size(ClientSize.Width, textBoxSearch.Height + 500);
			}
			else
			{
				ClientSize = new Size(ClientSize.Width, textBoxSearch.Height);
			}
		}
	}
}
