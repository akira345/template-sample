using System;
using System.Windows.Forms;
using RazorEngine;
using System.IO;
using RazorEngine.Configuration;
using RazorEngine.Text;
using RazorEngine.Templating;

namespace template_sample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //http://devlights.hatenablog.com/entry/20121030/p1より
            string TemplateFilePath = @"C:\temp\Templates\test.tpl";
            string OutputFilePath = @"c:\temp\Templates\test.txt";
            var template = File.ReadAllText(TemplateFilePath);
            var model = new
            {
                Name = "hogehoge",
                TEL  = "000-111-2345"
            };

            //config
            var config = new TemplateServiceConfiguration();
            config.Language = Language.CSharp;
            config.EncodedStringFactory = new RawStringFactory();
            //Service
            var service = RazorEngineService.Create(config);
            Engine.Razor = service;
            //Generate
            string ret = Engine.Razor.RunCompile(template, "templatekey", null, model);
            File.WriteAllText(OutputFilePath,ret);

            




        }
    }
}
