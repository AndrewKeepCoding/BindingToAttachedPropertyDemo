using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace BindingToAttachedPropertyDemo;

public sealed partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void GridRowsCountNumberBox_ValueChanged(NumberBox _, NumberBoxValueChangedEventArgs args)
    {
        if (GridControl?.RowDefinitions.Count < args.NewValue)
        {
            for (int i = GridControl.RowDefinitions.Count; i < args.NewValue; i++)
            {
                var rowDefinition = new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) };
                GridControl.RowDefinitions.Add(rowDefinition);
            }

            return;
        }

        if (GridControl?.RowDefinitions.Count > args.NewValue)
        {
            for (int i = GridControl.RowDefinitions.Count - 1; i >= args.NewValue; i--)
            {
                GridControl.RowDefinitions.RemoveAt(i);
            }

            return;
        }
    }

    private void GridColumnsCountNumberBox_ValueChanged(NumberBox _, NumberBoxValueChangedEventArgs args)
    {
        if (GridControl?.ColumnDefinitions.Count < args.NewValue)
        {
            for (int i = GridControl.ColumnDefinitions.Count; i < args.NewValue; i++)
            {
                var columnDefinition = new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) };
                GridControl.ColumnDefinitions.Add(columnDefinition);
            }

            return;
        }

        if (GridControl?.ColumnDefinitions.Count > args.NewValue)
        {
            for (int i = GridControl.ColumnDefinitions.Count - 1; i >= args.NewValue; i--)
            {
                GridControl.ColumnDefinitions.RemoveAt(i);
            }

            return;
        }
    }
}
