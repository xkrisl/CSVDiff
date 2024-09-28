using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSVDiff
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        // Asynchronous method for reading all text from a file
        // I'm using an older .NET Framework, it's so not available natively
        public async Task<string[]> ReadAllLinesAsync(string path)
        {
            return await Task.Run(() => File.ReadAllLines(path));
        }

        // Asynchronous method for writing all text to a file
        // I'm using an older .NET Framework, it's so not available natively
        public async Task WriteAllTextAsync(string path, string contents)
        {
            await Task.Run(() => File.WriteAllText(path, contents));
        }

        private async void compareButton_Click(object sender, EventArgs e)
        {
            try
            {
                compareButton.Enabled = false;
                compareButton.Text = "Comparing...";

                string[] oldFileLines = await ReadAllLinesAsync(ofTextbox.Text);
                string[] newFileLines = await ReadAllLinesAsync(mfTextbox.Text);

                // Check if the CSV files are compatible with each other
                if (oldFileLines.Length > 0 && newFileLines.Length > 0)
                {
                    if (oldFileLines[0] != newFileLines[0])
                    {
                        MessageBox.Show("The CSV files are different from each other. Please check and try again!", "Mismatched File", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        resetOptions();
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("One or both CSV files are empty. Please check and try again!", "Empty File", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    resetOptions();
                    return;
                }

                bool changesDetected = false;
                string htmlOutput = null;
                string textOutput = null;

                // Check if any output is required
                bool generateHtml = genhtmlCheckbox.Checked;
                bool generateText = gentxtCheckbox.Checked;

                if (generateHtml)
                {
                    htmlOutput = "<html><body><table border='1' style='border-collapse:collapse; width:100%;'>";
                    if (oldFileLines.Length > 0 && newFileLines.Length > 0)
                    {
                        htmlOutput += GenerateHtmlHeader(oldFileLines[0], newFileLines[0], oldFileLines, newFileLines);
                    }
                }

                await Task.Run(() =>
                {
                    for (int i = 1; i < Math.Max(oldFileLines.Length, newFileLines.Length); i++)
                    {
                        string oldLine = i < oldFileLines.Length ? oldFileLines[i] : string.Empty;
                        string newLine = i < newFileLines.Length ? newFileLines[i] : string.Empty;

                        if (oldLine != newLine)
                        {
                            changesDetected = true;

                            if (generateHtml)
                            {
                                if (string.IsNullOrEmpty(oldLine))
                                {
                                    htmlOutput += GenerateHtmlRowDifferences(newLine, string.Empty, "green");
                                }
                                else
                                {
                                    htmlOutput += GenerateHtmlRowDifferences(oldLine, newLine, "red");
                                    htmlOutput += GenerateHtmlRowDifferences(newLine, oldLine, "green");
                                }
                                htmlOutput += "<tr><td colspan='100%' style='height:45px;'></td></tr>";
                            }

                            if (generateText)
                            {
                                if (string.IsNullOrEmpty(oldLine))
                                {
                                    textOutput += GenerateTextDifferences("################################################################\nNew:", string.Empty, newLine);
                                }
                                else
                                {
                                    textOutput += GenerateTextDifferences("################################################################\nOriginal:", oldLine, newLine);
                                    textOutput += GenerateTextDifferences("Modified:", newLine, oldLine);
                                }
                            }
                        }
                    }
                });

                if (!changesDetected)
                {
                    MessageBox.Show("Completed successfully! No changes were detected.");
                    resetOptions();
                    return;
                }

                if (generateHtml)
                {
                    htmlOutput += "</table></body></html>";
                    string fileName = Path.GetFileName(ofTextbox.Text);
                    string htmlFilePath = $"{fileName}_{DateTime.Now:MMddyyyy}.html";
                    await WriteAllTextAsync(htmlFilePath, htmlOutput);

                    if (MessageBox.Show($"Do you want to open {htmlFilePath} in your web browser?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Process.Start(new ProcessStartInfo(htmlFilePath) { UseShellExecute = true });
                    }
                }

                if (generateText)
                {
                    string fileName = Path.GetFileName(ofTextbox.Text);
                    string textFilePath = $"{fileName}_{DateTime.Now:MMddyyyy}.txt";
                    await WriteAllTextAsync(textFilePath, textOutput);

                    if (MessageBox.Show($"Do you want to open {textFilePath}?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Process.Start(new ProcessStartInfo(textFilePath) { UseShellExecute = true });
                    }
                }

                MessageBox.Show("Completed successfully! The files have been generated and saved locally according to your selected options.");
                resetOptions();
                return;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        // Generate the HTML header row based on both files
        private string GenerateHtmlHeader(string oldHeader, string newHeader, string[] oldFileLines, string[] newFileLines)
        {
            string[] oldColumns = oldHeader.Split(',');
            string[] newColumns = newHeader.Split(',');

            string html = "<tr>";
            for (int i = 0; i < Math.Max(oldColumns.Length, newColumns.Length); i++)
            {
                string column = i < oldColumns.Length ? oldColumns[i] : (i < newColumns.Length ? newColumns[i] : "");
                int maxLength = GetMaxColumnLength(i, oldFileLines, newFileLines);
                html += $"<th style='width:{maxLength}px;'>{column}</th>";
            }
            html += "</tr>";
            return html;
        }

        // Get the maximum column length for consistent column widths
        private int GetMaxColumnLength(int columnIndex, string[] oldFileLines, string[] newFileLines)
        {
            int maxLength = 0;

            // Check the old file rows
            foreach (var line in oldFileLines)
            {
                string[] columns = line.Split(',');
                if (columnIndex < columns.Length)
                {
                    maxLength = Math.Max(maxLength, columns[columnIndex].Trim('"').Length);
                }
            }

            // Check the new file rows
            foreach (var line in newFileLines)
            {
                string[] columns = line.Split(',');
                if (columnIndex < columns.Length)
                {
                    maxLength = Math.Max(maxLength, columns[columnIndex].Trim('"').Length);
                }
            }

            return maxLength;
        }

        // Generate HTML rows to highlight differences
        private string GenerateHtmlRowDifferences(string line1, string line2, string color)
        {
            string[] segments1 = line1.Split(',');
            string[] segments2 = line2.Split(',');

            string html = "<tr>";
            for (int i = 0; i < Math.Max(segments1.Length, segments2.Length); i++)
            {
                string segment1 = i < segments1.Length ? segments1[i].Trim('"') : "";
                string segment2 = i < segments2.Length ? segments2[i].Trim('"') : "";

                // Highlight the background of changed cells
                html += $"<td style='background-color:{(segment1 != segment2 ? color : "white")};'>{segment1}</td>";
            }
            html += "</tr>";
            return html;
        }

        // Generate text output to show the differences
        private string GenerateTextDifferences(string label, string line1, string line2)
        {
            string text = $"{label}\n";
            text += HighlightTextDifferences(line1, line2);
            text += "\n\n";
            return text;
        }

        // Highlight differences in the text output
        private string HighlightTextDifferences(string line1, string line2)
        {
            int index1 = 0, index2 = 0;
            string text = null;

            // Compare both lines character by character
            while (index1 < line1.Length && index2 < line2.Length)
            {
                if (line1[index1] == '"' && line2[index2] == '"')
                {
                    int end1 = line1.IndexOf('"', index1 + 1);
                    int end2 = line2.IndexOf('"', index2 + 1);

                    string segment = line1.Substring(index1 + 1, end1 - index1 - 1);

                    text += $"\"{segment}\"";

                    index1 = end1 + 1;
                    index2 = end2 + 1;
                }
                else
                {
                    text += line1[index1];
                    index1++;
                    index2++;
                }
            }

            // Append remaining part of the new line if it is longer
            if (index2 < line2.Length)
            {
                text += line2.Substring(index2);
            }

            return text;
        }

        // Open *.csv file for filepath
        private void ofButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // Filter to only show .csv files
                openFileDialog.Filter = "CSV files (*.csv)|*.csv";
                openFileDialog.Title = "Select CSV File";

                // Check if the user selected a file
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ofTextbox.Text = openFileDialog.FileName;
                    mfButton.Enabled = true;
                }
            }
        }

        // Open *.csv file for filepath
        private void mfButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // Filter to only show .csv files
                openFileDialog.Filter = "CSV files (*.csv)|*.csv";
                openFileDialog.Title = "Select CSV File";

                // Check if the user selected a file
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    mfTextbox.Text = openFileDialog.FileName;
                    genhtmlCheckbox.Enabled = true;
                    gentxtCheckbox.Enabled = true;
                    compareButton.Enabled = true;
                }
            }
        }

        // Reset MainWindow form
        private void resetOptions()
        {
            ofTextbox.Text = mfTextbox.Text = null;

            mfButton.Enabled = genhtmlCheckbox.Enabled = gentxtCheckbox.Enabled = compareButton.Enabled = false;

            genhtmlCheckbox.Checked = gentxtCheckbox.Checked = true;

            compareButton.Text = "Compare";
        }
    }
}