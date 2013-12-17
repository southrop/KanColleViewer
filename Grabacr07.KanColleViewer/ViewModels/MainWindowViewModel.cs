﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Grabacr07.KanColleViewer.Model;
using Grabacr07.KanColleViewer.ViewModels.Contents;
using Grabacr07.KanColleViewer.ViewModels.Messages;
using Grabacr07.KanColleWrapper;
using Livet;
using Livet.EventListeners;

namespace Grabacr07.KanColleViewer.ViewModels
{
	public class MainWindowViewModel : WindowViewModel
	{
		private Mode currentMode;
		private MainContentViewModel mainContent;

		public NavigatorViewModel Navigator { get; private set; }
		public VolumeViewModel Volume { get; private set; }

		#region Mode 変更通知プロパティ

		public Mode Mode
		{
			get { return this.currentMode; }
			set
			{
				this.currentMode = value;
				switch (value)
				{
					case Mode.NotStarted:
						this.Content = NotStartedViewModel.Instance;
						StatusService.Current.Set(Properties.Resources.Status_NotStarted);
						ThemeService.Current.Accent = Accent.Purple;
						break;
					case Mode.Started:
						this.Content = this.mainContent ?? (this.mainContent = new MainContentViewModel());
						StatusService.Current.Set(Properties.Resources.Status_Ready);
						ThemeService.Current.Accent = Accent.Blue;
						break;
					case Mode.InSortie:
						// 今後の実装にご期待ください
						ThemeService.Current.Accent = Accent.Orange;
						break;
				}

				this.RaisePropertyChanged();
			}
		}

		#endregion

		#region Content 変更通知プロパティ

		private ViewModel _Content;

		public ViewModel Content
		{
			get { return this._Content; }
			set
			{
				if (this._Content != value)
				{
					this._Content = value;
					this.RaisePropertyChanged();
				}
			}
		}

		#endregion

		#region StatusMessage 変更通知プロパティ

		private string _StatusMessage;

		public string StatusMessage
		{
			get { return this._StatusMessage; }
			set
			{
				if (this._StatusMessage != value)
				{
					this._StatusMessage = value;
					this.RaisePropertyChanged();
				}
			}
		}

		#endregion

		#region StatusBar 変更通知プロパティ

		private ViewModel _StatusBar;

		public ViewModel StatusBar
		{
			get { return this._StatusBar; }
			set
			{
				if (this._StatusBar != value)
				{
					this._StatusBar = value;
					this.RaisePropertyChanged();
				}
			}
		}

		#endregion

		public MainWindowViewModel()
		{
			this.Title = Properties.Resources.MainWindow_Title;
			this.Navigator = new NavigatorViewModel();
			this.Volume = new VolumeViewModel();

			this.CompositeDisposable.Add(new PropertyChangedEventListener(StatusService.Current)
			{
				{ () => StatusService.Current.Message, (sender, args) => this.StatusMessage = StatusService.Current.Message },
			});
			this.CompositeDisposable.Add(new PropertyChangedEventListener(KanColleClient.Current)
			{
				{ () => KanColleClient.Current.IsStarted, (sender, args) => this.Mode = Mode.Started },
			});

			this.Mode = Mode.NotStarted;
		}

		public void TakeScreenshot()
		{
			var path = Helper.CreateScreenshotFilePath();
			var message = new ScreenshotMessage("Screenshot/Save") { Path = path, };

			this.Messenger.Raise(message);

			var notify = message.Response.IsSuccess
				? "スクリーンショットを保存しました: " + Path.GetFileName(path)
				: "スクリーンショットの保存に失敗しました: " + message.Response.Exception.Message;
			StatusService.Current.Notify(notify);
		}
	}
}
