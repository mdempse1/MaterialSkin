﻿namespace MaterialSkin
{
    using MaterialSkin.Controls;
    using MaterialSkin.Properties;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Drawing;
    using System.Drawing.Text;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    /// <summary>
    /// Defines the <see cref="MaterialSkinManager" />
    /// </summary>
    public class MaterialSkinManager
    {
        /// <summary>
        /// Defines the _instance
        /// </summary>
        private static MaterialSkinManager _instance;

        /// <summary>
        /// Defines the _formsToManage
        /// </summary>
        private readonly List<MaterialForm> _formsToManage = new List<MaterialForm>();

        /// <summary>
        /// Defines the _theme
        /// </summary>
        private Themes _theme;

        /// <summary>
        /// Gets or sets the Theme
        /// </summary>
        public Themes Theme
        {
            get { return _theme; }
            set
            {
                _theme = value;
                UpdateBackgrounds();
            }
        }

        /// <summary>
        /// Defines the _colorScheme
        /// </summary>
        private ColorScheme _colorScheme;

        /// <summary>
        /// Gets or sets the ColorScheme
        /// </summary>
        public ColorScheme ColorScheme
        {
            get { return _colorScheme; }
            set
            {
                _colorScheme = value;
                UpdateBackgrounds();
            }
        }

        /// <summary>
        /// Defines the Themes
        /// </summary>
        public enum Themes : byte
        {
            /// <summary>
            /// Defines the LIGHT
            /// </summary>
            LIGHT,
            /// <summary>
            /// Defines the DARK
            /// </summary>
            DARK
        }

        /// <summary>
        /// Defines the PRIMARY_TEXT_BLACK
        /// </summary>
        private static readonly Color PRIMARY_TEXT_BLACK = Color.FromArgb(222, 0, 0, 0);

        /// <summary>
        /// Defines the PRIMARY_TEXT_BLACK_BRUSH
        /// </summary>
        private static readonly Brush PRIMARY_TEXT_BLACK_BRUSH = new SolidBrush(PRIMARY_TEXT_BLACK);

        /// <summary>
        /// Defines the SECONDARY_TEXT_BLACK
        /// </summary>
        public static Color SECONDARY_TEXT_BLACK = Color.FromArgb(138, 0, 0, 0);

        /// <summary>
        /// Defines the SECONDARY_TEXT_BLACK_BRUSH
        /// </summary>
        public static Brush SECONDARY_TEXT_BLACK_BRUSH = new SolidBrush(SECONDARY_TEXT_BLACK);

        /// <summary>
        /// Defines the DISABLED_OR_HINT_TEXT_BLACK
        /// </summary>
        private static readonly Color DISABLED_OR_HINT_TEXT_BLACK = Color.FromArgb(66, 0, 0, 0);

        /// <summary>
        /// Defines the DISABLED_OR_HINT_TEXT_BLACK_BRUSH
        /// </summary>
        private static readonly Brush DISABLED_OR_HINT_TEXT_BLACK_BRUSH = new SolidBrush(DISABLED_OR_HINT_TEXT_BLACK);

        /// <summary>
        /// Defines the DIVIDERS_BLACK
        /// </summary>
        private static readonly Color DIVIDERS_BLACK = Color.FromArgb(31, 0, 0, 0);

        /// <summary>
        /// Defines the DIVIDERS_BLACK_BRUSH
        /// </summary>
        private static readonly Brush DIVIDERS_BLACK_BRUSH = new SolidBrush(DIVIDERS_BLACK);

        /// <summary>
        /// Defines the PRIMARY_TEXT_WHITE
        /// </summary>
        private static readonly Color PRIMARY_TEXT_WHITE = Color.FromArgb(255, 255, 255, 255);

        /// <summary>
        /// Defines the PRIMARY_TEXT_WHITE_BRUSH
        /// </summary>
        private static readonly Brush PRIMARY_TEXT_WHITE_BRUSH = new SolidBrush(PRIMARY_TEXT_WHITE);

        /// <summary>
        /// Defines the SECONDARY_TEXT_WHITE
        /// </summary>
        public static Color SECONDARY_TEXT_WHITE = Color.FromArgb(179, 255, 255, 255);

        /// <summary>
        /// Defines the SECONDARY_TEXT_WHITE_BRUSH
        /// </summary>
        public static Brush SECONDARY_TEXT_WHITE_BRUSH = new SolidBrush(SECONDARY_TEXT_WHITE);

        /// <summary>
        /// Defines the DISABLED_OR_HINT_TEXT_WHITE
        /// </summary>
        private static readonly Color DISABLED_OR_HINT_TEXT_WHITE = Color.FromArgb(77, 255, 255, 255);

        /// <summary>
        /// Defines the DISABLED_OR_HINT_TEXT_WHITE_BRUSH
        /// </summary>
        private static readonly Brush DISABLED_OR_HINT_TEXT_WHITE_BRUSH = new SolidBrush(DISABLED_OR_HINT_TEXT_WHITE);

        /// <summary>
        /// Defines the DIVIDERS_WHITE
        /// </summary>
        private static readonly Color DIVIDERS_WHITE = Color.FromArgb(31, 255, 255, 255);

        /// <summary>
        /// Defines the DIVIDERS_WHITE_BRUSH
        /// </summary>
        private static readonly Brush DIVIDERS_WHITE_BRUSH = new SolidBrush(DIVIDERS_WHITE);

        /// <summary>
        /// Defines the CHECKBOX_OFF_LIGHT
        /// </summary>
        private static readonly Color CHECKBOX_OFF_LIGHT = Color.FromArgb(138, 0, 0, 0);

        /// <summary>
        /// Defines the CHECKBOX_OFF_LIGHT_BRUSH
        /// </summary>
        private static readonly Brush CHECKBOX_OFF_LIGHT_BRUSH = new SolidBrush(CHECKBOX_OFF_LIGHT);

        /// <summary>
        /// Defines the CHECKBOX_OFF_DISABLED_LIGHT
        /// </summary>
        private static readonly Color CHECKBOX_OFF_DISABLED_LIGHT = Color.FromArgb(66, 0, 0, 0);

        /// <summary>
        /// Defines the CHECKBOX_OFF_DISABLED_LIGHT_BRUSH
        /// </summary>
        private static readonly Brush CHECKBOX_OFF_DISABLED_LIGHT_BRUSH = new SolidBrush(CHECKBOX_OFF_DISABLED_LIGHT);

        /// <summary>
        /// Defines the CHECKBOX_OFF_DARK
        /// </summary>
        private static readonly Color CHECKBOX_OFF_DARK = Color.FromArgb(179, 255, 255, 255);

        /// <summary>
        /// Defines the CHECKBOX_OFF_DARK_BRUSH
        /// </summary>
        private static readonly Brush CHECKBOX_OFF_DARK_BRUSH = new SolidBrush(CHECKBOX_OFF_DARK);

        /// <summary>
        /// Defines the CHECKBOX_OFF_DISABLED_DARK
        /// </summary>
        private static readonly Color CHECKBOX_OFF_DISABLED_DARK = Color.FromArgb(77, 255, 255, 255);

        /// <summary>
        /// Defines the CHECKBOX_OFF_DISABLED_DARK_BRUSH
        /// </summary>
        private static readonly Brush CHECKBOX_OFF_DISABLED_DARK_BRUSH = new SolidBrush(CHECKBOX_OFF_DISABLED_DARK);

        /// <summary>
        /// Defines the RAISED_BUTTON_BACKGROUND
        /// </summary>
        private static readonly Color RAISED_BUTTON_BACKGROUND = Color.FromArgb(255, 255, 255, 255);

        /// <summary>
        /// Defines the RAISED_BUTTON_BACKGROUND_BRUSH
        /// </summary>
        private static readonly Brush RAISED_BUTTON_BACKGROUND_BRUSH = new SolidBrush(RAISED_BUTTON_BACKGROUND);

        /// <summary>
        /// Defines the RAISED_BUTTON_TEXT_LIGHT
        /// </summary>
        private static readonly Color RAISED_BUTTON_TEXT_LIGHT = PRIMARY_TEXT_WHITE;

        /// <summary>
        /// Defines the RAISED_BUTTON_TEXT_LIGHT_BRUSH
        /// </summary>
        private static readonly Brush RAISED_BUTTON_TEXT_LIGHT_BRUSH = new SolidBrush(RAISED_BUTTON_TEXT_LIGHT);

        /// <summary>
        /// Defines the RAISED_BUTTON_TEXT_DARK
        /// </summary>
        private static readonly Color RAISED_BUTTON_TEXT_DARK = PRIMARY_TEXT_BLACK;

        /// <summary>
        /// Defines the RAISED_BUTTON_TEXT_DARK_BRUSH
        /// </summary>
        private static readonly Brush RAISED_BUTTON_TEXT_DARK_BRUSH = new SolidBrush(RAISED_BUTTON_TEXT_DARK);

        /// <summary>
        /// Defines the FLAT_BUTTON_BACKGROUND_HOVER_LIGHT
        /// </summary>
        private static readonly Color FLAT_BUTTON_BACKGROUND_HOVER_LIGHT = Color.FromArgb(20.PercentageToColorComponent(), 0x999999.ToColor());

        /// <summary>
        /// Defines the FLAT_BUTTON_BACKGROUND_HOVER_LIGHT_BRUSH
        /// </summary>
        private static readonly Brush FLAT_BUTTON_BACKGROUND_HOVER_LIGHT_BRUSH = new SolidBrush(FLAT_BUTTON_BACKGROUND_HOVER_LIGHT);

        /// <summary>
        /// Defines the FLAT_BUTTON_BACKGROUND_PRESSED_LIGHT
        /// </summary>
        private static readonly Color FLAT_BUTTON_BACKGROUND_PRESSED_LIGHT = Color.FromArgb(40.PercentageToColorComponent(), 0x999999.ToColor());

        /// <summary>
        /// Defines the FLAT_BUTTON_BACKGROUND_PRESSED_LIGHT_BRUSH
        /// </summary>
        private static readonly Brush FLAT_BUTTON_BACKGROUND_PRESSED_LIGHT_BRUSH = new SolidBrush(FLAT_BUTTON_BACKGROUND_PRESSED_LIGHT);

        /// <summary>
        /// Defines the FLAT_BUTTON_DISABLEDTEXT_LIGHT
        /// </summary>
        private static readonly Color FLAT_BUTTON_DISABLEDTEXT_LIGHT = Color.FromArgb(26.PercentageToColorComponent(), 0x000000.ToColor());

        /// <summary>
        /// Defines the FLAT_BUTTON_DISABLEDTEXT_LIGHT_BRUSH
        /// </summary>
        private static readonly Brush FLAT_BUTTON_DISABLEDTEXT_LIGHT_BRUSH = new SolidBrush(FLAT_BUTTON_DISABLEDTEXT_LIGHT);

        /// <summary>
        /// Defines the FLAT_BUTTON_BACKGROUND_HOVER_DARK
        /// </summary>
        private static readonly Color FLAT_BUTTON_BACKGROUND_HOVER_DARK = Color.FromArgb(15.PercentageToColorComponent(), 0xCCCCCC.ToColor());

        /// <summary>
        /// Defines the FLAT_BUTTON_BACKGROUND_HOVER_DARK_BRUSH
        /// </summary>
        private static readonly Brush FLAT_BUTTON_BACKGROUND_HOVER_DARK_BRUSH = new SolidBrush(FLAT_BUTTON_BACKGROUND_HOVER_DARK);

        /// <summary>
        /// Defines the FLAT_BUTTON_BACKGROUND_PRESSED_DARK
        /// </summary>
        private static readonly Color FLAT_BUTTON_BACKGROUND_PRESSED_DARK = Color.FromArgb(25.PercentageToColorComponent(), 0xCCCCCC.ToColor());

        /// <summary>
        /// Defines the FLAT_BUTTON_BACKGROUND_PRESSED_DARK_BRUSH
        /// </summary>
        private static readonly Brush FLAT_BUTTON_BACKGROUND_PRESSED_DARK_BRUSH = new SolidBrush(FLAT_BUTTON_BACKGROUND_PRESSED_DARK);

        /// <summary>
        /// Defines the FLAT_BUTTON_DISABLEDTEXT_DARK
        /// </summary>
        private static readonly Color FLAT_BUTTON_DISABLEDTEXT_DARK = Color.FromArgb(30.PercentageToColorComponent(), 0xFFFFFF.ToColor());

        /// <summary>
        /// Defines the FLAT_BUTTON_DISABLEDTEXT_DARK_BRUSH
        /// </summary>
        private static readonly Brush FLAT_BUTTON_DISABLEDTEXT_DARK_BRUSH = new SolidBrush(FLAT_BUTTON_DISABLEDTEXT_DARK);

        /// <summary>
        /// Defines the CMS_BACKGROUND_LIGHT_HOVER
        /// </summary>
        private static readonly Color CMS_BACKGROUND_LIGHT_HOVER = Color.FromArgb(255, 238, 238, 238);

        /// <summary>
        /// Defines the CMS_BACKGROUND_HOVER_LIGHT_BRUSH
        /// </summary>
        private static readonly Brush CMS_BACKGROUND_HOVER_LIGHT_BRUSH = new SolidBrush(CMS_BACKGROUND_LIGHT_HOVER);

        /// <summary>
        /// Defines the CMS_BACKGROUND_DARK_HOVER
        /// </summary>
        private static readonly Color CMS_BACKGROUND_DARK_HOVER = Color.FromArgb(38, 204, 204, 204);

        /// <summary>
        /// Defines the CMS_BACKGROUND_HOVER_DARK_BRUSH
        /// </summary>
        private static readonly Brush CMS_BACKGROUND_HOVER_DARK_BRUSH = new SolidBrush(CMS_BACKGROUND_DARK_HOVER);

        /// <summary>
        /// Defines the BACKGROUND_LIGHT
        /// </summary>
        private static readonly Color BACKGROUND_LIGHT = Color.FromArgb(255, 255, 255, 255);

        /// <summary>
        /// Defines the BACKGROUND_LIGHT_BRUSH
        /// </summary>
        private static Brush BACKGROUND_LIGHT_BRUSH = new SolidBrush(BACKGROUND_LIGHT);

        /// <summary>
        /// Defines the BACKGROUND_DARK
        /// </summary>
        private static readonly Color BACKGROUND_DARK = Color.FromArgb(255, 51, 51, 51);

        /// <summary>
        /// Defines the BACKGROUND_DARK_BRUSH
        /// </summary>
        private static Brush BACKGROUND_DARK_BRUSH = new SolidBrush(BACKGROUND_DARK);

        /// <summary>
        /// Defines the ACTION_BAR_TEXT
        /// </summary>
        public readonly Color ACTION_BAR_TEXT = Color.FromArgb(255, 255, 255, 255);

        /// <summary>
        /// Defines the ACTION_BAR_TEXT_BRUSH
        /// </summary>
        public readonly Brush ACTION_BAR_TEXT_BRUSH = new SolidBrush(Color.FromArgb(255, 255, 255, 255));

        /// <summary>
        /// Defines the ACTION_BAR_TEXT_SECONDARY
        /// </summary>
        public readonly Color ACTION_BAR_TEXT_SECONDARY = Color.FromArgb(153, 255, 255, 255);

        /// <summary>
        /// Defines the ACTION_BAR_TEXT_SECONDARY_BRUSH
        /// </summary>
        public readonly Brush ACTION_BAR_TEXT_SECONDARY_BRUSH = new SolidBrush(Color.FromArgb(153, 255, 255, 255));

        /// <summary>
        /// The GetPrimaryTextColor
        /// </summary>
        /// <returns>The <see cref="Color"/></returns>
        public Color GetPrimaryTextColor()
        {
            return Theme == Themes.LIGHT ? PRIMARY_TEXT_BLACK : PRIMARY_TEXT_WHITE;
        }

        /// <summary>
        /// The GetPrimaryTextBrush
        /// </summary>
        /// <returns>The <see cref="Brush"/></returns>
        public Brush GetPrimaryTextBrush()
        {
            return Theme == Themes.LIGHT ? PRIMARY_TEXT_BLACK_BRUSH : PRIMARY_TEXT_WHITE_BRUSH;
        }

        /// <summary>
        /// The GetSecondaryTextColor
        /// </summary>
        /// <returns>The <see cref="Color"/></returns>
        public Color GetSecondaryTextColor()
        {
            return Theme == Themes.LIGHT ? SECONDARY_TEXT_BLACK : SECONDARY_TEXT_WHITE;
        }

        /// <summary>
        /// The GetSecondaryTextBrush
        /// </summary>
        /// <returns>The <see cref="Brush"/></returns>
        public Brush GetSecondaryTextBrush()
        {
            return Theme == Themes.LIGHT ? SECONDARY_TEXT_BLACK_BRUSH : SECONDARY_TEXT_WHITE_BRUSH;
        }

        /// <summary>
        /// The GetDisabledOrHintColor
        /// </summary>
        /// <returns>The <see cref="Color"/></returns>
        public Color GetDisabledOrHintColor()
        {
            return Theme == Themes.LIGHT ? DISABLED_OR_HINT_TEXT_BLACK : DISABLED_OR_HINT_TEXT_WHITE;
        }

        /// <summary>
        /// The GetDisabledOrHintBrush
        /// </summary>
        /// <returns>The <see cref="Brush"/></returns>
        public Brush GetDisabledOrHintBrush()
        {
            return Theme == Themes.LIGHT ? DISABLED_OR_HINT_TEXT_BLACK_BRUSH : DISABLED_OR_HINT_TEXT_WHITE_BRUSH;
        }

        /// <summary>
        /// The GetDividersColor
        /// </summary>
        /// <returns>The <see cref="Color"/></returns>
        public Color GetDividersColor()
        {
            return Theme == Themes.LIGHT ? DIVIDERS_BLACK : DIVIDERS_WHITE;
        }

        /// <summary>
        /// The GetDividersBrush
        /// </summary>
        /// <returns>The <see cref="Brush"/></returns>
        public Brush GetDividersBrush()
        {
            return Theme == Themes.LIGHT ? DIVIDERS_BLACK_BRUSH : DIVIDERS_WHITE_BRUSH;
        }

        /// <summary>
        /// The GetCheckboxOffColor
        /// </summary>
        /// <returns>The <see cref="Color"/></returns>
        public Color GetCheckboxOffColor()
        {
            return Theme == Themes.LIGHT ? CHECKBOX_OFF_LIGHT : CHECKBOX_OFF_DARK;
        }

        /// <summary>
        /// The GetCheckboxOffBrush
        /// </summary>
        /// <returns>The <see cref="Brush"/></returns>
        public Brush GetCheckboxOffBrush()
        {
            return Theme == Themes.LIGHT ? CHECKBOX_OFF_LIGHT_BRUSH : CHECKBOX_OFF_DARK_BRUSH;
        }

        /// <summary>
        /// The GetCheckBoxOffDisabledColor
        /// </summary>
        /// <returns>The <see cref="Color"/></returns>
        public Color GetCheckBoxOffDisabledColor()
        {
            return Theme == Themes.LIGHT ? CHECKBOX_OFF_DISABLED_LIGHT : CHECKBOX_OFF_DISABLED_DARK;
        }

        /// <summary>
        /// The GetCheckBoxOffDisabledBrush
        /// </summary>
        /// <returns>The <see cref="Brush"/></returns>
        public Brush GetCheckBoxOffDisabledBrush()
        {
            return Theme == Themes.LIGHT ? CHECKBOX_OFF_DISABLED_LIGHT_BRUSH : CHECKBOX_OFF_DISABLED_DARK_BRUSH;
        }

        /// <summary>
        /// The GetRaisedButtonBackgroundBrush
        /// </summary>
        /// <returns>The <see cref="Brush"/></returns>
        public Brush GetRaisedButtonBackgroundBrush()
        {
            return RAISED_BUTTON_BACKGROUND_BRUSH;
        }

        /// <summary>
        /// The GetRaisedButtonTextBrush
        /// </summary>
        /// <param name="primary">The primary<see cref="bool"/></param>
        /// <returns>The <see cref="Brush"/></returns>
        public Brush GetRaisedButtonTextBrush(bool primary)
        {
            return primary ? RAISED_BUTTON_TEXT_LIGHT_BRUSH : RAISED_BUTTON_TEXT_DARK_BRUSH;
        }

        /// <summary>
        /// The GetFlatButtonHoverBackgroundColor
        /// </summary>
        /// <returns>The <see cref="Color"/></returns>
        public Color GetFlatButtonHoverBackgroundColor()
        {
            return Theme == Themes.LIGHT ? FLAT_BUTTON_BACKGROUND_HOVER_LIGHT : FLAT_BUTTON_BACKGROUND_HOVER_DARK;
        }

        /// <summary>
        /// The GetFlatButtonHoverBackgroundBrush
        /// </summary>
        /// <returns>The <see cref="Brush"/></returns>
        public Brush GetFlatButtonHoverBackgroundBrush()
        {
            return Theme == Themes.LIGHT ? FLAT_BUTTON_BACKGROUND_HOVER_LIGHT_BRUSH : FLAT_BUTTON_BACKGROUND_HOVER_DARK_BRUSH;
        }

        /// <summary>
        /// The GetFlatButtonPressedBackgroundColor
        /// </summary>
        /// <returns>The <see cref="Color"/></returns>
        public Color GetFlatButtonPressedBackgroundColor()
        {
            return Theme == Themes.LIGHT ? FLAT_BUTTON_BACKGROUND_PRESSED_LIGHT : FLAT_BUTTON_BACKGROUND_PRESSED_DARK;
        }

        /// <summary>
        /// The GetFlatButtonPressedBackgroundBrush
        /// </summary>
        /// <returns>The <see cref="Brush"/></returns>
        public Brush GetFlatButtonPressedBackgroundBrush()
        {
            return Theme == Themes.LIGHT ? FLAT_BUTTON_BACKGROUND_PRESSED_LIGHT_BRUSH : FLAT_BUTTON_BACKGROUND_PRESSED_DARK_BRUSH;
        }

        /// <summary>
        /// The GetFlatButtonDisabledTextBrush
        /// </summary>
        /// <returns>The <see cref="Brush"/></returns>
        public Brush GetFlatButtonDisabledTextBrush()
        {
            return Theme == Themes.LIGHT ? FLAT_BUTTON_DISABLEDTEXT_LIGHT_BRUSH : FLAT_BUTTON_DISABLEDTEXT_DARK_BRUSH;
        }

        /// <summary>
        /// The GetCmsSelectedItemBrush
        /// </summary>
        /// <returns>The <see cref="Brush"/></returns>
        public Brush GetCmsSelectedItemBrush()
        {
            return Theme == Themes.LIGHT ? CMS_BACKGROUND_HOVER_LIGHT_BRUSH : CMS_BACKGROUND_HOVER_DARK_BRUSH;
        }

        /// <summary>
        /// The GetApplicationBackgroundColor
        /// </summary>
        /// <returns>The <see cref="Color"/></returns>
        public Color GetApplicationBackgroundColor()
        {
            return Theme == Themes.LIGHT ? BACKGROUND_LIGHT : BACKGROUND_DARK;
        }

        /// <summary>
        /// The GetControlBackgroundColor
        /// </summary>
        /// <returns>The <see cref="Color"/></returns>
        public Color GetControlBackgroundColor()
        {
            return Theme == Themes.LIGHT ? BACKGROUND_LIGHT.Darken((float)0.02) : BACKGROUND_DARK.Lighten((float)0.05);
        }

        /// <summary>
        /// Defines the ROBOTO_MEDIUM_12
        /// </summary>
        public Font ROBOTO_MEDIUM_12;

        /// <summary>
        /// Defines the ROBOTO_REGULAR_11
        /// </summary>
        public Font ROBOTO_REGULAR_11;

        /// <summary>
        /// Defines the ROBOTO_MEDIUM_11
        /// </summary>
        public Font ROBOTO_MEDIUM_11;

        /// <summary>
        /// Defines the ROBOTO_MEDIUM_10
        /// </summary>
        public Font ROBOTO_MEDIUM_10;

        /// <summary>
        /// Defines the ROBOTO_MEDIUM_9
        /// </summary>
        public Font ROBOTO_MEDIUM_9;

        /// <summary>
        /// Defines the BUTTON_FONT
        /// </summary>
        public Font BUTTON_FONT;

        /// <summary>
        /// Defines the TEXT_FONT
        /// </summary>
        public Font TEXT_FONT;

        /// <summary>
        /// Defines the TITLE_FONT
        /// </summary>
        public Font TITLE_FONT;

        /// <summary>
        /// Defines the TAB_SELECTOR_FONT
        /// </summary>
        public Font TAB_SELECTOR_FONT;

        /// <summary>
        /// Defines the FORM_PADDING
        /// </summary>
        public int FORM_PADDING = 14;


        /// <summary>
        /// The AddFontMemResourceEx
        /// </summary>
        /// <param name="pbFont">The pbFont<see cref="IntPtr"/></param>
        /// <param name="cbFont">The cbFont<see cref="uint"/></param>
        /// <param name="pvd">The pvd<see cref="IntPtr"/></param>
        /// <param name="pcFonts">The pcFonts<see cref="uint"/></param>
        /// <returns>The <see cref="IntPtr"/></returns>
        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pvd, [In] ref uint pcFonts);

        /// <summary>
        /// Prevents a default instance of the <see cref="MaterialSkinManager"/> class from being created.
        /// </summary>
        private MaterialSkinManager()
        {
            ROBOTO_MEDIUM_12 = new Font(LoadFont(Resources.Roboto_Medium), 12f);
            ROBOTO_MEDIUM_10 = new Font(LoadFont(Resources.Roboto_Medium), 10f);
            ROBOTO_MEDIUM_9 = new Font(LoadFont(Resources.Roboto_Medium), 9f);
            ROBOTO_REGULAR_11 = new Font(LoadFont(Resources.Roboto_Regular), 11f);
            ROBOTO_MEDIUM_11 = new Font(LoadFont(Resources.Roboto_Medium), 11f);
            Theme = Themes.LIGHT;
            ColorScheme = new ColorScheme(Primary.ClaytexPrimary, Primary.ClaytexDark, Primary.ClaytexLight, Accent.ClaytexLight, TextShade.WHITE);
            BUTTON_FONT = ROBOTO_MEDIUM_10;
            TEXT_FONT = ROBOTO_MEDIUM_9;
            TITLE_FONT = ROBOTO_MEDIUM_12;
            TAB_SELECTOR_FONT= ROBOTO_MEDIUM_11;
        }

        /// <summary>
        /// Gets the Instance
        /// </summary>
        public static MaterialSkinManager Instance => _instance ?? (_instance = new MaterialSkinManager());

        /// <summary>
        /// The AddFormToManage
        /// </summary>
        /// <param name="materialForm">The materialForm<see cref="MaterialForm"/></param>
        public void AddFormToManage(MaterialForm materialForm)
        {
            _formsToManage.Add(materialForm);
            UpdateBackgrounds();
        }

        /// <summary>
        /// The RemoveFormToManage
        /// </summary>
        /// <param name="materialForm">The materialForm<see cref="MaterialForm"/></param>
        public void RemoveFormToManage(MaterialForm materialForm)
        {
            _formsToManage.Remove(materialForm);
        }

        /// <summary>
        /// Defines the privateFontCollection
        /// </summary>
        private readonly PrivateFontCollection privateFontCollection = new PrivateFontCollection();

        /// <summary>
        /// The LoadFont
        /// </summary>
        /// <param name="fontResource">The fontResource<see cref="byte[]"/></param>
        /// <returns>The <see cref="FontFamily"/></returns>
        private FontFamily LoadFont(byte[] fontResource)
        {
            int dataLength = fontResource.Length;
            IntPtr fontPtr = Marshal.AllocCoTaskMem(dataLength);
            Marshal.Copy(fontResource, 0, fontPtr, dataLength);

            uint cFonts = 0;
            AddFontMemResourceEx(fontPtr, (uint)fontResource.Length, IntPtr.Zero, ref cFonts);
            privateFontCollection.AddMemoryFont(fontPtr, dataLength);

            return privateFontCollection.Families.Last();
        }

        /// <summary>
        /// The UpdateBackgrounds
        /// </summary>
        private void UpdateBackgrounds()
        {
            var newBackColor = GetApplicationBackgroundColor();
            foreach (var materialForm in _formsToManage)
            {
                materialForm.BackColor = newBackColor;
                UpdateControl(materialForm, newBackColor, ROBOTO_REGULAR_11);
            }
        }

        /// <summary>
        /// The UpdateToolStrip
        /// </summary>
        /// <param name="toolStrip">The toolStrip<see cref="ToolStrip"/></param>
        /// <param name="newBackColor">The newBackColor<see cref="Color"/></param>
        private void UpdateToolStrip(ToolStrip toolStrip, Color newBackColor)
        {
            if (toolStrip == null)
            {
                return;
            }

            toolStrip.BackColor = newBackColor;
            foreach (ToolStripItem control in toolStrip.Items)
            {
                control.BackColor = newBackColor;
                if (control is MaterialToolStripMenuItem && (control as MaterialToolStripMenuItem).HasDropDown)
                {

                    //recursive call
                    UpdateToolStrip((control as MaterialToolStripMenuItem).DropDown, newBackColor);
                }
            }
        }

        /// <summary>
        /// The UpdateControl
        /// </summary>
        /// <param name="controlToUpdate">The controlToUpdate<see cref="Control"/></param>
        public void UpdateControl(Control controlToUpdate)
        {
            UpdateControl(controlToUpdate, GetApplicationBackgroundColor(), controlToUpdate.Font);
        }

        /// <summary>
        /// The UpdateControl
        /// </summary>
        /// <param name="controlToUpdate">The controlToUpdate<see cref="Control"/></param>
        /// <param name="newBackColor">The newBackColor<see cref="Color"/></param>
        private void UpdateControl(Control controlToUpdate, Color newBackColor, Font parentFont)
        {


            if (controlToUpdate == null)
            {
                return;
            }

            if (controlToUpdate.Name == "TrackMe")
            {
                //Debugger.Break();
            }

            var tabControl = controlToUpdate as MaterialTabControl;
            var CurrentTabPage = controlToUpdate as TabPage;


            if (controlToUpdate.ContextMenuStrip != null)
            {
                UpdateToolStrip(controlToUpdate.ContextMenuStrip, newBackColor);
            }
            if (tabControl != null)
            {
                foreach (TabPage tabPage in tabControl.TabPages)
                {
                    tabPage.BackColor = newBackColor;
                }
            }
            else if (controlToUpdate is MaterialDivider)
            {
                controlToUpdate.BackColor = GetDividersColor();
            }
            else if (controlToUpdate.HasProperty("BackColor") && CurrentTabPage == null && !controlToUpdate.IsMaterialControl())
            {         // if the control has a backcolor property set the colors  
                if (controlToUpdate.BackColor != newBackColor)
                {
                    controlToUpdate.BackColor = newBackColor;
                    if (controlToUpdate.HasProperty("ForeColor") && controlToUpdate.ForeColor != GetPrimaryTextColor())
                    {
                        controlToUpdate.ForeColor = GetPrimaryTextColor();

                        if (controlToUpdate.Font == SystemFonts.DefaultFont) // if the control has not had the font changed from default, set a default
                        {
                            controlToUpdate.Font = parentFont;
                        }
                    }
                }

            }
            else if (controlToUpdate.IsMaterialControl())
            {
               
                controlToUpdate.BackColor = newBackColor;
                controlToUpdate.ForeColor = GetPrimaryTextColor();
            }

            //recursive call
            foreach (Control control in controlToUpdate.Controls)
            {
                UpdateControl(control, newBackColor, controlToUpdate.Font);
            }

            controlToUpdate.Invalidate();
        }
    }
}
