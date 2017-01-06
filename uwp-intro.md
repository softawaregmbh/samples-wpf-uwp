# Universal Windows Platform

## Todo
* .NET Standard


## Intro
* Some thoughts about the differences between the desktop and the app world: (Desktop was yesterday)[uwp/slides/desktop-was-yesterday.pptx]
* Slide deck: (Windows 10 for developers)[slides/uwp/windows10-for-developers.pptx]

## Create a UWP app
* Discuss the created files
  * package.appxmanifest
* Add MVVMLight

## Changes to WPF
* TextBlock: Header property
* x:Bind syntax
* AutoSuggestBox
* Responsive layout (more details below)


## Offline scenarios
* Storage API
* SQLite
  * VS Extensions: SQLite for Universal App Platform

## Navigation with Behaviors SDK
* Add namespaces

```xml
xmlns:interactivity="using:Microsoft.Xaml.Interactivity"
xmlns:core="using:Microsoft.Xaml.Interactions.Core"

<Image Source="{Binding ImagePath}" [...]>
  <interactivity:Interaction.Behaviors>
    <core:EventTriggerBehavior 
      EventName="Tapped">

      <core:NavigateToPageAction 
        TargetPage=
          "Cookbook.Views.RecipeDetailView"
        Parameter="{Binding Id}" />

    </core:EventTriggerBehavior>
  </interactivity:Interaction.Behaviors>
</Image>
```

## Responsive Layout and Device awareness

### Visual State Triggers

```cs
<VisualStateManager.VisualStateGroups>
	<VisualStateGroup x:Name="WindowSizeStates">
		<VisualState x:Name="WideState">
			<VisualState.StateTriggers>
				<AdaptiveTrigger MinWindowWidth="1024" />
			</VisualState.StateTriggers>
			<VisualState.Setters>
				<Setter Target="splitView.IsPaneOpen" Value="True" />
				<Setter Target="splitView.DisplayMode" Value="Inline" />
			</VisualState.Setters>
		</VisualState>
	</VisualStateGroup>
</VisualStateManager.VisualStateGroups>
```

### RelativePanel


### Capability Check

* ApiInformation.IsTypePresent
  * Windows.Phone.UI.Input.HardwareButtons
  * Windows.Phone.Devices.Notification.VibrationDevice
* Mobile Extension SDK hinzufügen

### DeviceFamily

* Unterordner anlegen “DeviceFamily-Mobile”
    * Mobile, Desktop, Team, Xbox
* XAML View statt Page anlegen  Codebehind wird geshared
* Recources mit Style
* Ressourcen: “Logo.DeviceFamily-Mobile.png”
    * ms-appx:///Images/Logo.png

## Live Tiles

```cs
var updater = TileUpdateManager.CreateTileUpdaterForApplication();
//updater.EnableNotificationQueue(true);

XmlDocument xml = TileUpdateManager.GetTemplateContent(TileTemplateType.TileSquare150x150Image);
var all = xml.GetXml();
var image = xml.GetElementsByTagName(“image”)[0] as XmlElement;
image.SetAttribute(“src”, person.Photo);
updater.Update(new TileNotification(tileDefinition));
```

