using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuideListFormatter
{
    public partial class GuideListFormatter : Form
    {
        public GuideListFormatter()
        {
            InitializeComponent();
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            var builtString = "";
            resultBox.Text = "";

            builtString += getFormattedAbility();
            builtString += getFormattedClass();
            builtString += getFormattedOptions();
            builtString += getFormattedVersion();
            builtString += getFormattedFreetext();
            builtString += getFormattedURL();

            resultBox.Text = builtString;
        }

        private string getFormattedAbility()
        {
            var builtString = abilityBox.Text;

            if (builtString == "" || builtString == " ")
                return "";

            if (Properties.FormatOptions.Default.abilityBrackets)
                builtString = "[" + builtString + "]";

            if (Properties.FormatOptions.Default.abilityColour)
                builtString = "[span color=\"" + Properties.FormatOptions.Default.abilityColourCode + "\"]" + builtString + "[/span]";

            if (Properties.FormatOptions.Default.abilityUnderline)
                builtString = "[u]" + builtString + "[/u]";

            if (Properties.FormatOptions.Default.abilityItalics)
                builtString = "[i]" + builtString + "[/i]";

            if (Properties.FormatOptions.Default.abilityBold)
                builtString = "[b]" + builtString + "[/b]";

            if (Properties.FormatOptions.Default.spaceBetween)
                builtString += " ";

            return builtString;
        }

        private string getFormattedClass()
        {
            var builtString = ascendancyBox.Text;

            if (builtString == "Ascendant")
                return "";

            if (Properties.FormatOptions.Default.classBrackets)
                builtString = "[" + builtString + "]";

            if (Properties.FormatOptions.Default.classColour)
                switch (ascendancyBox.SelectedIndex)
                {
                    case 0:
                        builtString = "[span color=\"" + Properties.Settings.Default.Class1Colour + "\"]" + builtString + "[/span]";
                        break;
                    case 1:
                        builtString = "[span color=\"" + Properties.Settings.Default.Class2Colour + "\"]" + builtString + "[/span]";
                        break;
                    case 2:
                        builtString = "[span color=\"" + Properties.Settings.Default.Class3Colour + "\"]" + builtString + "[/span]";
                        break;
                }

            if (Properties.FormatOptions.Default.classUnderline)
                builtString = "[u]" + builtString + "[/u]";

            if (Properties.FormatOptions.Default.classItalics)
                builtString = "[i]" + builtString + "[/i]";

            if (Properties.FormatOptions.Default.classBold)
                builtString = "[b]" + builtString + "[/b]";

            if (Properties.FormatOptions.Default.spaceBetween)
                builtString += " ";

            return builtString;
        }

        private string getFormattedOptions()
        {
            var builtString = "";

            var hcString = "HC";
            var ssfString = "SSF";
            var lsString = "LS";

            if (Properties.FormatOptions.Default.optionBrackets)
            {
                hcString = "[" + hcString + "]";
                ssfString = "[" + ssfString + "]";
                lsString = "[" + lsString + "]";
            }

            if (Properties.FormatOptions.Default.optionColour)
            {
                hcString = "[span color=\"" + Properties.Settings.Default.hcColour + "\"]" + hcString + "[/span]";
                ssfString = "[span color=\"" + Properties.Settings.Default.ssfColour + "\"]" + ssfString + "[/span]";
                lsString = "[span color=\"" + Properties.Settings.Default.lsColour + "\"]" + lsString + "[/span]";
            }


            if (Properties.FormatOptions.Default.optionUnderline)
            {
                hcString = "[u]" + hcString + "[/u]";
                ssfString = "[u]" + ssfString + "[/u]";
                lsString = "[u]" + lsString + "[/u]";
            }


            if (Properties.FormatOptions.Default.optionItalics)
            {
                hcString = "[i]" + hcString + "[/i]";
                ssfString = "[i]" + ssfString + "[/i]";
                lsString = "[i]" + lsString + "[/i]";
            }


            if (Properties.FormatOptions.Default.optionBold)
            {
                hcString = "[b]" + hcString + "[/b]";
                ssfString = "[b]" + ssfString + "[/b]";
                lsString = "[b]" + lsString + "[/b]";
            }


            if (Properties.FormatOptions.Default.spaceBetween)
            {
                hcString += " ";
                ssfString += " ";
                lsString += " ";
            }

            if (tagBox.GetItemChecked(0))
                builtString += hcString;
            if (tagBox.GetItemChecked(1))
                builtString += ssfString;
            if (tagBox.GetItemChecked(2))
                builtString += lsString;

            return builtString;
        }

        private string getFormattedVersion()
        {

            string builtString = versionBox.Text;

            if (Properties.FormatOptions.Default.versionBrackets)
                builtString = "[" + builtString + "]";

            if (Properties.FormatOptions.Default.versionColour && versionBox.Text == Properties.Settings.Default.CurrentVersion)
                builtString = "[span color=\"" + Properties.Settings.Default.CurrentVersionHighlight + "\"]" + builtString + "[/span]";

            if (Properties.FormatOptions.Default.versionUnderline)
                builtString = "[u]" + builtString + "[/u]";

            if (Properties.FormatOptions.Default.versionItalics)
                builtString = "[i]" + builtString + "[/i]";

            if (Properties.FormatOptions.Default.versionBold)
                builtString = "[b]" + builtString + "[/b]";

            if (Properties.FormatOptions.Default.spaceBetween)
                builtString += " ";

            return builtString;
        }
        
        private string getFormattedFreetext()
        {
            var builtString = freeBox.Text;

            if (builtString == "" || builtString == " ")
                return "";

            if (Properties.FormatOptions.Default.freeBrackets)
                builtString = "[" + builtString + "]";

            if (Properties.FormatOptions.Default.freeColour)
                builtString = "[span color=\"" + Properties.FormatOptions.Default.freeColourCode + "\"]" + builtString + "[/span]";

            if (Properties.FormatOptions.Default.freeUnderline)
                builtString = "[u]" + builtString + "[/u]";

            if (Properties.FormatOptions.Default.freeItalics)
                builtString = "[i]" + builtString + "[/i]";

            if (Properties.FormatOptions.Default.freeBold)
                builtString = "[b]" + builtString + "[/b]";

            if (Properties.FormatOptions.Default.spaceBetween)
                builtString += " ";

            return builtString;
        }


        private string getFormattedURL()
        {
            return " [url=\"" + urlBox.Text + "\"]" + nameBox.Text + "[/url]";
        }

        private void saaveButton2_Click(object sender, EventArgs e)
        {
            save();
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            Properties.FormatOptions.Default.Reset();
            formatOptionsLoad();
        }

        private void guideListFormatter_FormClosing(object sender, FormClosingEventArgs e)
        {
            save();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            save();
        }

        private void save()
        {
            Properties.Settings.Default.PreviousClass = classBox.SelectedIndex;
            Properties.Settings.Default.CurrentVersion = versionOption.Text;
            Properties.Settings.Default.CurrentVersionHighlight = currentVersionColour.Text;

            Properties.Settings.Default.Class1Colour = class1Box.Text;
            Properties.Settings.Default.Class2Colour = class2Box.Text;
            Properties.Settings.Default.Class3Colour = class3Box.Text;

            Properties.Settings.Default.hcColour = hcBox.Text;
            Properties.Settings.Default.ssfColour = ssfBox.Text;
            Properties.Settings.Default.lsColour = lsBox.Text;


            Properties.Settings.Default.Save();

            classOptionsSave();
            formatOptionsSave();
        }

        private void classOptionsSave()
        {
            Properties.ClassOptions.Default.HierophantName = hieOption.Text;
            Properties.ClassOptions.Default.InquisitorName = inqOption.Text;
            Properties.ClassOptions.Default.GuardianName = guaOption.Text;

            Properties.ClassOptions.Default.SlayerName = slayerOption.Text;
            Properties.ClassOptions.Default.GladiatorName = gladOption.Text;
            Properties.ClassOptions.Default.ChampionName = champOption.Text;

            Properties.ClassOptions.Default.JuggernautName = juggOption.Text;
            Properties.ClassOptions.Default.ChieftainName = chiefOption.Text;
            Properties.ClassOptions.Default.BerserkerName = bersOption.Text;

            Properties.ClassOptions.Default.RaiderName = raidOption.Text;
            Properties.ClassOptions.Default.PathfinderName = pathOption.Text;
            Properties.ClassOptions.Default.DeadeyeName = deadOption.Text;

            Properties.ClassOptions.Default.TricksterName = trickOption.Text;
            Properties.ClassOptions.Default.AssassinName = assOption.Text;
            Properties.ClassOptions.Default.SaboteurName = sabOption.Text;

            Properties.ClassOptions.Default.OccultistName = occOption.Text;
            Properties.ClassOptions.Default.ElementalistName = eleOption.Text;
            Properties.ClassOptions.Default.NecromancerName = necOption.Text;

            Properties.ClassOptions.Default.Save();
        }

        private void formatOptionsSave()
        {
            Properties.FormatOptions.Default.abilityBrackets = abilityOptions.GetItemChecked(0);
            Properties.FormatOptions.Default.abilityBold = abilityOptions.GetItemChecked(1);
            Properties.FormatOptions.Default.abilityItalics = abilityOptions.GetItemChecked(2);
            Properties.FormatOptions.Default.abilityUnderline = abilityOptions.GetItemChecked(3);
            Properties.FormatOptions.Default.abilityColour = abilityOptions.GetItemChecked(4);

            Properties.FormatOptions.Default.classBrackets = classOptions.GetItemChecked(0);
            Properties.FormatOptions.Default.classBold = classOptions.GetItemChecked(1);
            Properties.FormatOptions.Default.classItalics = classOptions.GetItemChecked(2);
            Properties.FormatOptions.Default.classUnderline = classOptions.GetItemChecked(3);
            Properties.FormatOptions.Default.classColour = classOptions.GetItemChecked(4);

            Properties.FormatOptions.Default.optionBrackets = optionOptions.GetItemChecked(0);
            Properties.FormatOptions.Default.optionBold = optionOptions.GetItemChecked(1);
            Properties.FormatOptions.Default.optionItalics = optionOptions.GetItemChecked(2);
            Properties.FormatOptions.Default.optionUnderline = optionOptions.GetItemChecked(3);
            Properties.FormatOptions.Default.optionColour = optionOptions.GetItemChecked(4);

            Properties.FormatOptions.Default.versionBrackets = versionOptions.GetItemChecked(0);
            Properties.FormatOptions.Default.versionBold = versionOptions.GetItemChecked(1);
            Properties.FormatOptions.Default.versionItalics = versionOptions.GetItemChecked(2);
            Properties.FormatOptions.Default.versionUnderline = versionOptions.GetItemChecked(3);
            Properties.FormatOptions.Default.versionColour = versionOptions.GetItemChecked(4);

            Properties.FormatOptions.Default.freeBrackets = freeOptions.GetItemChecked(0);
            Properties.FormatOptions.Default.freeBold = freeOptions.GetItemChecked(1);
            Properties.FormatOptions.Default.freeItalics = freeOptions.GetItemChecked(2);
            Properties.FormatOptions.Default.freeUnderline = freeOptions.GetItemChecked(3);
            Properties.FormatOptions.Default.freeColour = freeOptions.GetItemChecked(4);


            Properties.FormatOptions.Default.abilityColourCode = abilityColourBox.Text;
            Properties.FormatOptions.Default.freeColourCode = freeColourBox.Text;

            Properties.FormatOptions.Default.dashURL = dashBox.Checked;

            Properties.FormatOptions.Default.Save();
        }

        private void guideListFormatter_Load(object sender, EventArgs e)
        {

            versionBox.Text = Properties.Settings.Default.CurrentVersion;
            versionOption.Text = Properties.Settings.Default.CurrentVersion;
            classBox.SelectedIndex = Properties.Settings.Default.PreviousClass;
            currentVersionColour.Text = Properties.Settings.Default.CurrentVersionHighlight;

            class1Box.Text = Properties.Settings.Default.Class1Colour;
            class2Box.Text = Properties.Settings.Default.Class2Colour;
            class3Box.Text = Properties.Settings.Default.Class3Colour;

            hcBox.Text = Properties.Settings.Default.hcColour;
            ssfBox.Text = Properties.Settings.Default.ssfColour;
            lsBox.Text = Properties.Settings.Default.lsColour;

            classOptionsLoad();
            formatOptionsLoad();
        }

        private void classOptionsLoad()
        {
            hieOption.Text = Properties.ClassOptions.Default.HierophantName;
            inqOption.Text = Properties.ClassOptions.Default.InquisitorName;
            guaOption.Text = Properties.ClassOptions.Default.GuardianName;

            slayerOption.Text = Properties.ClassOptions.Default.SlayerName;
            gladOption.Text = Properties.ClassOptions.Default.GladiatorName;
            champOption.Text = Properties.ClassOptions.Default.ChampionName;

            juggOption.Text = Properties.ClassOptions.Default.JuggernautName;
            chiefOption.Text = Properties.ClassOptions.Default.ChieftainName;
            bersOption.Text = Properties.ClassOptions.Default.BerserkerName;

            raidOption.Text = Properties.ClassOptions.Default.RaiderName;
            pathOption.Text = Properties.ClassOptions.Default.PathfinderName;
            deadOption.Text = Properties.ClassOptions.Default.DeadeyeName;

            trickOption.Text = Properties.ClassOptions.Default.TricksterName;
            assOption.Text = Properties.ClassOptions.Default.AssassinName;
            sabOption.Text = Properties.ClassOptions.Default.SaboteurName;

            occOption.Text = Properties.ClassOptions.Default.OccultistName;
            necOption.Text = Properties.ClassOptions.Default.NecromancerName;
            eleOption.Text = Properties.ClassOptions.Default.ElementalistName;

        }

        private void formatOptionsLoad()
        {
            abilityOptions.SetItemChecked(0, Properties.FormatOptions.Default.abilityBrackets);
            abilityOptions.SetItemChecked(1, Properties.FormatOptions.Default.abilityBold);
            abilityOptions.SetItemChecked(2, Properties.FormatOptions.Default.abilityItalics);
            abilityOptions.SetItemChecked(3, Properties.FormatOptions.Default.abilityUnderline);
            abilityOptions.SetItemChecked(4, Properties.FormatOptions.Default.abilityColour);

            classOptions.SetItemChecked(0, Properties.FormatOptions.Default.classBrackets);
            classOptions.SetItemChecked(1, Properties.FormatOptions.Default.classBold);
            classOptions.SetItemChecked(2, Properties.FormatOptions.Default.classItalics);
            classOptions.SetItemChecked(3, Properties.FormatOptions.Default.classUnderline);
            classOptions.SetItemChecked(4, Properties.FormatOptions.Default.classColour);

            optionOptions.SetItemChecked(0, Properties.FormatOptions.Default.optionBrackets);
            optionOptions.SetItemChecked(1, Properties.FormatOptions.Default.optionBold);
            optionOptions.SetItemChecked(2, Properties.FormatOptions.Default.optionItalics);
            optionOptions.SetItemChecked(3, Properties.FormatOptions.Default.optionUnderline);
            optionOptions.SetItemChecked(4, Properties.FormatOptions.Default.optionColour);

            versionOptions.SetItemChecked(0, Properties.FormatOptions.Default.versionBrackets);
            versionOptions.SetItemChecked(1, Properties.FormatOptions.Default.versionBold);
            versionOptions.SetItemChecked(2, Properties.FormatOptions.Default.versionItalics);
            versionOptions.SetItemChecked(3, Properties.FormatOptions.Default.versionUnderline);
            versionOptions.SetItemChecked(4, Properties.FormatOptions.Default.versionColour);

            freeOptions.SetItemChecked(0, Properties.FormatOptions.Default.freeBrackets);
            freeOptions.SetItemChecked(1, Properties.FormatOptions.Default.freeBold);
            freeOptions.SetItemChecked(2, Properties.FormatOptions.Default.freeItalics);
            freeOptions.SetItemChecked(3, Properties.FormatOptions.Default.freeUnderline);
            freeOptions.SetItemChecked(4, Properties.FormatOptions.Default.freeColour);

            abilityColourBox.Text = Properties.FormatOptions.Default.abilityColourCode;
            freeColourBox.Text = Properties.FormatOptions.Default.freeColourCode;

            dashBox.Checked = Properties.FormatOptions.Default.dashURL;
        }


        private string[] templarClasses = new[]
        {
            Properties.ClassOptions.Default.HierophantName,
            Properties.ClassOptions.Default.InquisitorName,
            Properties.ClassOptions.Default.GuardianName
        };
        private string[] duelistClasses = new[]
        {
            Properties.ClassOptions.Default.GladiatorName,
            Properties.ClassOptions.Default.ChampionName,
            Properties.ClassOptions.Default.SlayerName
        };
        private string[] marauderClasses = new[]
        {
            Properties.ClassOptions.Default.JuggernautName,
            Properties.ClassOptions.Default.ChieftainName,
            Properties.ClassOptions.Default.BerserkerName
        };
        private string[] rangerClasses = new[]
        {
            Properties.ClassOptions.Default.DeadeyeName,
            Properties.ClassOptions.Default.PathfinderName,
            Properties.ClassOptions.Default.RaiderName
        };
        private string[] shadowClasses = new[]
        {
            Properties.ClassOptions.Default.TricksterName,
            Properties.ClassOptions.Default.AssassinName,
            Properties.ClassOptions.Default.SaboteurName
        };
        private string[] witchClasses = new[]
        {
            Properties.ClassOptions.Default.OccultistName,
            Properties.ClassOptions.Default.ElementalistName,
            Properties.ClassOptions.Default.NecromancerName
        };
        private string[] scionClasses = new[]
        {
            "Ascendant"
        };

        private void classBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (classBox.SelectedIndex)
            {
                case 0:
                    ascendancyBox.DataSource = templarClasses;
                    break;
                case 1:
                    ascendancyBox.DataSource = duelistClasses;
                    break;
                case 2:
                    ascendancyBox.DataSource = rangerClasses;
                    break;
                case 3:
                    ascendancyBox.DataSource = witchClasses;
                    break;
                case 4:
                    ascendancyBox.DataSource = shadowClasses;
                    break;
                case 5:
                    ascendancyBox.DataSource = marauderClasses;
                    break;
                case 6:
                    ascendancyBox.DataSource = scionClasses;
                    break;
            }

        }
    }
}
