﻿using System;
using System.Data.Common;
using System.Threading.Tasks;
using System.Windows;
using DBManager.Application.View;
using DBManager.Application.ViewModel.ConnectionViewModel;
using DBManager.Default.Loaders;
using DBManager.Default.Tree;
using DBManager.Default.Tree.DbEntities;

namespace DBManager.Application.ViewModel.TreeViewModel
{
	public class TreeRootViewModel : MetadataViewModelBase
	{
		#region Fields

		private bool _isLoadingInProcess;

		private bool _isConnected;

		#endregion

		public bool IsConnected
		{
			get { return _isConnected; }
			set { SetProperty(ref _isConnected, value); }
		}

		public override DbObject Model { get; }

		public override DbEntityType Type => DbEntityType.Server;

		public override string Icon => "/Resources/Icons/Server.png";

		public ObjectLoader DbObjectLoader { get; }

		public override TreeRootViewModel Root => this;

		public bool IsLoadingInProcess
		{
			get { return _isLoadingInProcess; }
			set { SetProperty(ref _isLoadingInProcess, value); }
		}

		public bool IsDefaultDatabase { get; }

		public override string Name => Model.Name;

		public TreeRootViewModel(ObjectLoader objectLoader) : base(null, true)
		{
			DbObjectLoader = objectLoader;
			Model = new Server(DbObjectLoader.Connection.Server);
			IsDefaultDatabase = string.IsNullOrWhiteSpace(DbObjectLoader.Connection.InitialCatalog);
			IsConnected = true;
		}

		public TreeRootViewModel(DbObject model, ObjectLoader objectLoader) : base(null, true)
		{
			DbObjectLoader = objectLoader;
			Model = model;
			IsDefaultDatabase = string.IsNullOrWhiteSpace(DbObjectLoader.Connection.InitialCatalog);
			IsConnected = false;

		}
		

	}

}
