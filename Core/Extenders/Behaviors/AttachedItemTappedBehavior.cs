using System.Windows.Input;
using Xamarin.Forms;

namespace Xamarin.Summit
{
    public static class AttachedItemTappedBehavior
    {
        public static readonly BindableProperty CommandProperty =
            BindableProperty.CreateAttached(
                propertyName: "Command",
                returnType: typeof(ICommand),
                declaringType: typeof(ListView),
                defaultValue: null,
                defaultBindingMode: BindingMode.OneWay,
                validateValue: null,
                propertyChanged: OnItemTappedChanged);

        private static void OnItemTappedChanged(BindableObject bindable, object oldValue, object newValue)
            => (bindable as ListView).ItemTapped += (sender, e) =>
            {
                var control = sender as ListView;
                var command = (ICommand)control.GetValue(CommandProperty);

                if (command != null && command.CanExecute(e.Item))
                    command.Execute(e.Item);

                control.SelectedItem = null;
            };
    }
}
