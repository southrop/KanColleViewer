using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grabacr07.KanColleViewer.Model;
using Livet;
using Livet.EventListeners;

namespace Grabacr07.KanColleViewer.ViewModels
{
	public class SettingsViewModel : ViewModel
	{
		public string ScreenshotFolder
		{
			get { return Settings.Current.ScreenshotFolder; }
			set { Settings.Current.ScreenshotFolder = value; }
		}

		#region IsEnglish 変更通知プロパティ

		public bool IsEnglish
		{
			get { return Settings.Current.English; }
			set { 
				if (Settings.Current.English != value)
				{
					Settings.Current.English = value;
					this.RaisePropertyChanged();
				}
			}
		}

		#endregion

		public SettingsViewModel()
		{
			this.CompositeDisposable.Add(new PropertyChangedEventListener(Settings.Current)
			{
				(sender, args) => this.RaisePropertyChanged(args.PropertyName),
			});
		}
	}
}
