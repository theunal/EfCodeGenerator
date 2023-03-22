using Microsoft.WindowsAPICodePack.Dialogs;
using System.Net;

namespace EfCodeGenerator
{
    public partial class Form1 : Form
    {
        private readonly CommonOpenFileDialog dialog;
        public Form1()
        {
            InitializeComponent();
            dialog = new CommonOpenFileDialog
            {
                InitialDirectory = "C:\\Users",
                IsFolderPicker = true
            };
            btnGenerate.Enabled = false;
            btnFromFile.Enabled = false;
            Text = "Ef Code Generator v1.2";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                txtPath.Text = dialog.FileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Generate(txtEntity.Text);
            Cursor = Cursors.Default;
            MessageBox.Show("Baþarýlý");
        }
        private void txtFromFile_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            var root = $"{txtPath.Text}\\Entities\\Concrete";

            if (Directory.Exists(root))
            {
                var entityFiles = Directory.GetFiles(root);
                foreach (string item in entityFiles)
                {
                    var filename = item.Split("\\")[^1].Replace(".cs", "");
                    Generate(filename);
                }
            }
            Cursor = Cursors.Default;
            MessageBox.Show("Baþarýlý");
        }

        private void Generate(string entityName)
        {
            string root = txtPath.Text;

            Write($"{root}\\DataAccess\\Abstract", $"I{entityName}Dal.cs", GetDataAccessAbstractText()
             .Replace("{{name}}", $"I{entityName}Dal")
             .Replace("{{entity}}", entityName), true);

            Write($"{root}\\DataAccess\\Concrete", $"{entityName}Dal.cs", GetDataAccessConcreteText()
             .Replace("{{name}}", $"{entityName}Dal")
             .Replace("{{entity}}", entityName)
             .Replace("{{context}}", txtContext.Text)
             .Replace("{{interface}}", $"I{entityName}Dal")
             .Replace("{{name}}", $"{entityName}Dal")
             .Replace("{{context}}", entityName), true);

            var serviceRegisterFileContent = GetFileContent($"{root}\\Business\\ServiceRegistration.cs");
            if (serviceRegisterFileContent is not null)
            {
                var registerText = GetRegisterText().Replace("{{entityName}}", entityName).Replace("{{entityName}}", entityName);

                if (!serviceRegisterFileContent.Contains(registerText))
                {
                    serviceRegisterFileContent = serviceRegisterFileContent
                      .Replace("return services;\r\n        }\r\n    }\r\n}",
                      "{{text}}\r\n            return services;\r\n        }\r\n    }\r\n}")
                      .Replace("{{text}}", registerText);
                    Write($"{root}\\Business", "ServiceRegistration.cs", serviceRegisterFileContent, false);
                }
            }
        }
        private string GetRegisterText() => @"services.AddScoped<I{{entityName}}Dal, {{entityName}}Dal>();";
        private string? GetFileContent(string filepath)
        {
            if (File.Exists(filepath))
                return File.ReadAllText(filepath);
            else
                return null;
        }
        private void Write(string dir, string filename, string text, bool createIfNotExists)
        {
            var filePath = $"{dir}\\{filename}";

            if (createIfNotExists || (createIfNotExists is false && File.Exists(filePath)))
                WriteFile(dir, filePath, text);
        }

        private void WriteFile(string dir, string filePath, string text)
        {
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            using var writer = new StreamWriter(filePath);
            writer.WriteLine(text);
            writer.Flush();
            writer.Close();
        }
        private string GetDataAccessAbstractText() => @"using Core.DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface {{name}} : IEntityRepository<{{entity}}>
    {
    }
}
";
        private string GetDataAccessConcreteText() => @"using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using DataAccess.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete
{
    public class {{name}} : EfEntityRepositoryBase<{{entity}}, {{context}}>, {{interface}}
    {
        public {{name}}({{context}} context) : base(context)
        {
        }
    }
}
";

        private void txtContext_TextChanged(object sender, EventArgs e)
        {
            if (txtContext.Text.Length > 0)
            {
                btnFromFile.Enabled = true;
                btnGenerate.Enabled = true;
            }
            else
            {
                btnFromFile.Enabled = false;
                btnGenerate.Enabled = false;
            }
        }
    }
}