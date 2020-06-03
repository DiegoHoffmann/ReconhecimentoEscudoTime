using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReconhecimentoEscudoTime.Model
{
    public class ImagemModel
    {
        public ImagemModel(string caminho, string titulo)
        {
            this.Caminho = caminho;
            this.Titulo = titulo;
        }
        public readonly string Caminho;
        public readonly string Titulo;
    }
}
