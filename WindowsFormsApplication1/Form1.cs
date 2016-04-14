using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            int index = 0;
            foreach (var fn in files)
            {
                ++index;
                if (index <= 25)
                {
                    PictureBox box = (PictureBox)(this.Controls.Find("pictureBox" + index, true).Single());
                    box.Image = Image.FromFile(fn);
                }
                else
                {
                    break;
                }
            }
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "PNG files (*.png)|*.png|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Bitmap b = new Bitmap(tableLayoutPanel1.Width, tableLayoutPanel1.Height);
                this.tableLayoutPanel1.DrawToBitmap(b, new Rectangle(0, 0, b.Width, b.Height));
                b.Save(saveFileDialog1.FileName, ImageFormat.Png);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
