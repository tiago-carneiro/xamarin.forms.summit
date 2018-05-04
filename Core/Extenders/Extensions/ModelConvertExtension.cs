namespace Xamarin.Summit
{
    public static class ModelConvertExtension
    {
        public static T ConvertTo<T>(this IInformacao informacao) where T : IInformacao, new()
            => new T
            {
                Titulo = informacao.Titulo,
                SubTitulo = informacao.SubTitulo,
                Descricao = informacao.Descricao,
                Local = informacao.Local,
                Lat = informacao.Lat,
                Lon = informacao.Lon
            };

        public static T ConvertTo<T>(this INota nota) where T : INota, new()
            => new T
            {
                Titulo = nota.Titulo,
                Descricao = nota.Descricao
            };

        public static T ConvertTo<T>(this IPessoa pessoa) where T : IPessoa, new()
            => new T
            {
                Id = pessoa.Id,
                Descricao = pessoa.Descricao,
                Imagem = pessoa.Imagem,
                Link = pessoa.Link,
                Nome = pessoa.Nome,
                Titulo = pessoa.Titulo
            };

        public static T ConvertTo<T>(this IApoio apoio) where T : IApoio, new()
            => new T
            {
                Categoria = apoio.Categoria,
                Imagem = apoio.Imagem,
                Link = apoio.Link,
                Nome = apoio.Nome,
                Ordem = apoio.Ordem
            };

        public static T ConvertTo<T>(this IAgenda agenda) where T : IAgenda, new()
            => new T
            {
                Descricao = agenda.Descricao,
                Titulo = agenda.Titulo
            };

        public static T ConvertTo<T>(this ITimeLine timeLine) where T : ITimeLine, new()
            => new T
            {
                Id = timeLine.Id,
                Descricao = timeLine.Descricao,
                Hora = timeLine.Hora,
                Titulo = timeLine.Titulo
            };
    }
}
