using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using Newtonsoft.Json;
using fileCompareWithList.Model;
using System.Reflection;


namespace fileCompareWithList
{
    //Make it such that it can add or read the registry

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnOpen_Click_1(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string originalFilePath = openFileDialog.FileName;
                    string text = File.ReadAllText(originalFilePath);
                    AppList? appList = null;

                    // Check if the file is JSON or TXT based on extension
                    if (originalFilePath.EndsWith(".json", StringComparison.OrdinalIgnoreCase))
                    {
                        try
                        {
                            appList = JsonConvert.DeserializeObject<AppList>(text);
                        }
                        catch (JsonException)
                        {
                            MessageBox.Show("The file is not a valid JSON file.");
                            return;
                        }
                    }
                    else if (originalFilePath.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
                    {
                        try
                        {
                            appList = ParseTxtFile(text);
                            if (appList == null)
                            {
                                MessageBox.Show("The file is not in the expected TXT format.");
                                return;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error parsing TXT file: {ex.Message}");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Unsupported file format. Please open a .json or .txt file.");
                        return;
                    }

                    
                   

                    // Display the path and contents
                    string displayText = JsonConvert.SerializeObject(appList, Formatting.Indented);
                    txtDisplay.Text = $"Path: {appList.Path}{Environment.NewLine}" +
                                      $"Contents:{Environment.NewLine}{displayText}{Environment.NewLine}____{Environment.NewLine}";

                    if (appList != null)
                    {
                        foreach (App app in appList.Applications)
                        {
                            string filePath = Path.Combine(appList.Path, app.Name);
                            if (File.Exists(filePath))
                            {
                                FileInfo fileInfo = new FileInfo(filePath);
                                double size = fileInfo.Length / 1024; // Size in KB
                                string fileVersion = FileVersionInfo.GetVersionInfo(filePath).FileVersion ?? "N/A";

                                string fileDetails = $"Version: {fileVersion}{Environment.NewLine}" +
                                                     $"Size: {size} KB{Environment.NewLine}";

                                ListViewItem lvitem = new ListViewItem(app.Name);
                                lvitem.SubItems.Add(fileDetails);

                                bool vMatch = fileVersion.Equals(app.Version);
                                bool sMatch = size == app.Size;

                                string versionResult = $"Version Match: {vMatch} {(vMatch ? "✔" : "✘")}{Environment.NewLine}";
                                string sizeResult = $"Size Match: {sMatch} {(sMatch ? "✔" : "✘")}{Environment.NewLine}";

                                lvitem.SubItems.Add(versionResult);
                                lvitem.SubItems.Add(sizeResult);
                                lvitem.UseItemStyleForSubItems = false;
                                lvitem.SubItems[2].ForeColor = vMatch ? Color.Green : Color.Red;
                                lvitem.SubItems[3].ForeColor = sMatch ? Color.Green : Color.Red;

                                listView1.Items.Add(lvitem);
                            }
                            else
                            {
                                ListViewItem lvitem = new ListViewItem(app.Name);
                                string notFoundFile = "File does not exist.";
                                string notApplicable = "N/A";

                                lvitem.SubItems.Add(notFoundFile);
                                lvitem.SubItems.Add(notApplicable);
                                lvitem.SubItems.Add(notApplicable);

                                lvitem.SubItems[0].ForeColor = Color.Goldenrod;
                                lvitem.SubItems[1].ForeColor = Color.Goldenrod;
                                lvitem.SubItems[2].ForeColor = Color.Goldenrod;
                                lvitem.SubItems[3].ForeColor = Color.Goldenrod;

                                listView1.Items.Add(lvitem);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please open a file first.");
                }
            }
        }

        private AppList ParseTxtFile(string text)
        {
            AppList appList = new AppList();
            string[] lines = text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            // Extract the Path from the first line
            appList.Path = lines[0].Replace("Path: ", "").Trim('"');

            // Loop through the remaining lines and extract application data
            foreach (var line in lines.Skip(1)) // Skip the first line (path)
            {
                string[] parts = line.Split(','); // Use comma as the delimiter
                if (parts.Length == 2) // We expect two parts: name and size
                {
                    string name = parts[0].Trim();
                    int size = int.TryParse(parts[1].Trim(), out int parsedSize) ? parsedSize : 0;

                    appList.Applications.Add(new App
                    {
                        Name = name,
                        Version = "N/A", // No version info in this case
                        Size = size
                    });
                }
                else
                {
                    MessageBox.Show("Invalid format in TXT file. Expected format: Name,Size");
                    return null;
                }
            }

            return appList;
        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            Form2 registry = new Form2();
            registry.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            txtDisplay.Clear();
            richTextBox1.Clear();   
            
        }
    }
}
