using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Views;
using Android.Content.PM;
using Android.Content;
using System;
using Xamarin.Essentials;

namespace football_logo_quiz2
{
    [Activity(Label = "@string/app_name", Theme = "@style/Theme.AppCompat.Light.NoActionBar", MainLauncher = true, ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            Window.AddFlags(WindowManagerFlags.Fullscreen);
            Window.ClearFlags(WindowManagerFlags.ForceNotFullscreen);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            Boolean returning_user = Preferences.Get("returning_user", false);

            if (returning_user != true)
            {
                Preferences.Set("vibration_setting", false);
                Preferences.Set("button_vibration_setting", false);
                Preferences.Set("sound_correct_settings", true);
                Preferences.Set("sound_button_setting", true);
                Preferences.Set("arsenal_correct", false);
                Preferences.Set("astonvilla_correct_correct", false);
                Preferences.Set("bournemouth_correct", false);
                Preferences.Set("brighton_correct", false);
                Preferences.Set("burnley_correct", false);
                Preferences.Set("chelsea_correct", false);
                Preferences.Set("crystalpalace_correct", false);
                Preferences.Set("everton_correct", false);
                Preferences.Set("leicester_correct", false);
                Preferences.Set("liverpool_correct", false);
                Preferences.Set("mancity_correct", false);
                Preferences.Set("manunited_correct", false);
                Preferences.Set("newcastle_correct", false);
                Preferences.Set("norwich_correct", false);
                Preferences.Set("southampton_correct", false);
                Preferences.Set("shefunited_correct", false);
                Preferences.Set("spurs_correct", false);
                Preferences.Set("watford_correct", false);
                Preferences.Set("westham_correct", false);
                Preferences.Set("wolves_correct", false);



                Preferences.Set("barnsley_correct", false);
                Preferences.Set("shefwednesday_correct", false);
                Preferences.Set("hull_correct", false);
                Preferences.Set("charlton_correct", false);
                Preferences.Set("blackburn_correct", false);
                Preferences.Set("preston_correct", false);
                Preferences.Set("luton_correct", false);
                Preferences.Set("fullham_correct", false);
                Preferences.Set("westbrom_correct", false);
                Preferences.Set("reading_correct", false);
                Preferences.Set("huddersfield_correct", false);
                Preferences.Set("cardiff_correct", false);
                Preferences.Set("birmingham_correct", false);
                Preferences.Set("nottsforest_correct", false);
                Preferences.Set("leeds_correct", false);
                Preferences.Set("derby_correct", false);
                Preferences.Set("swansea_correct", false);
                Preferences.Set("qpr_correct", false);
                Preferences.Set("middlesbrough_correct", false);
                Preferences.Set("bristol_correct", false);
                Preferences.Set("millwall_correct", false);
                Preferences.Set("stoke_correct", false);
                Preferences.Set("brentford_correct", false);
                Preferences.Set("wigan_correct", false);

                Preferences.Set("coin_count", 500);

                Preferences.Set("epl_correct_count", 0);
                Preferences.Set("efl_champ_correct_count", 0);

                Preferences.Set("returning_user", true);
            }

            Button advanceToLeagueMenu = FindViewById<Button>(Resource.Id.btnPlay);
            advanceToLeagueMenu.Click += delegate
            {
                Intent intent = new Intent(this, typeof(league_menu));
                StartActivity(intent);
            };
        }


        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}