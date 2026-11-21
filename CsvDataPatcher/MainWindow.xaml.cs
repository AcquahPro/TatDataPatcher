using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace CsvDataPatcher;

public partial class MainWindow : Window
{
    private readonly DispatcherTimer _statusTimer;

    //dotnet publish -c Release -r win-x64 --self-contained true /p:PublishSingleFile=true
    //dotnet publish 'c:\Users\LENOVO\source\Repos\TatDataPatcher\CsvDataPatcher\CsvDataPatcher.csproj' -c Release

    public MainWindow()
    {
        InitializeComponent();

        _statusTimer = new DispatcherTimer
        {
            Interval = TimeSpan.FromSeconds(5)
        };
        _statusTimer.Tick += StatusTimer_Tick;
    }

    private void BrowseButton_Click(object sender, RoutedEventArgs e)
    {
        var openFileDialog = new OpenFileDialog
        {
            Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*",
            Title = "Select a CSV file"
        };

        if (openFileDialog.ShowDialog() == true)
        {
            FilePathTextBox.Text = openFileDialog.FileName;
        }
    }

    private void AppendButton_Click(object sender, RoutedEventArgs e)
    {
        StatusTextBlock.Text = string.Empty;
        StatusTextBlock.Foreground = Brushes.Green;

        string? filePath = FilePathTextBox.Text?.Trim().Trim('"');

        if (string.IsNullOrWhiteSpace(filePath))
        {
            ShowStatus("File path cannot be empty.", Brushes.Red);
            return;
        }

        if (!File.Exists(filePath))
        {
            ShowStatus("File does not exist.", Brushes.Red);
            return;
        }

        if (!Path.GetExtension(filePath)
                .Equals(".csv", StringComparison.OrdinalIgnoreCase))
        {
            ShowStatus("Please select a valid CSV file.", Brushes.Red);
            return;
        }

        string? input = DataTextBox.Text;

        if (string.IsNullOrWhiteSpace(input))
        {
            ShowStatus("No data provided.", Brushes.Red);
            return;
        }

        try
        {
            // Trim any trailing newlines from input, then add exactly one
            string line = input.TrimEnd('\r', '\n') + Environment.NewLine;

            File.AppendAllText(
                filePath,
                line
            );

            ShowStatus("Data successfully appended!", Brushes.Green);
            DataTextBox.Clear();
        }
        catch (Exception ex)
        {
            ShowStatus($"Error: {ex.Message}", Brushes.Red);
        }
    }

    private void ShowStatus(string message, System.Windows.Media.Brush color)
    {
        StatusTextBlock.Text = message;
        StatusTextBlock.Foreground = color;
        _statusTimer.Stop();
        _statusTimer.Start();
    }

    private void StatusTimer_Tick(object? sender, EventArgs e)
    {
        _statusTimer.Stop();
        StatusTextBlock.Text = string.Empty;
    }
}
