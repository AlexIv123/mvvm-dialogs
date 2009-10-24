﻿using System;
using System.Windows.Forms;
using FormsFolderBrowserDialog = System.Windows.Forms.FolderBrowserDialog;

namespace MVVM_Dialogs.Service.FrameworkDialogs.FolderBrowse
{
	/// <summary>
	/// Class wrapping System.Windows.Forms.FolderBrowserDialog, making it accept a ViewModel.
	/// </summary>
	class FolderBrowserDialog : IDisposable
	{
		private FormsFolderBrowserDialog folderBrowserDialog;
		private FolderBrowserDialogViewModel viewModel;


		public FolderBrowserDialog(FolderBrowserDialogViewModel viewModel)
		{
			this.viewModel = viewModel;

			// Create FolderBrowserDialog
			folderBrowserDialog = new FormsFolderBrowserDialog
			{
				Description = viewModel.Description,
				SelectedPath = viewModel.SelectedPath,
				ShowNewFolderButton = viewModel.ShowNewFolderButton
			};
		}


		/// <summary>
		/// Runs a common dialog box with the specified owner.
		/// </summary>
		/// <param name="owner">Any object that implements System.Windows.Forms.IWin32Window that
		/// represents the top-level window that will own the modal dialog box.</param>
		/// <returns>System.Windows.Forms.DialogResult.OK if the user clicks OK in the dialog box;
		/// otherwise, System.Windows.Forms.DialogResult.Cancel.</returns>
		public DialogResult ShowDialog(IWin32Window owner)
		{
			DialogResult result = folderBrowserDialog.ShowDialog(owner);

			// Update ViewModel
			viewModel.SelectedPath = folderBrowserDialog.SelectedPath;

			return result;
		}


		#region IDisposable Members

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting
		/// unmanaged resources.
		/// </summary>
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}


		~FolderBrowserDialog()
		{
			Dispose(false);
		}


		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (folderBrowserDialog != null)
				{
					folderBrowserDialog.Dispose();
					folderBrowserDialog = null;
				}
			}
		}

		#endregion
	}
}