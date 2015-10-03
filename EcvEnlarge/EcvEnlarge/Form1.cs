using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Emgu.CV;
using Emgu.Util;
using Emgu.CV.Structure;
using Emgu.CV.ML;
using Emgu.CV.Cvb;
using Emgu.CV.Reflection;
using Emgu.CV.CvEnum;
using System.Diagnostics;      
namespace EcvEnlarge
{
    public partial class Form1 : Form
    {
        string fname;
        PictureBox savePic = new PictureBox();
        PictureBox sav2 = new PictureBox();
        int i = 0;
        int k = 0;
        FileStream pFileStream;
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            k = 1;
            if (i==0)
            {
                OpenFileDialog OpenFileDialog1 = new OpenFileDialog();//创建OpenFileDialog用于打开一张图片
                OpenFileDialog1.InitialDirectory = "C:\\";           //设置打开的初始目录
                OpenFileDialog1.Filter = "图片格式|*.jpg;*.png";    // 要在对话框中显示的文件筛选器
                OpenFileDialog1.FilterIndex = 1;              //在对话框中选择的文件筛选器的索引，如果选第一项就设为1
                OpenFileDialog1.RestoreDirectory = true;      //关闭前恢复默认目录
                if (OpenFileDialog1.ShowDialog() == DialogResult.OK) //当点击打开时
                {
                    fname = OpenFileDialog1.FileName; //读取打开的文件路径
                    // StreamReader sr = File.OpenText(fname);//????????无法实现
                    this.pictureBox1.Image = Image.FromFile(fname); //设置图片控件中显示的图片
                    this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom; //按原有的大小比例缩放
                }

                i++;
            }
            else
            {
                //Process[] process = Process.GetProcesses();
                //foreach (Process prc in process)
                //{
                //    Console.WriteLine(prc.ProcessName);
                //    if (prc.ProcessName == "result.jpg")
                //        prc.Kill();
                //}
                //Console.ReadLine();

                this.pictureBox2.Image = Image.FromFile("笑.jpg");
                this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom; //按原有的大小比例缩放
                savePic.Image = this.pictureBox2.Image;
               // pFileStream.Close();
                //pFileStream.Dispose();
      
                OpenFileDialog OpenFileDialog1 = new OpenFileDialog();//创建OpenFileDialog用于打开一张图片
                OpenFileDialog1.InitialDirectory = "C:\\";           //设置打开的初始目录
                OpenFileDialog1.Filter = "图片格式|*.jpg;*.png";    // 要在对话框中显示的文件筛选器
                OpenFileDialog1.FilterIndex = 1;              //在对话框中选择的文件筛选器的索引，如果选第一项就设为1
                OpenFileDialog1.RestoreDirectory = true;      //关闭前恢复默认目录
                if (OpenFileDialog1.ShowDialog() == DialogResult.OK) //当点击打开时
                {
                    fname = OpenFileDialog1.FileName; //读取打开的文件路径
                    // StreamReader sr = File.OpenText(fname);//????????无法实现
                    this.pictureBox1.Image = Image.FromFile(fname); //设置图片控件中显示的图片
                    this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom; //按原有的大小比例缩放
                }

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "像素较小的头像的等比例放大系统";//显示窗体的名字
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
           // this.BackgroundImage = Image.FromFile(@"Form背景图.jpg");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            //if(k==0)
            //{
            //    MessageBox.Show("请选择或重新选择要处理的图片！");
            //}

             if (radioButton2.Checked == true && radioButton1.Checked == false && radioButton3.Checked == false && radioButton4.Checked == false && radioButton5.Checked == false)//只选择三次样条插值时，只放大
            {
                Mat image1 = CvInvoke.Imread(fname, LoadImageType.AnyDepth | LoadImageType.AnyColor);
                Mat image2 = image1;
                Size dsize = new Size(image1.Cols * 3, image1.Rows * 3);
                CvInvoke.Resize(image1, image2, dsize, 0, 0, Emgu.CV.CvEnum.Inter.Cubic);
               // image2.Save("result.jpg");
                // //this.pictureBox2.Image = Image.FromFile("result.jpg"); //设置图片控件中显示的图片
                //pFileStream = new FileStream("result.jpg", FileMode.Open, FileAccess.Read);
                //this.pictureBox2.Image = Image.FromStream(pFileStream);
               
                this.pictureBox2.Image = image2.Bitmap;
                savePic.Image = this.pictureBox2.Image;
                // // pFileStream.Close();
                // //  pFileStream.Dispose();
                this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom; //按原有的大小比例缩放

            }
            else if (radioButton2.Checked == true && radioButton1.Checked == false && radioButton3.Checked == true && radioButton4.Checked == false && radioButton5.Checked == false)//三次样条插值、仅放大
            {
                Mat image1 = CvInvoke.Imread(fname, LoadImageType.AnyDepth | LoadImageType.AnyColor);
                Mat image2 = image1;
                Size dsize = new Size(image1.Cols * 3, image1.Rows * 3);
                CvInvoke.Resize(image1, image2, dsize, 0, 0, Emgu.CV.CvEnum.Inter.Cubic);
              //  image2.Save("result.jpg");
               // //this.pictureBox2.Image = Image.FromFile("result.jpg"); //设置图片控件中显示的图片
               //  pFileStream = new FileStream("result.jpg", FileMode.Open, FileAccess.Read);
               // this.pictureBox2.Image = Image.FromStream(pFileStream);
                this.pictureBox2.Image = image2.Bitmap;
                savePic.Image = this.pictureBox2.Image;
               // //pFileStream.Close();
               // //pFileStream.Dispose();
                this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom; //按原有的大小比例缩放
   
            }
            else if (radioButton2.Checked == true && radioButton1.Checked == false && radioButton4.Checked == true && radioButton5.Checked == false && radioButton3.Checked == false)//三次样条插值，降噪
            {
                Mat image1 = CvInvoke.Imread(fname, LoadImageType.AnyDepth | LoadImageType.AnyColor);
                Mat image2 = image1;
                Mat image3 = image1;
                
                Size dsize = new Size(image1.Cols * 3, image1.Rows * 3);
                Size dsz = new Size(3,3);//高斯核设置大小
                CvInvoke.Resize(image1, image2, dsize, 0, 0, Emgu.CV.CvEnum.Inter.Cubic);
                CvInvoke.GaussianBlur(image2,image3,dsz,0,0);
               // image3.Save("result.jpg");
             //   //this.pictureBox2.Image = Image.FromFile("result.jpg"); //设置图片控件中显示的图片
             //   pFileStream = new FileStream("result.jpg", FileMode.Open, FileAccess.Read);
            //    this.pictureBox2.Image = Image.FromStream(pFileStream);
                
                this.pictureBox2.Image = image3.Bitmap;
                savePic.Image = this.pictureBox2.Image;
             //   //pFileStream.Close();
             //   //pFileStream.Dispose();
                this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom; //按原有的大小比例缩放

            }

            else if (radioButton2.Checked == true && radioButton1.Checked == false && radioButton5.Checked == true && radioButton3.Checked == false && radioButton4.Checked == false)//三次样条插值，锐化
            {
                Mat image1 = CvInvoke.Imread(fname, LoadImageType.AnyDepth | LoadImageType.AnyColor);
                Mat image2 = image1;
                Mat image3 = image1;
              //  Mat kernel = (Mat_<float>(3, 3) << 0, -1, 0, -1, 5, -1, 0, -1, 0);
                // Mat kernel(3,3,CV_32F,Scalar(-1)); 
                Matrix<float> km = new Matrix<float>(
                       new float[,]{
                {0.0f, -1.0f, 0.0f},
                {-1.0f, 5.0f, -1.0f},
                {0.0f, -1.0f, 0.0f}
            }
           );

                Point dian = new Point (-1,-1);
                Size dsize = new Size(image1.Cols * 3, image1.Rows * 3);
             
                CvInvoke.Resize(image1, image2, dsize, 0, 0, Emgu.CV.CvEnum.Inter.Cubic);
                CvInvoke.Filter2D(image2, image3, km,dian);
               // image3.Save("result.jpg");
              //  //this.pictureBox2.Image = Image.FromFile("result.jpg"); //设置图片控件中显示的图片
              //   pFileStream = new FileStream("result.jpg", FileMode.Open, FileAccess.Read);
              //  this.pictureBox2.Image = Image.FromStream(pFileStream);
              
                this.pictureBox2.Image = image3.Bitmap;
                savePic.Image = this.pictureBox2.Image;
            //   // pFileStream.Close();
             //   //pFileStream.Dispose();
                this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom; //按原有的大小比例缩放

            }

            //else if (checkBox4.Checked == true && checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false && checkBox5.Checked == false) 只降噪
            //{
            //    Mat image1 = CvInvoke.Imread(fname, LoadImageType.AnyDepth | LoadImageType.AnyColor);
            //    Mat image2 = image1;
            //    Size dsz = new Size(5, 5);//高斯核设置大小
            //    CvInvoke.GaussianBlur(image1, image2, dsz, 0, 0);
            //    image2.Save("result.jpg");//有问题错在哪？？？？？
            //   // this.pictureBox2.Image = Image.FromFile("result.jpg"); //设置图片控件中显示的图片
            //     pFileStream = new FileStream("result.jpg", FileMode.Open, FileAccess.Read);
            //    this.pictureBox2.Image = Image.FromStream(pFileStream);
                
            //    this.pictureBox2.Image = image2.Bitmap;
            //    savePic.Image = this.pictureBox2.Image;
            //    //pFileStream.Close();
            //    //pFileStream.Dispose();
            //    this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom; //按原有的大小比例缩放

            //}

         //   else if (checkBox5.Checked == true && checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false && checkBox4.Checked == false)只锐化
         //   {
         //       Mat image1 = CvInvoke.Imread(fname, LoadImageType.AnyDepth | LoadImageType.AnyColor);
         //       Matrix<float> km = new Matrix<float>(
         //            new float[,]{
         //       {0.0f, -1.0f, 0.0f},
         //       {-1.0f, 5.0f, -1.0f},
         //       {0.0f, -1.0f, 0.0f}
         //   }
         //);
         //       Mat image2 = image1;
         //       Point dian = new Point(-1, -1);
         //      // CvInvoke.Filter2D(image1, image2, km, dian);
         //       image2.Save("result.jpg");
         //       //this.pictureBox2.Image = Image.FromFile("result.jpg"); //设置图片控件中显示的图片
         //      // pFileStream = new FileStream("result.jpg", FileMode.Open, FileAccess.Read);
         //      // this.pictureBox2.Image = Image.FromStream(pFileStream); 
         //       this.pictureBox2.Image = image2.Bitmap;
         //       savePic.Image = this.pictureBox2.Image;
         //      // pFileStream.Close();
         //      // pFileStream.Dispose();
         //       this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom; //按原有的大小比例缩放


         //   }
            else if (radioButton1.Checked == true && radioButton2.Checked == false && radioButton3.Checked == false && radioButton4.Checked == false && radioButton5.Checked == false)//线性插值放大
            {
                Mat image1 = CvInvoke.Imread(fname, LoadImageType.AnyDepth | LoadImageType.AnyColor);
                Mat image2 = image1;
                Size dsize = new Size(image1.Cols * 3, image1.Rows * 3);
                CvInvoke.Resize(image1, image2, dsize, 0, 0, Emgu.CV.CvEnum.Inter.Linear);
              //  image2.Save("result.jpg");
               // //this.pictureBox2.Image = Image.FromFile("result.jpg"); //设置图片控件中显示的图片
              //  pFileStream = new FileStream("result.jpg", FileMode.Open, FileAccess.Read);
              //  this.pictureBox2.Image = Image.FromStream(pFileStream);
               
                this.pictureBox2.Image = image2.Bitmap;
                savePic.Image = this.pictureBox2.Image;
              //  //pFileStream.Close();
              //  //pFileStream.Dispose();
                this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom; //按原有的大小比例缩放

            }
          
            else if (radioButton1.Checked == true && radioButton2.Checked == false && radioButton3.Checked == true && radioButton4.Checked == false && radioButton5.Checked == false)//线性插值放大,仅放大
            {
                Mat image1 = CvInvoke.Imread(fname, LoadImageType.AnyDepth | LoadImageType.AnyColor);
                Mat image2 = image1;
                Size dsize = new Size(image1.Cols * 3, image1.Rows * 3);
                CvInvoke.Resize(image1, image2, dsize, 0, 0, Emgu.CV.CvEnum.Inter.Linear);
               // image2.Save("result.jpg");
              //  //this.pictureBox2.Image = Image.FromFile("result.jpg"); //设置图片控件中显示的图片
              //  pFileStream = new FileStream("result.jpg", FileMode.Open, FileAccess.Read);
             //   this.pictureBox2.Image = Image.FromStream(pFileStream);
                this.pictureBox2.Image = image2.Bitmap;
                savePic.Image = this.pictureBox2.Image;
             //   //pFileStream.Close();
             //   //pFileStream.Dispose();
                this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom; //按原有的大小比例缩放

            }
            else if (radioButton1.Checked == true && radioButton2.Checked == false && radioButton4.Checked == true && radioButton5.Checked == false && radioButton3.Checked == false)//线性插值放大，降噪
            {
                Mat image1 = CvInvoke.Imread(fname, LoadImageType.AnyDepth | LoadImageType.AnyColor);
                Mat image2 = image1;
                Mat image3 = image1;

                Size dsize = new Size(image1.Cols * 3, image1.Rows * 3);
                Size dsz = new Size(3, 3);//高斯核设置大小
                CvInvoke.Resize(image1, image2, dsize, 0, 0, Emgu.CV.CvEnum.Inter.Linear);
                CvInvoke.GaussianBlur(image2, image3, dsz, 0, 0);
                image3.Save("result.jpg");
               // //this.pictureBox2.Image = Image.FromFile("result.jpg"); //设置图片控件中显示的图片
               // pFileStream = new FileStream("result.jpg", FileMode.Open, FileAccess.Read);
               // this.pictureBox2.Image = Image.FromStream(pFileStream);
             
                this.pictureBox2.Image = image3.Bitmap; 
                savePic.Image = this.pictureBox2.Image;
              //  //pFileStream.Close();
              //  //pFileStream.Dispose();
                this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom; //按原有的大小比例缩放

            }
            else if (radioButton1.Checked == true && radioButton2.Checked == false && radioButton5.Checked == true && radioButton3.Checked == false && radioButton4.Checked == false)//线性插值，锐化
            {
                Mat image1 = CvInvoke.Imread(fname, LoadImageType.AnyDepth | LoadImageType.AnyColor);
                Mat image2 = image1;
                Mat image3 = image1;
                //  Mat kernel = (Mat_<float>(3, 3) << 0, -1, 0, -1, 5, -1, 0, -1, 0);
                // Mat kernel(3,3,CV_32F,Scalar(-1)); 
                Matrix<float> km = new Matrix<float>(
                       new float[,]{
                {0.0f, -1.0f, 0.0f},
                {-1.0f, 5.0f, -1.0f},
                {0.0f, -1.0f, 0.0f}
            }
           );

                Point dian = new Point(-1, -1);
                Size dsize = new Size(image1.Cols * 3, image1.Rows * 3);

                CvInvoke.Resize(image1, image2, dsize, 0, 0, Emgu.CV.CvEnum.Inter.Linear);
                CvInvoke.Filter2D(image2, image3, km, dian);
               // image3.Save("result.jpg");
              //  //this.pictureBox2.Image = Image.FromFile("result.jpg"); //设置图片控件中显示的图片
              //  pFileStream = new FileStream("result.jpg", FileMode.Open, FileAccess.Read);
              //  this.pictureBox2.Image = Image.FromStream(pFileStream);
             
                this.pictureBox2.Image = image3.Bitmap;
                savePic.Image = this.pictureBox2.Image;
             //   // pFileStream.Close();
             //   //pFileStream.Dispose();
                this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom; //按原有的大小比例缩放

            }
            else if (radioButton1.Checked == false && radioButton2.Checked == false && radioButton3.Checked == false && radioButton4.Checked == false && radioButton5.Checked == false)
            {
                MessageBox.Show("请选择具体操作！");
                
            }

            else
            {
                MessageBox.Show("操作无意义或存在冲突，请重新选择！");
            }
          

           //savePic.Image = this.pictureBox2.Image;


            k = 0;

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
           // this.panel1.BackgroundImage = Image.FromFile(@"面板背景图.jpg");
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
           // this.panel2.BackgroundImage = Image.FromFile(@"原图背景框.jpg");
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {
           // this.panel7.BackgroundImage = Image.FromFile(@"处理后图片背景框.jpg");
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            //保存到本地
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.CheckFileExists = false;

            sfd.CheckPathExists = true;

            sfd.Title = "另存为";

            sfd.InitialDirectory = @"D:\";

           // sfd.Filter = "图片(*.jpg)|*.jpg";
            sfd.Filter = "图片(*.jpg)|*.jpg";
            sfd.FilterIndex = 1;              //在对话框中选择的文件筛选器的索引，如果选第一项就设为1

            sfd.AddExtension = true;

            sfd.RestoreDirectory = true;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                savePic.Image.Save(sfd.FileName);

                //定位到保存的文件
                //System.Diagnostics.Process.Start("Explorer", "/select," + sfd.FileName);
            }
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
