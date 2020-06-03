using Microsoft.ML;
using ReconhecimentoEscudoTime.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static Microsoft.ML.Transforms.ValueToKeyMappingEstimator;

namespace ReconhecimentoEscudoTime
{
    public class Treinamento
    {
        public static void TreinarRNA(ProgressBar progressBar, TextBox txt)
        {
            var watch = Stopwatch.StartNew();
            txt.Text = "1 - Iniciando treinamento;";
            progressBar.Value = 1;
            var mlContext = new MLContext(1);
            string caminhoModelo = @"C:\Projetos\ReconhecimentoEscudoTime\ModeloTreinado\modelo.zip";
            string caminhoEntrada = @"C:\Projetos\ReconhecimentoEscudoTime\Exemplo\";
            progressBar.Value = 10;
            txt.Text = txt.Text + (" 2 - Buscando imagens para treino;");
            IEnumerable<ImagemModel> imagens = ObterImagensEntrada(caminhoEntrada);

            txt.Text = txt.Text + (" 3 - Criando DataView a partir das imagens;");
            IDataView iDataViewImagens = mlContext.Data.LoadFromEnumerable(imagens);

            txt.Text = txt.Text + (" 4 - Embaralhar as linhas do DataView para não carregar todos os dados em memória;");
            IDataView iDataViewEmbaralhar = mlContext.Data.ShuffleRows(iDataViewImagens);

            progressBar.Value = 20;
            txt.Text = txt.Text + (" 5 - Carregando imagens em memória, adicionando titúlo;");
            IDataView iDataViewMemoria = mlContext.Transforms.Conversion.
                        MapValueToKey(outputColumnName: "LabelAsKey", inputColumnName: "Titulo", keyOrdinality: KeyOrdinality.ByValue)
                    .Append(mlContext.Transforms.LoadRawImageBytes(outputColumnName: "Imagem", imageFolder: caminhoEntrada, inputColumnName: "Caminho"))
                    .Fit(iDataViewEmbaralhar).Transform(iDataViewEmbaralhar);


            progressBar.Value = 30;
            txt.Text = txt.Text + (" 6 - Dividindo o conjunto de dados no conjunto de treinamento;");
            var treinoTeste = mlContext.Data.TrainTestSplit(iDataViewMemoria, testFraction: 0.2);
            IDataView trainoDataView = treinoTeste.TrainSet;
            IDataView testeDataView = treinoTeste.TestSet;
            progressBar.Value = 40;

            var pipeline = mlContext.MulticlassClassification.Trainers.ImageClassification(featureColumnName: "Imagem",
                            labelColumnName: "LabelAsKey",validationSet: testeDataView)
                            .Append(mlContext.Transforms.Conversion.MapKeyToValue(outputColumnName: "PredictedLabel",
                            inputColumnName: "PredictedLabel"));
            
            progressBar.Value = 50;

            txt.Text = txt.Text + (" 7 - Treinando modelo;");
            ITransformer modeloTreinado = pipeline.Fit(trainoDataView);
            progressBar.Value = 90;
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            txt.Text = txt.Text + (" 8 - Treinamento Tempo: " + elapsedMs/1000 + " Segundos;");           
            txt.Text = txt.Text + (" 9 - Salvando modelo;");
            mlContext.Model.Save(modeloTreinado, trainoDataView.Schema, caminhoModelo);

            txt.Text = txt.Text + (" 10 - Processo concluído;");
            string metricas = Metricas(mlContext, testeDataView, modeloTreinado);
            txt.Text = txt.Text + metricas;
            progressBar.Value = 100;
        }

        public static IEnumerable<ImagemModel> ObterImagensEntrada(string entrada)
        {
            var imagens = Directory.GetFiles(entrada, "*", searchOption: SearchOption.AllDirectories).Where(x => Path.GetExtension(x) == ".jpg" || Path.GetExtension(x) == ".png" || Path.GetExtension(x) == ".bmp");
            return imagens.Select(i => new ImagemModel(i, Directory.GetParent(i).Name));          
        }

        public static IEnumerable<ImagemMemoria> ObterImagensEntradaImagemMemoria(string entrada)
        {
            var imagens = Directory.GetFiles(entrada, "*", searchOption: SearchOption.AllDirectories).Where(x => Path.GetExtension(x) == ".jpg" || Path.GetExtension(x) == ".png" || Path.GetExtension(x) == ".bmp");
            var ret = imagens.Select(i => (i, Directory.GetParent(i).Name));
            return ret.Select(i => new ImagemMemoria(File.ReadAllBytes(i.i), i.Name, Path.GetFileName(i.i)));
        }

        private static string Metricas(MLContext mlContext, IDataView datView, ITransformer modeloTreinamento)
        {
            var predicao = modeloTreinamento.Transform(datView);
            var metricas = mlContext.MulticlassClassification.Evaluate(predicao, labelColumnName: "LabelAsKey", predictedLabelColumnName: "PredictedLabel");
            return string.Format(Environment.NewLine + "Microprecisão: {0:0.###}, Macroprecisão: {1:0.###}, Perda: {2:0.###}, Redução de Perdas: {3:0.###}", metricas.MicroAccuracy, metricas.MacroAccuracy, metricas.LogLoss, metricas.LogLossReduction);
        }
    }
}