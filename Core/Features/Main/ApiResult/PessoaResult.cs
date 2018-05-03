using System;

namespace Xamarin.Summit
{
    public class PessoaResult : PessoaBase, IPessoa
    {
        public PessoaResult()
            => Id = Guid.NewGuid().ToString();
    }
}
