using System;
using System.Threading.Tasks;
using CodebaseAnalysisLib;
using Microsoft.Maui.Controls;

namespace CodebaseAnalysisMauiApp
{
    public partial class MainPage : ContentPage
    {
        private readonly CodebaseAnalyzer _analyzer;

        public MainPage()
        {
            InitializeComponent();
            _analyzer = new CodebaseAnalyzer();
        }

        private async void OnSubmitClicked(object sender, EventArgs e)
        {
            var solutionPath = @"C:\Users\pvano\source\repos\GimmeGifGit\GifBuilder\GimmeGif.sln";
            var instruction = InputEditor.Text;

            var codebaseInfo = await _analyzer.GetCodebaseInfo(solutionPath, instruction);
            var codeBasestring = codebaseInfo.ToString();

            var codebaseInfoString = $"{codeBasestring}";
            var ns = System.Reflection.Assembly.GetExecutingAssembly().EntryPoint.DeclaringType.Namespace;
            string prompt = $"Given the following codebase information: \n\n Namespace: {ns} \n\n {codebaseInfoString}\n\n{instruction}";

            CodebaseInfo.Text = prompt;
        }
    }
}
