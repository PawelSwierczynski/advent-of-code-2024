using AdventOfCode.Tasks;
using System.Windows;

namespace AdventOfCode
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class AdcentOfCodeWindow : Window
	{
		private static readonly AdventTaskService adventTaskService = new AdventTaskService();

		public AdcentOfCodeWindow()
		{
			InitializeComponent();

			SelectTaskComboBox.DisplayMemberPath = nameof(AdventTask.Name);
			SelectTaskComboBox.ItemsSource = adventTaskService.AdventTasks;
		}

		private void SelectTaskComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			InputTextBox.IsEnabled = true;
			ProcessInputButton.IsEnabled = true;
		}

		private void ProcessInputButton_Click(object sender, RoutedEventArgs e)
		{
			if (SelectTaskComboBox.SelectedItem is AdventTask adventTask)
			{
				OutputTextBox.Text = adventTask.ProcessInput(InputTextBox.Text);
			}
		}
	}
}