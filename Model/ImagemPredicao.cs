using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReconhecimentoEscudoTime.Model
{
    public class ImagemPredicao
    {
        [ColumnName("Score")]
        public float[] Score;
        [ColumnName("PredictedLabel")]
        public string PredicaoTitulo;
    }
}
