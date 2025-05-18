using Microsoft.AspNetCore.Components;
using Microsoft.FluentUI.AspNetCore.Components;

namespace BridgeMall.Helpers
{
	public class MessageBoxHelper(IDialogService dialogService)
	{
		private readonly IDialogService _dialogService = dialogService;

		public async Task ShowSuccessAsync(string message)
		{
			var dialog = await _dialogService.ShowMessageBoxAsync(new DialogParameters<MessageBoxContent>
			{
				Width = "320px",
				Content = new()
				{
					Title = "Success",
					Message = message,
					Icon = new Microsoft.FluentUI.AspNetCore.Components.Icons.Regular.Size24.CheckmarkCircle(),
					IconColor = Color.Success,
				},
				PrimaryAction = "Ok",
				SecondaryAction = null,
				SecondaryActionEnabled = false
			}
			);
			_ = await dialog.Result;
		}

		public async Task ShowInfoAsync(string title, string message)
		{
			_ = await _dialogService.ShowInfoAsync(title, message);
		}

		public async Task ShowErrorAsync(string message)
		{
			var dialog = await _dialogService.ShowMessageBoxAsync(new DialogParameters<MessageBoxContent>
			{
				Width = "320px",
				Content = new()
				{
					Title = "Error",
					Message = message,
					Icon = new Microsoft.FluentUI.AspNetCore.Components.Icons.Regular.Size24.ErrorCircle(),
					IconColor = Color.Error,
				},
				PrimaryAction = "Ok",
				SecondaryAction = null,
				SecondaryActionEnabled = false
			}
			);
			dialog.Instance.Parameters.Width = "300px";
			_ = await dialog.Result;
		}

		public async Task ShowMessageBoxAsync(string title, string message, string ok, string cancel, MessageBoxCallback callback)
		{
			var dialog = await _dialogService.ShowMessageBoxAsync(new DialogParameters<MessageBoxContent>()
			{
				Content = new()
				{
					Title = title,
					MarkupMessage = new MarkupString(message),
					Icon = new Microsoft.FluentUI.AspNetCore.Components.Icons.Regular.Size24.Games(),
					IconColor = Color.Error,
				},
				PrimaryAction = ok,
				SecondaryAction = cancel,
				Width = "320px",
			});
			var result = await dialog.Result;
			if (!result.Cancelled)
			{
				callback();
			}
		}

		public delegate void MessageBoxCallback();
	}
}
