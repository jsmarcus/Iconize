# Iconize Plugin for Xamarin
A .NET for Xamarin port of the [android-iconify](https://github.com/JoanZapata/android-iconify) project.
Use icon fonts in your Xamarin.Android, Xamarin.iOS, or Xamarin.Forms application!

**NuGet**
* Available on NuGet: http://www.nuget.org/packages/Xam.Plugin.Iconize [![NuGet](https://img.shields.io/nuget/v/Xam.Plugin.Media.svg?label=NuGet)](https://www.nuget.org/packages/Xam.Plugin.Iconize/)
* Install into your PCL project and Client projects.

**Build Status** 
* [![Build status](https://ci.appveyor.com/api/projects/status/8ibyfk1rxn3mun3a?svg=true)](https://ci.appveyor.com/project/JeremyMarcus/iconize)
* CI NuGet Feed: https://ci.appveyor.com/nuget/iconize

## Icon Fonts

* [Entypo+](http://entypo.com/) - pictograms by Daniel Bruce
* [Font Awesome](http://fortawesome.github.io/Font-Awesome/)
* [Ionicons](http://ionicons.com/)
* [Material design icons](http://google.github.io/material-design-icons/)
* [Meteocons](http://www.alessioatzeni.com/meteocons/)
* [Simple Line Icons](https://github.com/thesabbir/simple-line-icons)
* [Typicons](https://github.com/stephenhutchings/typicons.font)
* [Weather Icons](http://weathericons.io)

**Font Requests**  
If you have an icon font or series of svg pictograms you'd like included, just submit an issue or pull request and we'll work to add it.

**Extensibility**  
In case you can't find the icon you want, you can extend the available icon directly from your app.
All you need to do is to implement IIconModule with a .ttf file in your assets/resources and provide the mapping between keys and special characters, then give it to Iconize.With().

There are no constraints on the icon keys, but I strongly suggest you use a unique prefix like my- or anything, to avoid conflicts with other modules.
FYI, if there is a conflict, the first module declared with Iconize.With() has priority.

## Controls

**Xamarin.Android (AppCompat)**

* IconButton (AppCompatButton)
* IconDrawable (Drawable)
* IconTextView (TextView)
* IconToggleButton (ToggleButton)

**Xamarin.iOS (Unified)**

* IconButton (UIButton)
* IconLabel (UILabel)
* UIImage (extension)

**Xamarin.Forms**

* IconButton (Button)
* IconImage (Image)
* IconLabel (Label)
* IconTabbedPage (TabbedPage)
* IconToolbarItem (ToolbarItem)

**UWP (Coming Soon)**

* IconButton (Button)
* IconLabel (TextBlock)
* Bitmap (extension)


## Setup

### Install

**Nuget**  
All packages are provided via NuGet.

* [Xam.Plugin.Iconize](https://www.nuget.org/packages/Xam.Plugin.Iconize) - Required by all projects
* [Xam.FormsPlugin.Iconize](https://www.nuget.org/packages/Xam.FormsPlugin.Iconize) - Required by Xamarin.Forms projects
* [Xam.Plugin.Iconize.FontAwesome](https://www.nuget.org/packages/Xam.Plugin.Iconize.FontAwesome)
* [Xam.Plugin.Iconize.Ionicons](https://www.nuget.org/packages/Xam.Plugin.Iconize.Ionicons)
* [Xam.Plugin.Iconize.Material](https://www.nuget.org/packages/Xam.Plugin.Iconize.Material)
* [Xam.Plugin.Iconize.Meteocons](https://www.nuget.org/packages/Xam.Plugin.Iconize.Meteocons)
* [Xam.Plugin.Iconize.SimpleLineIcons](https://www.nuget.org/packages/Xam.Plugin.Iconize.SimpleLineIcons)
* [Xam.Plugin.Iconize.Typicons](https://www.nuget.org/packages/Xam.Plugin.Iconize.Typicons)
* [Xam.Plugin.Iconize.WeatherIcons](https://www.nuget.org/packages/Xam.Plugin.Iconize.WeatherIcons)

### Configure

**Xamarin.Android**  
Initialize any number of modules in Application.OnCreate() or Activity.OnCreate().
```csharp
public override void OnCreate()
{
    base.OnCreate();

    Plugin.Iconize.Iconize.With(new Plugin.Iconize.Fonts.FontAwesomeModule())
                          .With(new Plugin.Iconize.Fonts.MaterialModule())
                          .With(new Plugin.Iconize.Fonts.MeteoconsModule())
                          .With(new Plugin.Iconize.Fonts.TypiconsModule());
    ...
}
```
**OR**
```csharp
protected override void OnCreate(Bundle bundle)
{
    base.OnCreate(bundle);

    Plugin.Iconize.Iconize.With(new Plugin.Iconize.Fonts.FontAwesomeModule())
                          .With(new Plugin.Iconize.Fonts.MaterialModule())
                          .With(new Plugin.Iconize.Fonts.MeteoconsModule())
                          .With(new Plugin.Iconize.Fonts.TypiconsModule());
    ...
}
```


**Xamarin.iOS**  
Initialize any number of modules in AppDelegate.FinishedLaunching().
```csharp
public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
{
    Plugin.Iconize.Iconize.With(new Plugin.Iconize.Fonts.FontAwesomeModule())
                          .With(new Plugin.Iconize.Fonts.MaterialModule())
                          .With(new Plugin.Iconize.Fonts.MeteoconsModule())
                          .With(new Plugin.Iconize.Fonts.TypiconsModule());

    ...
}
```

Add the UIAppFonts key to Info.plist.
```xml
<key>UIAppFonts</key>
<array>
    <string>iconize-fontawesome.ttf</string>
    <string>iconize-material.ttf</string>
    <string>iconize-meteocons.ttf</string>
    <string>iconize-typicons.ttf</string>
</array>
```

**Xamarin.Forms**  
Follow the instructions for the specific platforms above and add the following:

Android:
```csharp
Xamarin.Forms.Forms.Init(this, savedInstanceState);
...
FormsPlugin.Iconize.Droid.IconControls.Init(Resource.Id.toolbar, Resource.Id.tabs);
...
LoadApplication(new App());
```

iOS:
```csharp
Xamarin.Forms.Forms.Init();
...
FormsPlugin.Iconize.iOS.IconControls.Init();
...
LoadApplication(new App());
```

## Contributions

* Jeremy Marcus [@jsmarcus](https://github.com/jsmarcus)
* Riccardo Marraghini [@marra85](https://github.com/marra85)
* Kevin Petit [@kvpt](https://github.com/kvpt)

## License
This work is licensed under a [Apache License, Version 2.0](http://www.apache.org/licenses/LICENSE-2.0).

**Entypo+**  
Entypo+ is licensed under the [Creative Commons Attribution-ShareAlike 4.0 International License (CC BY-SA 4.0)](http://creativecommons.org/licenses/by-sa/4.0/)

**Font Awesome**  
Font Awesome is licensed under the [SIL Open Font License 1.1](http://scripts.sil.org/OFL).

**Ionicons**  
Ionicons is licensed under the [MIT License](http://opensource.org/licenses/MIT).

**Material design icons**  
Material design icons are licensed under the [Apache License, Version 2.0](http://www.apache.org/licenses/LICENSE-2.0).

**Meteocons**  
Meteocons are provided as free icons by the creator, [Alessio Atzeni](http://www.alessioatzeni.com/).

**Simple Line Icons**  
Simple Line Icons are licensed under the [MIT License](http://opensource.org/licenses/MIT).

**Typicons**  
Typicons is licensed under the [SIL Open Font License 1.1](http://scripts.sil.org/OFL).

**Weather Icons**  
Weather Icons are licensed under the [SIL Open Font License 1.1](http://scripts.sil.org/OFL).

**Brand Icons**  
All brand icons are trademarks of their respective owners.
The use of these trademarks does not indicate endorsement of the trademark holder by Iconize, nor vice versa.
Brand icons should only be used to represent the company or product to which they refer.
