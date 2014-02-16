using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuickSearch
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
			SearchWord(textBoxSearch.Text);
        }

		private void SearchWord(string word)
		{
			//webBrowser.Url = new Uri("http://eow.alc.co.jp/" + word + "#resultsList_contextmenu");


			webBrowser.Navigate("http://eow.alc.co.jp/" + word + "#resultsList_contextmenu");
			SearchResultVisible(true);
			webBrowser.DocumentCompleted += (sender, e) =>
			{
				try { webBrowser.Navigate("#resultsList_contextmenu"); }
				catch { }
			};

			/*
			webBrowser.Url = new Uri("http://eow.alc.co.jp/" + word + "#resultsList_contextmenu");
			SearchResultVisible(true);
			webBrowser.DocumentCompleted += (sender, e) =>
			{
				try { webBrowser.Navigate("#resultsList_contextmenu"); }
				catch { }
			};
			 */
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

		private void buttonToggle_Click(object sender, EventArgs e)
		{
			SearchResultVisible(!webBrowser.Visible);
		}

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

		private void Form1_Activated(object sender, EventArgs e)
		{
			textBoxSearch.Focus();
			SearchResultVisible(true);
		}

		private void Form1_Deactivate(object sender, EventArgs e)
		{
			SearchResultVisible(false);
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			ActiveControl = textBoxSearch;
		}
    }
}
