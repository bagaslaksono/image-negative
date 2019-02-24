using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Image_Negative
{
    public partial class Form1 : Form
    {
        Image File;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_Open_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "JPG(*.JPG)|*.jpg";
            if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                File = Image.FromFile(open.FileName);
                pb_1.Image = File;

            }
        }

        private void btn_negative_Click(object sender, EventArgs e)
        {

            Color p;

            pb_1.Image = File;

            Bitmap bmp1 = new Bitmap(File);


            int Width = bmp1.Width;
            int Height = bmp1.Height;

            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    p = bmp1.GetPixel(x, y);
                    int a = p.A;
                    int r = p.R;
                    int g = p.G;
                    int b = p.B;



                    int sub1 = 255 - r;
                    int sub2 = 255 - g;
                    int sub3 = 255 - b;


                    bmp1.SetPixel(x, y, Color.FromArgb(a, sub1, sub2, sub3));

                }
            }
           pb_result.Image = bmp1;
        }
    }
}
