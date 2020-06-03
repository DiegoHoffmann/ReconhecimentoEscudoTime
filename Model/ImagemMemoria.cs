using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReconhecimentoEscudoTime.Model
{
    public class ImagemMemoria
    {
        public ImagemMemoria(Byte[] imagem,string titulo, string nome)
        {
            this.Imagem = imagem;
            this.Titulo = titulo;
            this.Nome = nome;
        }
        public readonly byte[] Imagem;
        public readonly string Titulo;
        public readonly string Nome;
    }
}
