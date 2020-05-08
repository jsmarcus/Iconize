# Iconize Plugin for Xamarin Forms

Use icon fonts in your Xamarin.Forms application!

**NuGet**

* Available on NuGet: [![NuGet](https://img.shields.io/nuget/v/Xam.Plugin.Iconize.svg?label=NuGet)](https://www.nuget.org/packages/Xam.Plugin.Iconize/)

**Build Status**

* [![Build status](https://ci.appveyor.com/api/projects/status/8ibyfk1rxn3mun3a?svg=true)](https://ci.appveyor.com/project/JeremyMarcus/iconize)
* CI NuGet Feed: https://ci.appveyor.com/nuget/iconize

## Icon Fonts

* [Entypo+](http://entypo.com/)
  * pictograms by Daniel Bruce
  * Version: 5/3, 2015
* [Font Awesome](http://fortawesome.github.io/Font-Awesome/)
  * Version: 5.8.1
* [Font Awesome Pro](https://github.com/FortAwesome/Font-Awesome-Pro/)
  * Version: 5.8.1
* [Google Material Icons](http://google.github.io/material-design-icons/)
  * Version: 3.0.1
* [Ionicons](http://ionicons.com/)
  * Version: 4.5.6
* [Jam Icons](https://jam-icons.com/)
  * Version: 2.0.0
* [Material Design Icons](https://materialdesignicons.com/)
  * Version: 5.1.45
* [Meteocons](http://www.alessioatzeni.com/meteocons/)
  * Version: 1.0
* [Simple Line Icons](https://github.com/thesabbir/simple-line-icons)
  * Version: 2.4.1
* [Typicons](https://github.com/stephenhutchings/typicons.font)
  * Version: 2.0.7
* [Weather Icons](http://weathericons.io)
  * Version: 2.0.10

**Font Requests**  
If you have an icon font or series of svg pictograms you'd like included, just submit an issue or pull request and we'll work to add it.

**Extensibility**  
In case you can't find the icon you want, you can extend the available icon directly from your app.
All you need to do is to implement IIconModule with a .ttf file in your assets/resources and provide the mapping between keys and special characters, then give it to Iconize.With().

There are no constraints on the icon keys, but I strongly suggest you use a unique prefix like my- or anything, to avoid conflicts with other modules.
FYI, if there is a conflict, the first module declared with Iconize.With() has priority.

## Controls

### Xamarin.Forms

* IconButton (Button)
* IconImage (Image)
* IconLabel (Label)
* IconTabbedPage (TabbedPage)
* IconToolbarItem (ToolbarItem)
  * Requires IconNavigationPage

## Setup

**Nuget**  
All packages are provided via NuGet.

* [Xam.Plugin.Iconize](https://www.nuget.org/packages/Xam.Plugin.Iconize)
* [Xam.Plugin.Iconize.EntypoPlus](https://www.nuget.org/packages/Xam.Plugin.Iconize.EntypoPlus)
* [Xam.Plugin.Iconize.FontAwesome](https://www.nuget.org/packages/Xam.Plugin.Iconize.FontAwesome)
* [Xam.Plugin.Iconize.FontAwesomePro](https://www.nuget.org/packages/Xam.Plugin.Iconize.FontAwesomePro)
* [Xam.Plugin.Iconize.Ionicons](https://www.nuget.org/packages/Xam.Plugin.Iconize.Ionicons)
* [Xam.Plugin.Iconize.JamIcons](https://www.nuget.org/packages/Xam.Plugin.Iconize.JamIcons)
* [Xam.Plugin.Iconize.Material](https://www.nuget.org/packages/Xam.Plugin.Iconize.Material)
* [Xam.Plugin.Iconize.MaterialDesignIcons](https://www.nuget.org/packages/Xam.Plugin.Iconize.MaterialDesignIcons)
* [Xam.Plugin.Iconize.Meteocons](https://www.nuget.org/packages/Xam.Plugin.Iconize.Meteocons)
* [Xam.Plugin.Iconize.SimpleLineIcons](https://www.nuget.org/packages/Xam.Plugin.Iconize.SimpleLineIcons)
* [Xam.Plugin.Iconize.Typicons](https://www.nuget.org/packages/Xam.Plugin.Iconize.Typicons)
* [Xam.Plugin.Iconize.WeatherIcons](https://www.nuget.org/packages/Xam.Plugin.Iconize.WeatherIcons)

## Configure

**Core Project**  
Initialize any number of modules in App.cs constructor.

```csharp
public App()
{
    ...
    Plugin.Iconize.Iconize.With(new Plugin.Iconize.Fonts.EntypoPlusModule())
                          .With(new Plugin.Iconize.Fonts.FontAwesomeRegularModule())
                          .With(new Plugin.Iconize.Fonts.FontAwesomeBrandsModule())
                          .With(new Plugin.Iconize.Fonts.FontAwesomeSolidModule());
                          .With(new Plugin.Iconize.Fonts.IoniconsModule())
                          .With(new Plugin.Iconize.Fonts.MaterialModule())
                          .With(new Plugin.Iconize.Fonts.MaterialDesignIconsModule())
                          .With(new Plugin.Iconize.Fonts.MeteoconsModule())
                          .With(new Plugin.Iconize.Fonts.SimpleLineIconsModule())
                          .With(new Plugin.Iconize.Fonts.TypiconsModule())
                          .With(new Plugin.Iconize.Fonts.WeatherIconsModule());
    ...
}
```

**Xamarin.Android (AppCompat)**  
Initialize the IconControls.

```csharp
protected override void OnCreate(Bundle savedInstanceState)
{
    Xamarin.Forms.Forms.Init(this, savedInstanceState);
    ...
    Plugin.Iconize.Iconize.Init(Resource.Id.toolbar, Resource.Id.sliding_tabs);
    ...
    LoadApplication(new App());
}
```

**Xamarin.iOS (Unified)**  
Add the UIAppFonts key to Info.plist with the specific fonts you have chosen.

```xml
<key>UIAppFonts</key>
<array>
    <string>iconize-entypoplus.ttf</string>
    <string>iconize-fontawesome-regular.ttf</string>
    <string>iconize-fontawesome-solid.ttf</string>
    <string>iconize-fontawesome-brands.ttf</string>
    <string>iconize-ionicons.ttf</string>
    <string>iconize-material.ttf</string>
    <string>iconize-meteocons.ttf</string>
    <string>iconize-simplelineicons.ttf</string>
    <string>iconize-typicons.ttf</string>
    <string>iconize-weathericons.ttf</string>
</array>
```

**Xamarin.Forms with Caliburn Micro**  
Add the following to App.cs

```csharp
protected override NavigationPage CreateApplicationPage()
{
    return new IconNavigationPage();
}
```

## License

This work is licensed under the [Apache License, Version 2.0](http://www.apache.org/licenses/LICENSE-2.0).

**Entypo+**  
Entypo+ is licensed under the [Creative Commons Attribution-ShareAlike 4.0 International License (CC BY-SA 4.0)](http://creativecommons.org/licenses/by-sa/4.0/)

**Font Awesome**  
Font Awesome is licensed under the [SIL Open Font License 1.1](http://scripts.sil.org/OFL).

**Font Awesome Pro**  
Font Awesome Pro is commercial software that requires a paid license. [Full Font Awesome Pro license](https://fontawesome.com/license).
As a consequence the font files are not bundled with the plugin and need to be added manually.

**Google Material Icons**  
Google Material Icons are licensed under the [Apache License, Version 2.0](http://www.apache.org/licenses/LICENSE-2.0).

**Ionicons**  
Ionicons is licensed under the [MIT License](http://opensource.org/licenses/MIT).

**Jam Icons**  
Jam Icons is licensed under the [MIT License](http://opensource.org/licenses/MIT).

**Material Design Icons**  
Material Design Icons are licensed under the [SIL Open Font License 1.1](http://scripts.sil.org/OFL).

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
