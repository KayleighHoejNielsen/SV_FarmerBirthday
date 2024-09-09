using System;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;
using StardewValley.GameData.Shirts;
using StardewValley.Menus;
using StardewValley.Objects;
using static StardewValley.Menus.CharacterCustomization;

namespace FarmerBirthday
{
    public class BirthdayDialogue : Dialogue
    {
        public BirthdayDialogue(NPC speaker) : base(speaker, "", "Hapy Birthday const")
        {

            public void changedDialogue(string str) {
                string farmer_name = Utility.FilterUserName(this.farmer.Name);

                if (this.speaker != null && this.speaker.Name.Equals("Pierre"))
                {
                    str = str.Replace("@", farmer_name);

                    Game1.content.LoadString("happy birthday @!");
                }
            }
        }
    }
}
