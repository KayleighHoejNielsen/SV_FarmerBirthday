using System.Security.Cryptography.X509Certificates;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;
using StardewValley.GameData.Shirts;
using StardewValley.Menus;
using StardewValley.Objects;

namespace FarmerBirthday
{
    public class SettingBirthday : CharacterCustomization
    {
        public const int region_birthday = 670;

        public List<string> Months;

        public List<int> Days = new List<int>();

        public ClickableComponent birthdaylabel;

        public ClickableComponent birthdaytitle;

        public SettingBirthday(Source item) : base(item)
        {
            this.Months = new List<string> { "spring", "summer", "fall", "winter" };
            for (int i = 1; i <= 28; i++)
            {
                this.Days.Add(i);
            }

            this.labels.Add(this.birthdaytitle = new ClickableComponent(new Rectangle(base.xPositionOnScreen + 200 + IClickableMenu.spaceToClearSideBorder + IClickableMenu.borderWidth + 10 + 8 / 2, base.yPositionOnScreen + IClickableMenu.borderWidth + IClickableMenu.spaceToClearTopBorder + 540, 1, 1), "Birthday"));
            this.leftSelectionButtons.Add(new ClickableTextureComponent("Day", new Rectangle(base.xPositionOnScreen + 330 + IClickableMenu.spaceToClearSideBorder + IClickableMenu.borderWidth, base.yPositionOnScreen + IClickableMenu.borderWidth + IClickableMenu.spaceToClearTopBorder + 530, 64, 64), null, "", Game1.mouseCursors, Game1.getSourceRectForStandardTileSheet(Game1.mouseCursors, 44), 1f)
            {
                myID = 801,
                upNeighborID = -99998,
                leftNeighborID = -99998,
                rightNeighborID = -99998,
                downNeighborID = -99998
            });
            this.labels.Add(this.birthdaylabel = new ClickableComponent(new Rectangle(base.xPositionOnScreen + 325 + IClickableMenu.spaceToClearSideBorder + IClickableMenu.borderWidth + 57 + 8 / 2, base.yPositionOnScreen + IClickableMenu.borderWidth + IClickableMenu.spaceToClearTopBorder + 520, 1, 1), GetMenuBirthdayLabel()));
            this.rightSelectionButtons.Add(new ClickableTextureComponent("Day", new Rectangle(base.xPositionOnScreen + 330 + IClickableMenu.spaceToClearSideBorder + 128 + IClickableMenu.borderWidth, base.yPositionOnScreen + IClickableMenu.borderWidth + IClickableMenu.spaceToClearTopBorder + 530, 64, 64), null, "", Game1.mouseCursors, Game1.getSourceRectForStandardTileSheet(Game1.mouseCursors, 33), 1f)
            {
                myID = 802,
                upNeighborID = -99998,
                leftNeighborID = -99998,
                rightNeighborID = -99998,
                downNeighborID = -99998
            });

        }

        public void RotateBirthday(ButtonPressedEventArgs e)
        {
            if (this.leftSelectionButtons.Count > 0)
            {
                foreach (ClickableComponent c in this.leftSelectionButtons)
                {
                    if (c.containsPoint((int)e.Cursor.ScreenPixels.X, (int)e.Cursor.ScreenPixels.Y) && c.myID == 801)
                    {
                        if (ModEntry.SelectedBirthdayDay == 1)
                        {
                            int monthIndex = Utility.WrapIndex(ModEntry.MenuMonthIndex - 1, this.Months.Count);
                            int dayIndex = Utility.WrapIndex(ModEntry.MenuDayIndex - 1, this.Days.Count);

                            ModEntry.MenuMonthIndex = monthIndex;
                            ModEntry.MenuDayIndex = dayIndex;

                            ModEntry.SelectedBirthdayMonth = this.Months[monthIndex];
                            ModEntry.SelectedBirthdayDay = this.Days[dayIndex];

                            this.birthdaylabel.name = GetMenuBirthdayLabel();

                            // this.selectionClick(c.name, -1);
                            if (c.scale != 0f)
                            {
                                c.scale -= 0.25f;
                                c.scale = Math.Max(0.75f, c.scale);
                            }
                        }
                        else
                        {
                            int monthIndex = ModEntry.MenuMonthIndex;
                            int dayIndex = Utility.WrapIndex(ModEntry.MenuDayIndex - 1, this.Days.Count);

                            ModEntry.MenuDayIndex = dayIndex;

                            ModEntry.SelectedBirthdayMonth = this.Months[monthIndex];
                            ModEntry.SelectedBirthdayDay = this.Days[dayIndex];

                            this.birthdaylabel.name = GetMenuBirthdayLabel();

                            // this.selectionClick(c.name, -1);
                            if (c.scale != 0f)
                            {
                                c.scale -= 0.25f;
                                c.scale = Math.Max(0.75f, c.scale);
                            }
                        }
                    }
                }
            }

            if (this.rightSelectionButtons.Count > 0)
            {
                foreach (ClickableComponent c in this.rightSelectionButtons)
                {
                    if (c.containsPoint((int)e.Cursor.ScreenPixels.X, (int)e.Cursor.ScreenPixels.Y) && c.myID == 802)
                    {
                        if (ModEntry.SelectedBirthdayDay == 28)
                        {
                            int monthIndex = Utility.WrapIndex(ModEntry.MenuMonthIndex + 1, this.Months.Count);
                            int dayIndex = Utility.WrapIndex(ModEntry.MenuDayIndex + 1, this.Days.Count);

                            ModEntry.MenuMonthIndex = monthIndex;
                            ModEntry.MenuDayIndex = dayIndex;

                            ModEntry.SelectedBirthdayMonth = this.Months[monthIndex];
                            ModEntry.SelectedBirthdayDay = this.Days[dayIndex];

                            this.birthdaylabel.name = GetMenuBirthdayLabel();

                            // this.selectionClick(c.name, -1);
                            if (c.scale != 0f)
                            {
                                c.scale -= 0.25f;
                                c.scale = Math.Max(0.75f, c.scale);
                            }
                        }
                        else
                        {
                            int monthIndex = ModEntry.MenuMonthIndex;
                            int dayIndex = Utility.WrapIndex(ModEntry.MenuDayIndex +1, this.Days.Count);

                            ModEntry.MenuDayIndex = dayIndex;

                            ModEntry.SelectedBirthdayMonth = this.Months[monthIndex];
                            ModEntry.SelectedBirthdayDay = this.Days[dayIndex];

                            this.birthdaylabel.name = GetMenuBirthdayLabel();

                            // this.selectionClick(c.name, -1);
                            if (c.scale != 0f)
                            {
                                c.scale -= 0.25f;
                                c.scale = Math.Max(0.75f, c.scale);
                            }
                        }
                    }
                }
            }
        }

        public string GetMenuBirthdayLabel()
        {
            return string.Format("{0} {1}", this.Months[ModEntry.MenuMonthIndex], this.Days[ModEntry.MenuDayIndex]);
        }
    }
}
