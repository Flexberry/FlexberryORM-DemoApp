namespace NewPlatform.Flexberry.Samples
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Globalization;
    using System.IO;
    using System.Text;
    using System.Windows.Forms;

    /// <summary>
    /// User control for sample visualization.
    /// </summary>
    public partial class SamplesControl : UserControl
    {
        /// <summary>
        /// Samples by tree nodes.
        /// </summary>
        private readonly Dictionary<TreeNode, SampleData> _samples = new Dictionary<TreeNode, SampleData>();

        /// <summary>
        /// Text writer for output stream.
        /// </summary>
        private TextWriter _writer;

        /// <summary>
        /// Private field for property <see cref="SampleDataList"/>.
        /// </summary>
        private List<SampleData> _sampleDataList;

        /// <summary>
        /// Private field for property <see cref="SelectedSample"/>.
        /// </summary>
        private SampleData _selectedSample;

        /// <summary>
        /// Initialize the samples control.
        /// </summary>
        public SamplesControl()
        {
            InitializeComponent();
            SamplesTree.AfterSelect += SamplesTree_AfterSelect;
        }

        /// <summary>
        /// Handle event after select node in samples tree view.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="e">Event arguments.</param>
        private void SamplesTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SelectedSample = _samples[e.Node];
        }

        /// <summary>
        /// List of sample data for visualization.
        /// </summary>
        public List<SampleData> SampleDataList
        {
            get
            {
                return _sampleDataList;
            }

            set
            {
                _sampleDataList = value;
                FillSamplesTree(_sampleDataList);
            }
        }

        /// <summary>
        /// Fill the samples tree.
        /// </summary>
        /// <param name="sampleDataList">Samples data for filling.</param>
        private void FillSamplesTree(IEnumerable<SampleData> sampleDataList)
        {
            SamplesTree.BeginUpdate();
            SamplesTree.Nodes.Clear();
            AddChildTreeNode(SamplesTree.Nodes, sampleDataList);

            SamplesTree.EndUpdate();
        }

        /// <summary>
        /// Add child tree node collection.
        /// </summary>
        /// <param name="treeNodeCollection">Node collection for adding.</param>
        /// <param name="sampleDataList">Sample data list.</param>
        private void AddChildTreeNode(TreeNodeCollection treeNodeCollection, IEnumerable<SampleData> sampleDataList)
        {
            if (sampleDataList == null)
            {
                return;
            }

            foreach (SampleData sampleData in sampleDataList)
            {
                TreeNode node = new TreeNode(sampleData.SampleCaption);
                treeNodeCollection.Add(node);
                _samples.Add(node, sampleData);

                AddChildTreeNode(node.Nodes, sampleData.ChildNodesList);
            }
        }

        /// <summary>
        /// Selected in tree view sample.
        /// </summary>
        public SampleData SelectedSample
        {
            get
            {
                return _selectedSample;
            }

            set
            {
                _selectedSample = value;
                WikiUrlLinkLabel.Text = _selectedSample.WikiUrl;
                WebBrowserControl.Navigate(_selectedSample.WikiUrl);
                LogTextBox.Text = string.Empty;
            }
        }

        /// <summary>
        /// Handle event Wiki Url link clicked.
        /// </summary>
        /// <param name="sender">Link label.</param>
        /// <param name="e">Event arguments.</param>
        private void WikiUrlLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process process = new Process();
            process.StartInfo = new ProcessStartInfo { FileName = SelectedSample.WikiUrl };
            process.Start();
        }

        /// <summary>
        /// Handle click event for clear log tool strip button.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="e">Event arguments.</param>
        private void ClearLogToolStripButton_Click(object sender, EventArgs e)
        {
            LogTextBox.Text = string.Empty;
        }

        /// <summary>
        /// Handle click event for run sample tool strip button.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="e">Event arguments.</param>
        private void RunSampleToolStripButton_Click(object sender, EventArgs e)
        {
            RunSampleAction(SelectedSample);
        }

        /// <summary>
        /// Run sample action.
        /// </summary>
        /// <param name="sampleData">Sample data to run.</param>
        private void RunSampleAction(SampleData sampleData)
        {
            if (sampleData == null)
            {
                return;
            }

            if (sampleData.SampleAction != null)
            {
                sampleData.SampleAction.Invoke();
            }

            if (sampleData.ChildNodesList != null)
            {
                foreach (SampleData sample in sampleData.ChildNodesList)
                {
                    RunSampleAction(sample);
                }
            }
        }

        /// <summary>
        /// Handle load this control event. Set console output to the <see cref="LogTextBox"/>.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="e">Event arguments.</param>
        private void SamplesControl_Load(object sender, EventArgs e)
        {
            _writer = new TextBoxStreamWriter(LogTextBox);
            
            // Redirect the out Console stream.
            Console.SetOut(_writer);
        }

        /// <summary>
        /// Text box stream writer for logging samples run.
        /// </summary>
        public class TextBoxStreamWriter : TextWriter
        {
            /// <summary>
            /// The <see cref="TextBox"/> for output.
            /// </summary>
            private readonly TextBox _output;

            /// <summary>
            /// Text box stream writer for logging samples run.
            /// </summary>
            /// <param name="output">The <see cref="TextBox"/> for output.</param>
            public TextBoxStreamWriter(TextBox output)
            {
                _output = output;
            }

            /// <summary>
            /// Writes a character to the text stream.
            /// </summary>
            /// <param name="value">The character to write to the text stream. </param>
            /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception>
            /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
            /// <filterpriority>1</filterpriority>
            public override void Write(char value)
            {
                base.Write(value);

                // When character data is written, append it to the text box.
                _output.AppendText(value.ToString(CultureInfo.InvariantCulture));
            }

            /// <summary>
            /// Write to UTF-8 encoding.
            /// </summary>
            public override Encoding Encoding
            {
                get { return Encoding.UTF8; }
            }
        }
    }
}
