# MVVM Dialogs

![MVVM Dialogs logo](design/Icon_128x128.png)

### Introduction

MVVM Dialogs is a framework simplifying the concept of opening dialogs from a view model when using MVVM in WPF. It enables the developer to write unit tests for view models in the same way unit tests are written for other classes.

### Usage

Decorate the view with the attached property `DialogServiceViews.IsRegistered`:

```xaml
<UserControl
    x:Class="DemoApplication.Features.Dialog.Modal.Views.ModalDialogTabContent"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:md="https://github.com/fantasticfiasco/mvvm-dialogs"
    md:DialogServiceViews.IsRegistered="True">

  ...
  
</UserControl>
```

With the view registered the view model is now capable of opening a dialog using `IDialogService`:

```C#
public class ModalDialogTabContentViewModel : INotifyPropertyChanged
{
  private readonly IDialogService dialogService;

  public ModalDialogTabContentViewModel(IDialogService dialogService)
  {
    this.dialogService = dialogService;
  }

  ...

  private void ShowDialog()
  {
    var dialogViewModel = new AddTextDialogViewModel();

    bool? success = dialogService.ShowDialog(this, dialogViewModel);
    if (success == true)
    {
      Texts.Add(dialogViewModel.Text);
    }
  }
}
```

### Install MVVM Dialogs via NuGet

If you want to include MVVM Dialogs in your project, you can [install it directly from NuGet](https://www.nuget.org/packages/MvvmDialogs/).

To install MVVM Dialogs, run the following command in the Package Manager Console:

```
PM> Install-Package MvvmDialogs
```