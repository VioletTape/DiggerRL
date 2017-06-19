using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace TestUI {
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private Label[,] labels;

        private int rowX = 1;
        private int colX = 1;

        public MainWindow() {
            InitializeComponent();

            for (var i = 0; i < 10; i++) {
                grid.ColumnDefinitions.Add(new ColumnDefinition {
                                                                    Width = new GridLength(50)
                                                                });
                grid.RowDefinitions.Add(new RowDefinition {
                                                              Height = new GridLength(50)
                                                          });
            }

            AddLabels();


            grid.ShowGridLines = true;

            KeyUp += DoStuff;
        }

        private void AddLabels() {
            labels = new Label[10, 10];

            for (var row = 0; row < 10; row++)
            for (var col = 0; col < 10; col++) {
                var uiElement = new Label();
                labels[row, col] = uiElement;
                uiElement.Content = "X";
                uiElement.SetValue(Grid.RowProperty, row);
                uiElement.SetValue(Grid.ColumnProperty, col);
                grid.Children.Add(uiElement);
            }
        }

        private void DoStuff(object sender, KeyEventArgs e) {
            debugLabel.Content = e.Key.ToString();
            Draw(e.Key);
        }

        private void Draw(Key eKey) {
            labels[rowX, colX].Content = " ";
            switch (eKey) {
                case Key.Up:
                    rowX--;
                    break;
                case Key.Down:
                    rowX++;
                    break;
                case Key.Left:
                    colX--;
                    break;
                case Key.Right:
                    colX++;
                    break;
                default:
                    return;
            }

            labels[rowX, colX].Content = "@";
        }
    }
}
