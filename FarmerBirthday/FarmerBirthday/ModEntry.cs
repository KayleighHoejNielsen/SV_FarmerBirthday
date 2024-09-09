using Microsoft.Xna.Framework.Input;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;
using StardewValley.Menus;

namespace FarmerBirthday
{
    /// <summary>The mod entry point.</summary>
    internal sealed class ModEntry : Mod
    {
        private SettingBirthday? SettingBirthday;

        public static string SelectedBirthdayMonth = "";

        public static int SelectedBirthdayDay;

        public static int MenuMonthIndex;

        public static int MenuDayIndex;

        public override void Entry(IModHelper helper)
        {
            helper.Events.Display.MenuChanged += MenuChanged;
            helper.Events.GameLoop.UpdateTicked += UpdateTicked;
            helper.Events.Input.ButtonPressed += OnLeftClick;
            helper.Events.GameLoop.DayStarted += CorrectDay;
        }

        public void MenuChanged(object? sender, MenuChangedEventArgs e)
        {
            if (e.NewMenu is CharacterCustomization && !(e.NewMenu is SettingBirthday))
            {
                CharacterCustomization.Source source = (e.NewMenu as CharacterCustomization).source;
                if (source == CharacterCustomization.Source.NewFarmhand)
                {
                    Game1.activeClickableMenu = new SettingBirthday(source);
                }
            }
        }

        public void UpdateTicked(object? sender, UpdateTickedEventArgs e)
        {
            if (TitleMenu.subMenu is CharacterCustomization && !(TitleMenu.subMenu is SettingBirthday))
            {
                CharacterCustomization.Source source = (TitleMenu.subMenu as CharacterCustomization).source;
                if (source == CharacterCustomization.Source.NewGame || source == CharacterCustomization.Source.NewFarmhand || source == CharacterCustomization.Source.HostNewFarm)
                {
                    this.SettingBirthday = new SettingBirthday(source);
                    TitleMenu.subMenu = this.SettingBirthday;
                }
            }
        }

        public void OnLeftClick(object? sender, ButtonPressedEventArgs e)
        {
            if (this.SettingBirthday != null)
            {
                this.SettingBirthday.RotateBirthday(e);
            }
        }

        private void CorrectDay(object? sender, DayStartedEventArgs e)
        {
            if (Game1.dayOfMonth == SelectedBirthdayDay && Game1.currentSeason == SelectedBirthdayMonth)
            {
                Game1.hudMessages.Add(new HUDMessage("Happy Birthday Farmer!"));
            }
        }
    }
}

