using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace VHelperMaker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        StringBuilder hResult = new StringBuilder();
        StringBuilder cppResult = new StringBuilder();

        static string NewLine = "\n";
        static string NextLine = NewLine + NewLine;
        static string Tab = "    ";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ErrorBox(string error)
        {
            System.Windows.MessageBox.Show(error, "Failed", MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
        }

        public bool IsDirectoryWritable(string dirPath)
        {
            try
            {
                using (FileStream fs = File.Create(
                    Path.Combine(
                        dirPath,
                        Path.GetRandomFileName()
                    ),
                    1,
                    FileOptions.DeleteOnClose)
                )
                { }
                return true;
            }
            catch
            {
                return false;
            }
        }

        private string CommentHeader(string header, int tabs = 0)
        {
            StringBuilder result = new StringBuilder();
            result.Append("/////////////////////////////////////////\n");
            for(int i = 0; i < tabs; i++)
            {
                result.Append(Tab);
            }

            result.Append("// " + header);
            return result.ToString();
        }

        private string AddLog(string verbosity)
        {
            string open = "{ \\";
            string close = "} \\";

            StringBuilder result = new StringBuilder();
            result.Append("#define LOG" + LogNameBox.Text);
            if(verbosity != "Log")
            {
                result.Append("_" + verbosity.ToUpper());
            }
            result.Append("(Format, ...) \\");
            result.Append(NewLine);
            result.Append(open);
            result.Append(NewLine);
            result.Append(VHelperMaker.Properties.Resources.LogString);
            result.Append(NewLine + Tab);
            result.Append("if (LogString == \"\") \\");
            result.Append(NewLine);
            result.Append(Tab + open);
            result.Append(NewLine);
            result.Append(Tab + Tab + "UE_LOG(" + LogNameBox.Text + ", " + verbosity + ", TEXT(\"%s%s() : %s\"), LOG_NETMODE_WORLD, LOG_FUNC_NAME, *GetNameSafe(this)); \\");
            result.Append(NewLine);
            result.Append(Tab + close);
            result.Append(NewLine);
            result.Append(Tab + "else \\");
            result.Append(NewLine);
            result.Append(Tab + open);
            result.Append(NewLine);
            result.Append(Tab + Tab + "UE_LOG(" + LogNameBox.Text + ", " + verbosity + ", TEXT(\"%s%s() : %s\"), LOG_NETMODE_WORLD, LOG_FUNC_NAME, *LogString); \\");
            result.Append(NewLine);
            result.Append(Tab + close);
            result.Append(NewLine);
            result.Append("}");

            return result.ToString();
        }

        private string AddK2Log(string verbosity)
        {
            StringBuilder result = new StringBuilder();
            result.Append("void U" + FileNameBox.Text + "::K2_" + verbosity + "(UObject* WorldContextObject, const FString& String)");
            result.Append(NewLine);
            result.Append("{");
            result.Append(NewLine);
            result.Append(Tab + "UE_LOG(" + LogNameBox.Text + ", " + verbosity + ", TEXT(\"%s : %s\"), LOG_NETMODE_WORLD_STATIC, *String);");
            result.Append(NewLine);
            result.Append("}");

            return result.ToString();
        }

        private void MakeBtn_Click(object sender, RoutedEventArgs e)
        {
            // Create the header
            hResult.Append("#pragma once");
            hResult.Append(NextLine);

            cppResult.Append("#include \"" + FileNameBox.Text + ".h\"");

            if(NetRoleCBox.IsChecked == true)
            {
                cppResult.Append(NewLine);
                cppResult.Append("#include <GameFramework/Actor.h>");
            }

            cppResult.Append(NextLine);
            cppResult.Append("DEFINE_LOG_CATEGORY(" + LogNameBox.Text + ");");

            bool needsHelperClass = (BPLogCBox.IsChecked == true || NetRoleCBox.IsChecked == true);
            if (needsHelperClass)
            {
                // A helper class deriving from UObject is required for these methods
                hResult.Append("#include \"Object.h\"");
                hResult.Append(NewLine);
            }

            hResult.Append("#include \"Engine/Engine.h\"");
            hResult.Append(NewLine);
            hResult.Append("#include \"" + FileNameBox.Text + ".generated.h\"");

            // Add macros used for logging macros
            hResult.Append(NextLine);
            hResult.Append(CommentHeader("Logging Helper Macros"));

            hResult.Append(NextLine);
            hResult.Append(ProjectNameBox.Text.ToUpper() + "_API DECLARE_LOG_CATEGORY_EXTERN(" + LogNameBox.Text + ", Log, All);");

            hResult.Append(NextLine);
            hResult.Append(VHelperMaker.Properties.Resources.LOG_NETMODE_WORLD);
            hResult.Append(NextLine);

            if (BPLogCBox.IsChecked == true)  // Add static BP logging macro if required
            {
                hResult.Append(VHelperMaker.Properties.Resources.LOG_NETMODE_WORLD_STATIC);
                hResult.Append(NextLine);
            }

            hResult.Append(VHelperMaker.Properties.Resources.LOG_FUNC_NAME);
            hResult.Append(NextLine);

            // Logging macros
            hResult.Append(CommentHeader("Logging Macros"));
            hResult.Append(NextLine);

            hResult.Append(AddLog("Log"));
            hResult.Append(NextLine);
            hResult.Append(AddLog("Warning"));
            hResult.Append(NextLine);
            hResult.Append(AddLog("Error"));
            hResult.Append(NextLine);
            hResult.Append(AddLog("Fatal"));
            hResult.Append(NextLine);

            // Helper Class
            if(needsHelperClass)
            {
                hResult.Append(CommentHeader("Helper Class"));
                hResult.Append(NextLine);

                hResult.Append("UCLASS()");
                hResult.Append(NewLine);
                hResult.Append("class U" + FileNameBox.Text + " : public UObject");
                hResult.Append(NewLine);
                hResult.Append("{");
                hResult.Append(NewLine);
                hResult.Append(Tab + "GENERATED_BODY()");
                hResult.Append(NextLine);

                hResult.Append("public:");

                if (NetRoleCBox.IsChecked == true) 
                {
                    hResult.Append(NewLine);
                    hResult.Append(Tab + CommentHeader("Helpers", 1));
                    hResult.Append(NextLine);
                    hResult.Append(Tab + VHelperMaker.Properties.Resources.HelperHeaders);

                    cppResult.Append(NextLine);
                    cppResult.Append("FString U" + FileNameBox.Text + "::GetNetRole(AActor* InActor)");
                    cppResult.Append(NewLine);
                    cppResult.Append(VHelperMaker.Properties.Resources.GetNetRole);

                    cppResult.Append(NextLine);
                    cppResult.Append("FString U" + FileNameBox.Text + "::GetNetRole(const AActor* InActor)");
                    cppResult.Append(NewLine);
                    cppResult.Append(VHelperMaker.Properties.Resources.GetNetRole);

                    cppResult.Append(NextLine);
                    cppResult.Append("FString U" + FileNameBox.Text + "::EnumToString(FString EnumString, uint8 EnumValue)");
                    cppResult.Append(NewLine);
                    cppResult.Append(VHelperMaker.Properties.Resources.EnumToString);
                }

                if (BPLogCBox.IsChecked == true)  // Add BP logging functions if desired
                {
                    hResult.Append((NetRoleCBox.IsChecked == true) ? NextLine : NewLine);
                    hResult.Append(Tab + CommentHeader("BP Logging", 1));
                    hResult.Append(NextLine);
                    hResult.Append(Tab + VHelperMaker.Properties.Resources.BlueprintLoggingHeaders);

                    cppResult.Append(NextLine);
                    cppResult.Append(AddK2Log("Log"));
                    cppResult.Append(NextLine);
                    cppResult.Append(AddK2Log("Warning"));
                    cppResult.Append(NextLine);
                    cppResult.Append(AddK2Log("Error"));
                    cppResult.Append(NextLine);
                    cppResult.Append(AddK2Log("Fatal"));
                }

                hResult.Append(NewLine);
                hResult.Append("};");
            }

            // Write the output
            if (System.IO.Directory.Exists(OutputBox.Text))
            {
                if (IsDirectoryWritable(OutputBox.Text))
                {
                    string filePath = OutputBox.Text + FileNameBox.Text;
                    // Write .h
                    System.IO.File.WriteAllText(filePath + ".h", hResult.ToString());

                    // Search for matching Private folder for .cpp
                    string cppPath = filePath + ".cpp";

                    char[] splitter = { '\\' };
                    string[] splitPath = OutputBox.Text.Split(splitter);

                    string lastDirectory = "";

                    for(int i = (splitPath.Length - 1); i >= 0; i--)
                    {
                        if(splitPath[i].Equals("Public"))
                        {
                            for (int j = 0; j < i; j++) 
                            {
                                lastDirectory += splitPath[j] + "\\";
                            }
                            break;
                        }
                    }

                    if(System.IO.Directory.Exists(lastDirectory + "Private\\"))
                    {
                        cppPath = lastDirectory + "Private\\" + FileNameBox.Text + ".cpp";
                    }

                    // Write .cpp
                    System.IO.File.WriteAllText(cppPath, cppResult.ToString());

                    // Open the output folder
                    System.Diagnostics.Process.Start(OutputBox.Text);
                }
                else
                {
                    ErrorBox("Directory is not writable");
                }
            }
            else
            {
                ErrorBox("Directory does not exist");
            }
        }

        private void FixOutputPathSuffix()
        {
            if (!OutputBox.Text.EndsWith("\\"))
            {
                OutputBox.Text += "\\";
            }
        }

        private void BrowseBtn_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog browserDialog = new FolderBrowserDialog();
            {
                if(browserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    OutputBox.Text = browserDialog.SelectedPath;
                    FixOutputPathSuffix();
                }
            }
        }

        private void OnChanged(object sender, RoutedEventArgs e)
        {
            FixOutputPathSuffix();
        }
    }
}
