﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grabacr07.KanColleWrapper;
using Grabacr07.KanColleWrapper.Models;
using Livet;
using Livet.EventListeners;

namespace Grabacr07.KanColleViewer.ViewModels.Fleets
{
	/// <summary>
	/// 単一の艦隊情報を提供します。
	/// </summary>
	public class FleetViewModel : ViewModel
	{
		private readonly Fleet source;

		public ReSortieBarViewModel ReSortie { get; private set; }
		public ExpeditionViewModel Expedition { get; private set; }

		public int Id
		{
			get { return this.source.Id; }
		}

		public string Name
		{
			get { return string.IsNullOrEmpty(this.source.Name.Trim()) ? "(第 " + this.source.Id + " 艦隊)" : this.source.Name; }
		}

		/// <summary>
		/// 艦隊に所属している艦娘のコレクションを取得します。
		/// </summary>
		public ShipViewModel[] Ships
		{
			get { return this.source.GetShips().Select(x => new ShipViewModel(x)).ToArray(); }
		}

		/// <summary>
		/// 艦隊の状態を取得します。
		/// </summary>
		public ViewModel State
		{
			get
			{
				if (this.source.Ships.Length == 0)
				{
					return null;
				}
				if (this.source.State == FleetState.Expedition)
				{
					return this.Expedition;
				}
				if (this.source.State == FleetState.Repairing)
				{
					return new RepairingBarViewModel(source);
				}
				return this.ReSortie;
			}
		}

		public FleetViewModel(Fleet fleet)
		{
			this.source = fleet;

			this.CompositeDisposable.Add(new PropertyChangedEventListener(fleet)
			{
				(sender, args) => this.RaisePropertyChanged(args.PropertyName),
			});

			this.ReSortie = new ReSortieBarViewModel(this, fleet.ReSortie);
			this.CompositeDisposable.Add(this.ReSortie);

			this.Expedition = new ExpeditionViewModel(fleet.Expedition);
			this.CompositeDisposable.Add(this.Expedition);
		}
	}
}
