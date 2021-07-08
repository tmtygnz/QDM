using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickDownloadManagerDesktop.Utilities;

namespace QuickDownloadManagerDesktop.ViewsModel
{
	class FilesViewModel : ViewModelBase
	{
		private string _fileName;
		public string FileName
		{
			get => _fileName;
			set
			{
				if (value == _fileName)
					return;
				_fileName = value;
				OnPropertyChanged();
			}
		}

		private string _fileSize;
		public string FileSize
		{
			get => _fileSize;
			set
			{
				if (value == _fileSize)
					return;
				_fileSize = value;
				OnPropertyChanged();
			}
		}

		private DateTime _dateAdded;
		public DateTime DateAdded
		{
			get => _dateAdded;
			set
			{
				if (value == _dateAdded)
					return;
				_dateAdded = value;
				OnPropertyChanged();
			}
		}
	}
}
