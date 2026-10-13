using _Microsoft.Android.Resource.Designer;
using Android.App;
using Bundle = Android.OS.Bundle;

namespace FluentMusic;

[Activity(Label = "@string/app_name", MainLauncher = true)]
public class MainActivity : Activity
{
    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        // Set our view from the "main" layout resource
        SetContentView(ResourceConstant.Layout.activity_main);
    }
}