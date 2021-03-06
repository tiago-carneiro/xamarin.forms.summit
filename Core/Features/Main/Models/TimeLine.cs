﻿using Realms;
using System.Linq;

namespace Xamarin.Summit
{
    public class TimeLine : RealmObject, ITimeLine
    {
        [PrimaryKey]
        public string Id { get; set; }
        public string Titulo { get; set; }
        public string Hora { get; set; }
        public string Descricao { get; set; }

        [Backlink(nameof(Pessoa.TimeLine))]
        public IQueryable<Pessoa> Palestrantes { get; }
    }
}
