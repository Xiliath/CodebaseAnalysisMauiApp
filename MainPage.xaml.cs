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
            var solutionPath = @"C:\Users\pvano\source\repos\CodebaseAnalysisMauiApp\CodebaseAnalysisMauiApp.sln";
            var instruction = InputEditor.Text;

            var codebaseInfo = await _analyzer.GetCodebaseInfo(solutionPath, instruction);
            var codeBasestring = codebaseInfo.ToString();

            var codebaseInfoString = $"codebaseInfo: {codeBasestring}"; 

            string prompt = $"Given the following codebase information: {codebaseInfoString}\n\n{instruction}";

            CodebaseInfo.Text = prompt;
        }
    }
}
