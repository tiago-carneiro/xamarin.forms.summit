using System.Windows.Input;
using Xamarin.Forms;

namespace Xamarin.Summit
{
    public partial class TabHeaderItem : StackLayout
    {
        public TabHeaderItem()
            => InitializeComponent();

        Color DefaultColor => Color.LightGray;
        Color PrimaryColor => (Color)Application.Current.Resources["PrimaryColor"];
        Color RedColor => Color.Red;

        public static readonly BindableProperty HeaderProperty =
             BindableProperty.Create(nameof(Header), typeof(AgendaHeaderWrapper), typeof(TabHeaderItem), default(AgendaHeaderWrapper), propertyChanged: OnCurrentChanged);

        public AgendaHeaderWrapper Header
        {
            get => (AgendaHeaderWrapper)GetValue(HeaderProperty);
            set => SetValue(HeaderProperty, value);
        }

        public static readonly BindableProperty CommandProperty = 
            BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(TabHeaderItem), null, propertyChanged: OnItemTappedChanged);

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public static readonly BindableProperty CurrentProperty =
             BindableProperty.Create(nameof(Current), typeof(AgendaHeaderWrapper), typeof(TabHeaderItem), default(AgendaHeaderWrapper), propertyChanged: OnSelectedChanged);

        public AgendaHeaderWrapper Current
        {
            get => (AgendaHeaderWrapper)GetValue(CurrentProperty);
            set => SetValue(CurrentProperty, value);
        }
        
        private static void OnCurrentChanged(BindableObject bindable, object oldValue, object newValue)
            => (bindable as TabHeaderItem).lblTitle.Text = (newValue as AgendaHeaderWrapper).Titulo;

        private static void OnSelectedChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var self = bindable as TabHeaderItem;
            var header = (AgendaHeaderWrapper)newValue;

            if (self.Header == header)
            {
                self.lblTitle.TextColor = self.PrimaryColor;
                self.bxView.BackgroundColor = self.RedColor;
            }
            else
            {
                self.lblTitle.TextColor = (Color)Label.TextColorProperty.DefaultValue;
                self.bxView.BackgroundColor = self.DefaultColor;
            }
        }

        private static void OnItemTappedChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = bindable as TabHeaderItem;
            if (control != null)
            {
                var tapGestureRecognizer = new TapGestureRecognizer();
                tapGestureRecognizer.Tapped += (sender, e) 
                    => control?.Command?.Execute(control.Header);
                control.GestureRecognizers.Add(tapGestureRecognizer);
            }
        }
    }
}