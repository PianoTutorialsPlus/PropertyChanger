using PropertyChanger.View.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PropertyChanger
{
    public partial class MainView : Form, IMainView
    {
        public event Action<string[]> OnFileOpened;
        public event Action OnPropertiesChanged;

        public MainView()
        {
            InitializeComponent();
        }

        public List<string> Files
        {
            get => listBoxFiles.Items.Cast<string>().ToList(); 
            set
            {
                listBoxFiles.Items.Clear();
                listBoxFiles.Items.AddRange(value.ToArray());
            }
        }
        public List<string[]> Properties
        {
            get => listViewProperties.Items.Cast<string[]>().ToList();
            set
            {
                listViewProperties.Items.Clear();

                foreach(string[] entry in value)
                {
                    ListViewItem lvi = listViewProperties.Items.Add(entry[0]);
                    lvi.SubItems.Add(entry[1]);
                }
            }
        }

        private void buttonOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog
            {
                Multiselect = true,
                Filter = "MP3 (.mp3)|*.mp3"
            };
            fileDialog.ShowDialog();

            OnFileOpened?.Invoke(fileDialog.FileNames);
        }

        private void buttonChangeProperties_Click(object sender, EventArgs e)
        {
            OnPropertiesChanged?.Invoke();
        }
    }
}
