using Microsoft.Win32;
using System;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace fileCompareWithList
{
    public partial class Form2 : Form
    {
        private List<RegistryConfig> registryConfigs;
        private string? FilePath;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            SetupListView();
        }

        private void SetupListView()/////////////////////////////////////
        {
            listView2.View = View.Details;
            listView2.Columns.Add("Registry Path", 440);
            listView2.Columns.Add("Name", 350);
            listView2.Columns.Add("Type", 200);
            listView2.Columns.Add("Registry Value", 200);
            listView2.Columns.Add("Text Value", 130);
            listView2.Columns.Add("Result", 100);
            listView2.Columns.Add("Found Status", 100);
        }

        public static string? ReadRegistryValue(string keyPath, string valueName)////////////////////////////////////
        {
            try
            {
                using (RegistryKey? key = Registry.LocalMachine.OpenSubKey(keyPath))
                {
                    if (key != null)
                    {
                        Object? o = key.GetValue(valueName);
                        return o?.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading the Registry: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }

        private void PopulateListView()////////////////////////////////////////
        {
            listView2.Items.Clear();

            foreach (var registryConfig in registryConfigs)
            {
                foreach (var keyVal in registryConfig.KeyVal)
                {
                    ListViewItem item = new ListViewItem(new[]
                    {
                        registryConfig.Path,
                        keyVal.Name,
                        keyVal.Data,
                        keyVal.TheType.ToString(),
                    });

                    listView2.Items.Add(item);
                }
            }
        }

        private void LoadTextFile(string filePath)///////////////////////////////////////
        {
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                registryConfigs = new List<RegistryConfig>();
                RegistryConfig? currentRegistryConfig = null;
                KeyValEntry? currentKeyValEntry = null;

                foreach (var line in lines)
                {
                    if (line.StartsWith("Key Name:"))
                    {
                        string fullPath = line.Substring("Key Name:".Length).Trim();
                        int softwareIndex = fullPath.IndexOf("SOFTWARE");

                        if (softwareIndex != -1)
                        {
                            string relevantPath = fullPath.Substring(softwareIndex).Trim();

                            if (currentRegistryConfig != null)
                            {
                                registryConfigs.Add(currentRegistryConfig);
                            }

                            currentRegistryConfig = new RegistryConfig
                            {
                                Path = relevantPath,
                                KeyVal = new List<KeyValEntry>()
                            };
                        }
                    }
                    else if (line.StartsWith("Value"))
                    {
                        currentKeyValEntry = new KeyValEntry
                        {
                            Name = string.Empty,
                            TheType = string.Empty,
                            Data = string.Empty
                        };
                    }
                    else if (line.StartsWith("  Name:"))
                    {
                        if (currentKeyValEntry != null)
                        {
                            currentKeyValEntry.Name = line.Substring("  Name:".Length).Trim();
                        }
                    }
                    else if (line.StartsWith("  Type:"))
                    {
                        if (currentKeyValEntry != null)
                        {
                            currentKeyValEntry.TheType = line.Substring("  Type:".Length).Trim();
                        }
                    }
                    else if (line.StartsWith("  Data:"))
                    {
                        if (currentKeyValEntry != null)
                        {
                            currentKeyValEntry.Data = line.Substring("  Data:".Length).Trim();
                            currentRegistryConfig?.KeyVal.Add(currentKeyValEntry);
                            currentKeyValEntry = null; // Reset for the next entry
                        }
                    }
                }

                // Add the last registry config after loop ends
                if (currentRegistryConfig != null)
                {
                    registryConfigs.Add(currentRegistryConfig);
                }

                PopulateListView();
            }
            catch (Exception ex)
            {
                //MessageBox.Show($"Error loading text file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CompareRegistryWithText()//////////////////////////////////////////////////
        {
            listView2.Items.Clear();

            foreach (var registryConfig in registryConfigs)
            {
                CompareRegistryEntry(registryConfig);
            }
        }

        private string CompareValues(string registryValue, string? textValue)///////////////////////////////////////
        {
            if (registryValue == "?" || textValue == "?")
                return "??";

            return registryValue.Equals(textValue, StringComparison.OrdinalIgnoreCase)
                ? "Match"
                : $"Mismatch: Registry='{registryValue}', Text='{textValue}'";
        }

        private void CompareRegistryEntry(RegistryConfig registryConfig)////////////////////////////////////////////
        {
            using (RegistryKey? key = Registry.LocalMachine.OpenSubKey(registryConfig.Path))
            {
                if (key != null)
                {
                    var registryValues = key.GetValueNames().ToDictionary(
                        name => name,
                        name => ReadRegistryValue(registryConfig.Path, name)
                    );

                    // Iterate through each KeyVal from the text file
                    foreach (var keyVal in registryConfig.KeyVal)
                    {
                        // Get the corresponding value from the registry
                        string? registryValue = registryValues.TryGetValue(keyVal.Name, out var rv) ? rv : "?";

                        // Compare names and values
                        string result = CompareValues(registryValue, keyVal.Data);
                        string foundStatus = registryValues.ContainsKey(keyVal.Name) ? "Found" : "Not Found";

                        // Create a ListViewItem to display the comparison result
                        ListViewItem item = new ListViewItem(new[]
                        {
                    registryConfig.Path,
                    keyVal.Name,
                    registryValue ?? "?",
                    keyVal.Data ?? "?",
                    keyVal.TheType ?? "Unknown", // Include type here
                    result,
                    foundStatus
                });

                        // Set color based on conditions
                        if (foundStatus == "Not Found")
                        {
                            item.BackColor = Color.Gold;
                        }
                        else if (result.StartsWith("Mismatch"))
                        {
                            item.BackColor = Color.Red;
                        }

                        listView2.Items.Add(item); // Add item to ListView
                    }
                }
                else
                {
                    // MessageBox.Show($"The registry key '{registryConfig.Path}' does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public class KeyValEntry
        {
            public required string Name { get; set; }
            public required string TheType { get; set; } 
            public required string Data { get; set; } 
        }

        public class RegistryConfig
        {
            public required string Path { get; set; }
            public required List<KeyValEntry> KeyVal { get; set; }
        }

        private void btnOpn_Click_1(object sender, EventArgs e)/////////////////////////////////////////////
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*",
                Title = "Select a Text file"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                lblCurrent.Text = openFileDialog.SafeFileName; // Display only the filename
                FilePath = openFileDialog.FileName; // Store the selected file path
                LoadTextFile(FilePath); // Load text file using stored path
                CompareRegistryWithText(); // Compare after loading the file
            }
        }

        private void btnretry_Click(object sender, EventArgs e)
        {
            listView2.Items.Clear();

            if (!string.IsNullOrEmpty(FilePath))
            {
                LoadTextFile(FilePath); // Load text file using stored path
                CompareRegistryWithText(); // Compare after loading the file
            }
            else
            {
                MessageBox.Show("No file selected. Please select a text file first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}