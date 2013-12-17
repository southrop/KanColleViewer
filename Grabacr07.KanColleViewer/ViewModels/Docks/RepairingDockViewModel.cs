﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grabacr07.KanColleViewer.Model;
using Grabacr07.KanColleWrapper.Models;
using Livet;
using Livet.EventListeners;
using Livet.Messaging.Windows;

namespace Grabacr07.KanColleViewer.ViewModels.Docks
{
	public class RepairingDockViewModel : ViewModel
	{
		private readonly RepairingDock source;

		public int Id
		{
			get { return this.source.Id; }
		}

		public string Ship
		{
			get { return source.Ship == null ? "----" : source.Ship.Info.Name; }
		}

		public string CompleteTime
		{
			get { return source.CompleteTime.HasValue ? source.CompleteTime.Value.LocalDateTime.ToString("MM/dd HH:mm") : "--/-- --:--:--"; }
		}

		public string Remaining
		{
			get { return source.Remaining.HasValue ? source.Remaining.Value.ToString(@"hh\:mm\:ss") : "--:--:--"; }
		}

		public RepairingDockState State
		{
			get { return this.source.State; }
		}

		#region IsNotifyCompleted 変更通知プロパティ

		private bool _IsNotifyCompleted;

		public bool IsNotifyCompleted
		{
			get { return this._IsNotifyCompleted; }
			set
			{
				if (this._IsNotifyCompleted != value)
				{
					this._IsNotifyCompleted = value;
					this.RaisePropertyChanged();
				}
			}
		}

		#endregion

		public RepairingDockViewModel(RepairingDock source)
		{
			this.source = source;
			this.CompositeDisposable.Add(new PropertyChangedEventListener(source, (sender, args) => this.RaisePropertyChanged(args.PropertyName)));

			if (Helper.IsWindows8OrGreater)
			{
				source.Completed += (sender, args) =>
				{
					if (this.IsNotifyCompleted)
					{
						Toast.Show(
							Properties.Resources.Repairyard_Complete,
							Properties.Resources.Repairyard_Finished1 + this.Id + Properties.Resources.Repairyard_Finished2 + this.Ship + Properties.Resources.Repairyard_Finished3,
							() => this.Messenger.Raise(new WindowActionMessage(WindowAction.Active, "Window/Activate")));
					}
				};
			}
		}
	}
}