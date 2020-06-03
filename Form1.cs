using Emgu.CV;
using Emgu.CV.Structure;
using Microsoft.ML;
using ReconhecimentoEscudoTime.Model;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ReconhecimentoEscudoTime
{
    public partial class Form1 : Form
    {
        Capture captura;
        delegate void SetTextCallback(Bitmap bt, int r, int g, int b);
        public Form1()
        {
            InitializeComponent();
            captura = new Capture();
            Application.Idle += CarregarCam;
        }

        public void CarregarCam(object sender, System.EventArgs e)
        {
            if (picBoxCam.Image != null)
                picBoxCam.Image.Dispose();

            var imgagem = captura.QueryFrame().ToImage<Bgr, byte>();
            var btm = imgagem.Bitmap;
            Rectangle r = new Rectangle(350, 50, 250,250);
            using (Graphics gr = Graphics.FromImage(btm))
            {
                using (Pen p = new Pen(Color.Blue, 1))
                {
                    gr.DrawRectangle(p, r);
                }
            }           
            picBoxCam.Image = btm;
        }

        private void btnCarregar_Click(object sender, EventArgs e)
        {
            buscarInformacoes();
        }

        public void buscarInformacoes()
        {
            var btm = new Bitmap(picBoxCam.Image);
           
            Rectangle cropRect = new Rectangle(353,53,245,245);
            Bitmap src = btm;
            Bitmap target = new Bitmap(400, 300);

            using (Graphics g = Graphics.FromImage(target))
            {
                g.DrawImage(src, new Rectangle(0, 0, 400, 300),
                                 cropRect,
                                 GraphicsUnit.Pixel);
            }
            picBoxCaptura.Image = target;
            comparaImagemComModelo(target);
        }                

        private void carregarCor(Bitmap bt, int r, int g, int b)
        {            
            Rectangle cropRect = new Rectangle(403, 53, 175, 175);
            Bitmap target = new Bitmap(400, 300);

            using (Graphics gr = Graphics.FromImage(target))
            {
                gr.DrawImage(bt, new Rectangle(0, 0, 400, 300),
                                 cropRect,
                                 GraphicsUnit.Pixel);
            }
            picBoxCaptura.Image = target;
            comparaImagemComModelo(target);
        }

        private void btnTreinar_Click(object sender, EventArgs e)
        {
            Treinamento.TreinarRNA(progressBar, txtTreino);
        }      

        private void comparaImagemComModelo(Bitmap bt)
        {
            try
            {               
                ImageCodecInfo myImageCodecInfo;
                System.Drawing.Imaging.Encoder myEncoder;
                EncoderParameter myEncoderParameter;
                EncoderParameters myEncoderParameters;
                myEncoderParameters = new EncoderParameters(1);
                myEncoder = System.Drawing.Imaging.Encoder.Quality;

                myImageCodecInfo = GetEncoderInfo("image/jpeg");
                myEncoderParameter = new EncoderParameter(myEncoder, 100L);
                myEncoderParameters.Param[0] = myEncoderParameter;
                bt.Save(@"C:\Projetos\ReconhecimentoEscudoTime\Temp\captura.jpg", myImageCodecInfo, myEncoderParameters);

                MLContext mlContext = new MLContext();
                DataViewSchema predictionPipelineSchema;

                Bitmap a = new Bitmap(@"C:\Projetos\ReconhecimentoEscudoTime\Temp\captura.jpg");

                MemoryStream imageMemoryStream = new MemoryStream();
                a.Save(imageMemoryStream, a.RawFormat);
                byte[] imageData = imageMemoryStream.ToArray();
                var watch = System.Diagnostics.Stopwatch.StartNew();

                var imageInputData = new Model.ImagemMemoria(imagem: imageData, titulo: null, nome: null);

                var predictionEnginePool = mlContext.Model.Load(@"C:\Projetos\ReconhecimentoEscudoTime\ModeloTreinado\modelo.zip", out predictionPipelineSchema);
                var result = mlContext.Model.CreatePredictionEngine<ImagemMemoria, ImagemPredicao>(predictionEnginePool).Predict(imageInputData);
                watch.Stop();
                var tempo = watch.ElapsedMilliseconds;
                txtTime.Text = result.PredicaoTitulo.ToString();
                txtScore.Text = string.Format("{0:0.###}", result.Score.Max());
                txtTempo.Text = string.Format("{0}",(tempo / 1000));
            }
            catch (Exception e)
            {
                MessageBox.Show("Treine a RNA");
            }
        }

        private static ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }
    }
}
