using System;
using System.Collections;
using System.Collections.Generic;
using Realms;

namespace Xamarin.Summit
{
    public class Pessoa : RealmObject, IPessoa
    {
        [PrimaryKey]
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Imagem { get; set; }
        public string Link { get; set; }

        public IList<TimeLine> TimeLine { get;  }

        public Informacao Organizacao { get; set; }

    }
}
