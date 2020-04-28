using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Z_8_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int allVotesCount = 0;
        Dictionary<string, int> answers = new Dictionary<string, int>()
        {
            {"A",0 },
            {"B",0 },
            {"C",0 },
            {"D",0 },
        };
        public MainWindow()
        {
            InitializeComponent();
           // QuestionTextblock.Text = "Głosuj!"; <-- opcjonalne, można w XAMLu ustawić
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var choice = button.Content.ToString();

            answers[choice]++;
            allVotesCount++;

            AllVotes.Text = allVotesCount.ToString();

            RedrawGraph();
        }

        private void RedrawGraph()
        {
            var maxHeight = canvas.ActualHeight;
            
            RecA.Height = maxHeight * (answers["A"] / (double)allVotesCount);
            RecB.Height = maxHeight * (answers["B"] / (double)allVotesCount);
            RecC.Height = maxHeight * (answers["C"] / (double)allVotesCount);
            RecD.Height = maxHeight * (answers["D"] / (double)allVotesCount);


            MaxVote.Text = answers.Max(x => x.Value).ToString();
        }
    }
}
