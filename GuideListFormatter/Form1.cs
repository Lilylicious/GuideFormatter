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
    public partial class guideListFormatter : Form
    {
        public guideListFormatter()
        {
            InitializeComponent();
        }

        private const string hcColour = "#ff0000";
        private const string ssfColour = "#8080ff";
        private const string lsColour = "#ff80ff";

        private void guideListFormatter_Load(object sender, EventArgs e)
        {

            versionBox.Text = Properties.Settings.Default.CurrentVersion;
            versionOption.Text = Properties.Settings.Default.CurrentVersion;
            classBox.SelectedIndex = Properties.Settings.Default.PreviousClass;
            currentVersionColour.Text = Properties.Settings.Default.CurrentVersionHighlight;

            class1Box.Text = Properties.Settings.Default.Class1Colour;
            class2Box.Text = Properties.Settings.Default.Class2Colour;
            class3Box.Text = Properties.Settings.Default.Class3Colour;

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


            Properties.Settings.Default.Save();
            Properties.ClassOptions.Default.Save();
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

        private void generateButton_Click(object sender, EventArgs e)
        {
            var builtString = "";
            resultBox.Text = "";

            builtString += getFormattedClass();
            builtString += getFormattedOptions();
            builtString += getFormattedVersion();
            builtString += getFormattedURL();

            resultBox.Text = builtString;
        }

        private string getFormattedVersion()
        {
            string val = versionBox.Text;

            if (val != Properties.Settings.Default.CurrentVersion)
                return "[" + val + "]";

            return "[span color=\"" + Properties.Settings.Default.CurrentVersionHighlight + "\"][" + val + "][/span]";
        }

        private string getFormattedClass()
        {
            if (classBox.Text == "Scion")
                return "";

            switch (ascendancyBox.SelectedIndex)
            {
                case 0:
                    return "[span color=\"" + Properties.Settings.Default.Class1Colour + "\"][" + ascendancyBox.Text + "][/span]";
                case 1:
                    return "[span color=\"" + Properties.Settings.Default.Class2Colour + "\"][" + ascendancyBox.Text + "][/span]";
                case 2:
                    return "[span color=\"" + Properties.Settings.Default.Class3Colour + "\"][" + ascendancyBox.Text + "][/span]";
            }

            return "Error";
        }

        private string getFormattedOptions()
        {
            string tempString = "";

            if (tagBox.GetItemChecked(0))
                tempString += "[span color=\"" + hcColour + "\"][HC][/span]";
            if (tagBox.GetItemChecked(1))
                tempString += "[span color=\"" + ssfColour + "\"][SSF][/span]";
            if (tagBox.GetItemChecked(2))
                tempString += "[span color=\"" + lsColour + "\"][LS][/span]";

            return tempString;
        }

        private string getFormattedURL()
        {
            return " [url=\"" + urlBox.Text + "\"]" + nameBox.Text + "[/url]";
        }
    }
}
