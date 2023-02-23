using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MTDeo6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // image rotation seq...
            Stopwatch sw = Stopwatch.StartNew();
            // get all images
            foreach (var file in Directory.GetFiles(@"E:\images"))
            {
                // Load image file
                Image img = Image.FromFile(file);
                // rotate image
                img.RotateFlip(RotateFlipType.Rotate180FlipX);
                // save image
                FileInfo finfo = new FileInfo(file);
                img.Save($"E:\\RotatedImages\\{finfo.Name}");

            }
            MessageBox.Show($"Done...and took {sw.ElapsedMilliseconds}");
        }
    }
}
