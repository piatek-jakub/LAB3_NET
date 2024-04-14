using NET_LAB3;

namespace ImageGUI
{
    public partial class ParallelImage : Form
    {
        private Bitmap? img;
        private readonly object imageLock = new object();
        public ParallelImage()
        {
            InitializeComponent();
        }
        public void Brightness(int brightness)
        {
            const int MAX_VALUE = 255;
            const int MIN_VALUE_BRIGHTNESS = -255;
            const int MIN_VALUE_COLOR = 0;
            Bitmap bitmap;
            Color color;
            lock (imageLock)
            {
               bitmap = (Bitmap)img.Clone();
            }
            if(brightness > MAX_VALUE)
            {
                brightness = MAX_VALUE;
            }
            if(brightness < MIN_VALUE_BRIGHTNESS)
            {
                brightness = MIN_VALUE_BRIGHTNESS;
            }

            for(int i=0; i < bitmap.Width; i++)
            {
                for(int j=0; j < bitmap.Height; j++)
                {
                    color = bitmap.GetPixel(i, j);
                    int colorRed = color.R + brightness;
                    int colorGreen = color.G + brightness;
                    int colorBlue = color.B + brightness;
                    if(colorRed < MIN_VALUE_COLOR) { colorRed = MIN_VALUE_COLOR;}
                    else if(colorRed > MAX_VALUE) {  colorRed = MAX_VALUE; }

                    if (colorGreen < MIN_VALUE_COLOR) { colorGreen = MIN_VALUE_COLOR; }
                    else if (colorGreen > MAX_VALUE) { colorGreen = MAX_VALUE; }

                    if (colorBlue < MIN_VALUE_COLOR) { colorBlue = MIN_VALUE_COLOR; }
                    else if (colorBlue > MAX_VALUE) { colorBlue = MAX_VALUE; }

                    bitmap.SetPixel(i, j, Color.FromArgb((byte)colorRed, (byte)colorGreen, (byte)colorBlue));
                }
            }

            pictureBox1.Image = bitmap;
        }
        public void Invert()
        {
            Bitmap bitmap;
            Color color;
            const int MAX_VALUE = 255;
            lock (imageLock)
            {
                bitmap = (Bitmap)img.Clone();
            }
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    color = bitmap.GetPixel(i, j);
                    int colorRed = MAX_VALUE - color.R;
                    int colorGreen = MAX_VALUE - color.G;
                    int colorBlue = MAX_VALUE - color.B;


                    bitmap.SetPixel(i, j, Color.FromArgb((byte)colorRed, (byte)colorGreen, (byte)colorBlue));
                }
            }
            pictureBox2.Image = bitmap;
        }
        public void GrayScale()
        {
            Bitmap bitmap;
            Color color;
            lock (imageLock)
            {
                bitmap = (Bitmap)img.Clone();
            }
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    color = bitmap.GetPixel(i, j);
                    byte gray = (byte)(.299 * color.R + .587 * color.G + .114 * color.B);

                    bitmap.SetPixel(i, j, Color.FromArgb(gray, gray, gray));
                }
            }
            pictureBox3.Image = bitmap;
        }
        public void FlipHorizontally()
        {
            Bitmap bitmap;
            Bitmap bitmapFlipped;
            Color color;
            lock (imageLock)
            {
                bitmap = (Bitmap)img.Clone();
            }

            bitmapFlipped = new Bitmap(bitmap.Width, bitmap.Height);

            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    color = bitmap.GetPixel(i, j);
                    int Xcoord = bitmap.Width - i - 1;
                    int Ycoord = j;
                    bitmapFlipped.SetPixel(Xcoord, Ycoord, color);
                }
            }
            pictureBox4.Image = bitmapFlipped;
        }
        private void buttonLoad_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "jpg files (*.jpg)|*.jpg|All files (*.*)|(*.*)";
            openFileDialog1.Multiselect = false;
            DialogResult result = openFileDialog1.ShowDialog();
            if (result != DialogResult.OK)
            {
                MessageBox.Show("No image has been selected", "cancelling selection");
                return;
            }
            var file = openFileDialog1.FileName;
            if (file != null)
            {
                img = new Bitmap(file);
                pictureBoxMain.Image = img;
            }
        }

        private void buttonProcess_Click(object sender, EventArgs e)
        {
            if(img == null)
            {
                MessageBox.Show("Image not selected!");
                return;
            }
            int numberOfThreads = Convert.ToInt32(numericUpDown1.Value);
            Parallel.For(0, numberOfThreads, index =>
            {
                switch (index)
                {
                    default:
                    case 0:
                        Brightness(150);
                        break;
                    case 1:
                        Invert();
                        break;
                    case 2:
                        GrayScale();
                        break;
                    case 3:
                        FlipHorizontally();
                        break;
                }
            });
        }
    }
}
