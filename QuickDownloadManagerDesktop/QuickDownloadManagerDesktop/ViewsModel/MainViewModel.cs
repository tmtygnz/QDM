using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using QuickDownloadManagerDesktop.Utilities;

namespace QuickDownloadManagerDesktop.ViewsModel
{
	class MainViewModel : ViewModelBase
	{

		public MainViewModel()
		{
			DataGridSource = new ObservableCollection<FilesViewModel>();
			DataGridSource.Add(new FilesViewModel {
				FileName = "TestFile",
				FileSize = "100kb",
				DateAdded = DateTime.Now
			});
		}

		private ObservableCollection<FilesViewModel> _dataGridSource;
		public ObservableCollection<FilesViewModel> DataGridSource
		{
			get => _dataGridSource;
			set
			{
				if (value == _dataGridSource)
					return;
				_dataGridSource = value;
				OnPropertyChanged();
			}
		}


		public ICommand AddURL_Command => new RelayCommand(param => AddURL_Action());
		public void AddURL_Action()
		{
			DataGridSource.Add(new FilesViewModel
			{
				FileName = "TestFile",
				FileSize = "100kb",
				DateAdded = DateTime.Now
			});
		}

		public ICommand ClearList_Command => new RelayCommand(param => ClearList_Action());
		public void ClearList_Action()
		{
			DataGridSource.Clear();
		}
	}
}
