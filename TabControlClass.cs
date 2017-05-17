using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TabControlForm
{
    public partial class TabControlClass : Form
    {
        public TabControlClass()
        {
            InitializeComponent();
        }

        private void TabControl_Load(object sender, EventArgs e)
        {

        }

        // Add tabPage, if it doesn't exist; otherwise, select it
        private void addButton_Click(object sender, EventArgs e)
        {
            addNewTab();
        }

        // Add tabPage when user presses Enter from textBox
        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
                addNewTab();
        }

        // Remove tabPage from tabControl
        private void deleteButton_Click(object sender, EventArgs e)
        {
            if(tabControl.SelectedTab != null)
            {
                tabControl.TabPages.Remove(tabControl.SelectedTab);
                tabControl.SelectedIndex = tabControl.TabPages.Count - 1;
            }
        }

        // Check whether a tabPage already exists
        private int? SearchIndex(String text)
        {
            if (tabControl == null)
                return null;

            foreach (TabPage tab in tabControl.TabPages)
                if (tab.Text == text)
                    return tabControl.TabPages.IndexOf(tab);

            return null;
        }

        // Generate new TabPage
        private void addNewTab()
        {
            String text = textBox.Text.Trim();

            if (text.Length != 0)
            {
                int? index = SearchIndex(text);

                if (index == null)
                {
                    TabPage newTab = new System.Windows.Forms.TabPage();

                    newTab.Location = new System.Drawing.Point(4, 22);
                    newTab.Name = text;
                    newTab.Padding = new System.Windows.Forms.Padding(3);
                    newTab.Size = new System.Drawing.Size(460, 267);
                    newTab.TabIndex = tabControl.TabPages.Count;
                    newTab.Text = text;
                    newTab.UseVisualStyleBackColor = true;

                    tabControl.TabPages.Add(newTab);
                    tabControl.SelectedIndex = tabControl.TabPages.IndexOf(newTab);
                }
                else
                    tabControl.SelectedIndex = Convert.ToInt32(index);
            }
            else
                textBox.Clear();
        }
    }
}