using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KiraraSaveDataManeger
{
    public partial class Form1 : Form
    {
        DirectoryInfo SaveDir;
        DirectoryInfo[] SaveDirArray;
        DirectoryInfo SelectedDir;
        Random rnd = new Random();

        public Form1()
        {
            InitializeComponent();
            button2_Click(null, null);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            SaveDir = new DirectoryInfo(textBox2.Text);
            SaveDirArray = SaveDir.GetDirectories();
            //SaveDirs = Directory.GetDirectories(textBox2.Text);
            int tmpScroll = listBox2.SelectedIndex;
            listBox2.Items.Clear();
            listBox2.Items.AddRange(SaveDirArray);
            if (tmpScroll < listBox2.Items.Count)
            {
                listBox2.SelectedIndex = tmpScroll;
            }
            listBox2.Focus();

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var index = listBox2.SelectedIndex;
            if (index != -1 && index < listBox2.Items.Count)
            {
                SelectedDir = SaveDirArray[index];
                if (SelectedDir.Exists == false)
                    return;

                textBox1.Text = SelectedDir.Name;
                
                var png = SelectedDir.GetFiles("*.png");
                if (png.Length > 0)
                {
                    var tmpImg = Image.FromFile(png[0].FullName);
                    pictureBox1.Image = new Bitmap(tmpImg);
                    tmpImg.Dispose();
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        { 
            if(SelectedDir != null && SelectedDir.Exists)
            {
                //MessageBox.Show(SelectedDir.Parent.FullName);
                var newPath = SelectedDir.Parent.FullName + "\\" + textBox1.Text;
                if (!Directory.Exists(newPath))
                {
                    SelectedDir.MoveTo(newPath);
                    button2_Click(null, null);
                    button1.Text = rnd.Next(100000).ToString();
                }
                else
                {
                    button1.Text = "資料夾已存在";
                }
            }
        }

        private void listBox2_DoubleClick(object sender, EventArgs e)
        {
            var index = listBox2.SelectedIndex;
            if (index != -1 && index < listBox2.Items.Count)
            {
                SelectedDir = SaveDirArray[index];
                textBox2.Text = SelectedDir.FullName;
                button2_Click(null, null);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Text = SaveDir.Parent.FullName;
            button2_Click(null, null);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            var sleGoldIndex = listBox1.SelectedIndex;
            string[] GoldName = { "_Aoba", "_Chiya", "_Karen", "_Tamaki", "_Tooru", "_Yuki", "_Yuzuko", "_Yuno" };
            var tmpStr = textBox1.Text;
            textBox1.Text = tmpStr.Substring(0, 1) + GoldName[sleGoldIndex] + tmpStr.Substring(1);

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
