using Xamarin.Forms;

namespace Xamarin.Summit
{
    public class InfoDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate EnderecoTemplate { get; set; }
        public DataTemplate NotaTemplate { get; set; }
        public DataTemplate OrganizacaoTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            switch ((item as SummitInfoWrapper).Tipo)
            {
                case SummitInfoType.Endereco:
                    return EnderecoTemplate;
                case SummitInfoType.Nota:
                    return NotaTemplate;
                case SummitInfoType.Organizacao:
                    return OrganizacaoTemplate;
            }
            return null;
        }
    }
}
