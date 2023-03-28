using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Microsoft.Win32;

namespace WpfHexEditor.ReadOnlyBinding {

    public class MainWindowViewModel : INotifyPropertyChanged {

        #region Properties

        public string SelectedFile {
            get => selectedFile;
            private set {
                if (selectedFile == value) {
                    return;
                }

                selectedFile = value;
                NotifyOfPropertyChange();
            }
        } 

        public bool IsReadOnly {
            get => isReadOnly;
            set {
                if (isReadOnly == value) {
                    return;
                }

                isReadOnly = value;
                NotifyOfPropertyChange();
            }
        }

        public ICommand OpenFileCommand {
            get;
        }

        #endregion

        #region Fields

        private string selectedFile;
        private bool isReadOnly;

        #endregion

        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        public MainWindowViewModel() {
            OpenFileCommand = new RelayCommand(OpenFile);
        }

        protected void NotifyOfPropertyChange([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void OpenFile() {
            OpenFileDialog openFileDialog = new OpenFileDialog {
                InitialDirectory = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "TestFiles")),
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"
            };

            if (openFileDialog.ShowDialog() != true) {
                return;
            }

            SelectedFile = openFileDialog.FileName;
        }

    }

}
