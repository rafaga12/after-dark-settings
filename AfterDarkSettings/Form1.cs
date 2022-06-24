
/*
Copyright (c) 2022 Rafaga Systems (Rafael Garay Perez)

This file is part of After Dark Settings.

After Dark Settings is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.

After Dark Settings is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with After Dark Settings. If not, see <https://www.gnu.org/licenses/>. 
*/

using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vestris.ResourceLib;
using static System.Windows.Forms.ListView;

namespace AfterDarkSettings
{
    public partial class Form1 : Form
    {
        String ControlPrefix = "Control";
        String ValuePrefix = "Value";

        //HKEY_CURRENT_USER\SOFTWARE\Berkeley Systems\After Dark
        private RegistryKey AfterDarkKey
        {
            get
            {
                RegistryKey SoftwareKey = Registry.CurrentUser.OpenSubKey("SOFTWARE");
                return SoftwareKey.OpenSubKey("Berkeley Systems").OpenSubKey("After Dark", true);
            }
        }

        private RegistryKey GetModuleKey(string SelectedFolder, string ModuleName)
        {
            RegistryKey ModuleSettingsKey = AfterDarkKey.OpenSubKey("Module Settings");
            return ModuleSettingsKey.OpenSubKey(SelectedFolder).OpenSubKey(ModuleName, true);
        }
        //HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Berkeley Systems\After Dark\4.00
        private RegistryKey AfterDarkPathKey
        {
            get
            {
                RegistryKey SoftwareKey = Registry.LocalMachine.OpenSubKey("SOFTWARE");
                return SoftwareKey.OpenSubKey("Berkeley Systems").OpenSubKey("After Dark").OpenSubKey("4.00");
            }
        }

        private string AfterDarkPath
        {
            get
            {
                //return "C:\\After Dark";
                return AfterDarkPathKey.GetValue("Path").ToString();
            }
        }

        public Form1()
        {
            InitializeComponent();
            GetConfiguration();
            ListFolders();
            GetFolder();
            ListModules();
            GetModule();

            //int KeyValue = (int)(Keys.Control | Keys.Shift | Keys.S);
        }

        private void ListFolders()
        {
            string[] FolderPaths = Directory.GetDirectories (AfterDarkPath);
            foreach (string FolderPath in FolderPaths)
            {
                string[] ModulePaths = Directory.GetFiles(FolderPath, "*.ad");
                if (ModulePaths.Length > 0)
                {
                    string FolderName = Path.GetFileName(FolderPath);
                    FolderComboBox.Items.Add(FolderName);
                }
            }
        }

        private void SetFolder()
        {
            string SelectedFolder = FolderComboBox.SelectedItem.ToString();
            //HKEY_CURRENT_USER\SOFTWARE\Berkeley Systems\After Dark
            AfterDarkKey.SetValue("SelectedFolder", SelectedFolder, RegistryValueKind.String);
        }

        private void GetFolder()
        {
            //HKEY_CURRENT_USER\SOFTWARE\Berkeley Systems\After Dark\Folders
            string SelectedFolder = AfterDarkKey.GetValue("SelectedFolder").ToString();
            FolderComboBox.SelectedItem = SelectedFolder;
        }

        private void ListModules()
        {
            string SelectedFolder = FolderComboBox.SelectedItem.ToString();
            string[] ModulePaths = Directory.GetFiles(AfterDarkPath + "\\" + SelectedFolder, "*.ad");
            ModulesListView.Items.Clear();
            foreach (string ModulePath in ModulePaths)
            {
                string ModuleName = Path.GetFileNameWithoutExtension(ModulePath);
                ListViewItem ModuleItem = new ListViewItem(ModuleName);
                ModuleItem.Tag = ModulePath;
                ModulesListView.Items.Add(ModuleItem);
            }
        }

        private void SetModule()
        {
            string SelectedFolder = FolderComboBox.SelectedItem.ToString();
            if (RandomCheckBox.Checked)
            {
                foreach (ListViewItem ModuleItem in ModulesListView.Items)
                {
                    string ModuleName = ModuleItem.Text;
                    bool ModuleSelected = ModuleItem.Checked;
                    GetModuleKey(SelectedFolder, ModuleName).SetValue("UseInRandomizer", ModuleSelected, RegistryValueKind.DWord);
                }
            }
            else
            {
                string SelectedModuleName = ModulesListView.SelectedItems[0].Text;
                //HKEY_CURRENT_USER\SOFTWARE\Berkeley Systems\After Dark\Folders
                AfterDarkKey.OpenSubKey("Folders", true).SetValue(SelectedFolder, SelectedModuleName, RegistryValueKind.String);
            }
        }

        private void GetModule()
        {
            string SelectedFolder = FolderComboBox.SelectedItem.ToString();
            if (RandomCheckBox.Checked)
            {
                try
                {
                    foreach (ListViewItem ModuleItem in ModulesListView.Items)
                    {
                        string ModuleName = ModuleItem.Text;
                        bool ModuleSelected = Convert.ToBoolean(GetModuleKey(SelectedFolder, ModuleName).GetValue("UseInRandomizer"));
                        ModuleItem.Checked = ModuleSelected;
                    }
                }
                catch (Exception)
                {

                }
            }
            else
            {
                bool ModuleSelected = false;
                //HKEY_CURRENT_USER\SOFTWARE\Berkeley Systems\After Dark\Folders
                try
                {
                    string SelectedModule = AfterDarkKey.OpenSubKey("Folders", true).GetValue(SelectedFolder).ToString();
                    foreach (ListViewItem ModuleItem in ModulesListView.Items)
                    {
                        if (ModuleItem.Text == SelectedModule)
                        {
                            ModuleItem.Selected = true;
                            ModuleSelected = true;
                            break;
                        }
                    }
                }
                catch (Exception)
                {

                }
                if (!ModuleSelected)
                {
                    ModulesListView.Items[0].Selected = true;
                }
            }
        }

        private void SetConfiguration()
        {
            AfterDarkKey.SetValue("Randomizer", RandomCheckBox.Checked, RegistryValueKind.DWord);
            AfterDarkKey.SetValue("MuteSound", MuteCheckBox.Checked, RegistryValueKind.DWord);
            AfterDarkKey.SetValue("AnimatedMiniPreview", PreviewCheckBox.Checked, RegistryValueKind.DWord);
            AfterDarkKey.SetValue("ControlOnTaskbar", TaskbarCheckBox .Checked, RegistryValueKind.DWord);
            AfterDarkKey.SetValue("RandomizerDuration", RandomNumericUpDown.Value * 60 * 1000, RegistryValueKind.DWord);
        }

        private void GetConfiguration()
        {
            RandomCheckBox.Checked = Convert.ToBoolean(AfterDarkKey.GetValue("Randomizer"));
            MuteCheckBox.Checked = Convert.ToBoolean(AfterDarkKey.GetValue("MuteSound"));
            PreviewCheckBox.Checked = Convert.ToBoolean(AfterDarkKey.GetValue("AnimatedMiniPreview"));
            TaskbarCheckBox.Checked = Convert.ToBoolean(AfterDarkKey.GetValue("ControlOnTaskbar"));
            decimal RandomValue = Convert.ToDecimal(AfterDarkKey.GetValue("RandomizerDuration")) / 1000 / 60;
            if (RandomValue < 1)
            {
                RandomValue = 5;
            }
            RandomNumericUpDown.Value = (int)RandomValue;
        }

        private void SetModuleConfiguration()
        {
            string SelectedFolder = FolderComboBox.SelectedItem.ToString();
            ListViewItem ModuleItem = ModulesListView.FocusedItem;
            string ModuleName = ModuleItem.Text;
            for (int i = 0; i < ModuleConfig.Controls.Count / 3; i++)
            {
                string ControlName = String.Format("{0}{1}", ControlPrefix, i);
                Control[] Controls = ModuleConfig.Controls.Find(ControlName, true);
                Control CurrentControl = Controls[0];
                ADControlInfo ControlInfo = (ADControlInfo)CurrentControl.Tag;
                switch (ControlInfo.ControlType)
                {
                    case ADControl.NumberSlider:
                        GetModuleKey(SelectedFolder, ModuleName).SetValue(ControlName, ((TrackBar)CurrentControl).Value, RegistryValueKind.DWord);
                        break;
                    case ADControl.TextSlider:
                        GetModuleKey(SelectedFolder, ModuleName).SetValue(ControlName, ((TrackBar)CurrentControl).Value, RegistryValueKind.DWord);
                        break;
                    case ADControl.ComboBox:
                        GetModuleKey(SelectedFolder, ModuleName).SetValue(ControlName, ((ComboBox)CurrentControl).SelectedIndex, RegistryValueKind.DWord);
                        break;
                    case ADControl.CheckBox:
                        GetModuleKey(SelectedFolder, ModuleName).SetValue(ControlName, ((CheckBox)CurrentControl).Checked, RegistryValueKind.DWord);
                        break;
                    case ADControl.PushButton:
                        break;
                    default:
                        break;
                }
            }
        }

        private void GetModuleConfiguration()
        {
            string SelectedFolder = FolderComboBox.SelectedItem.ToString();
            ListViewItem ModuleItem = null;
            if (ModulesListView.FocusedItem != null)
            {
                ModuleItem = ModulesListView.FocusedItem;
            }
            else
            {
                ModuleItem = ModulesListView.SelectedItems[0];
            }
            
            string ModuleName = ModuleItem.Text;
            for (int i = 0; i < ModuleConfig.Controls.Count / 3; i++)
            {
                string ControlName = String.Format("{0}{1}", ControlPrefix, i);
                if (GetModuleKey(SelectedFolder, ModuleName).GetValue(ControlName) != null)
                {
                    Control[] Controls = ModuleConfig.Controls.Find(ControlName, true);
                    Control CurrentControl = Controls[0];
                    ADControlInfo ControlInfo = (ADControlInfo)CurrentControl.Tag;
                    switch (ControlInfo.ControlType)
                    {
                        case ADControl.NumberSlider:
                            ((TrackBar)CurrentControl).Value = Convert.ToInt32(GetModuleKey(SelectedFolder, ModuleName).GetValue(ControlName));
                            break;
                        case ADControl.TextSlider:
                            ((TrackBar)CurrentControl).Value = Convert.ToInt32(GetModuleKey(SelectedFolder, ModuleName).GetValue(ControlName));
                            break;
                        case ADControl.ComboBox:
                            ((ComboBox)CurrentControl).SelectedIndex = Convert.ToInt32(GetModuleKey(SelectedFolder, ModuleName).GetValue(ControlName));
                            break;
                        case ADControl.CheckBox:
                            GetModuleKey(SelectedFolder, ModuleName).SetValue(ControlName, ((CheckBox)CurrentControl).Checked ? 1 : 0, RegistryValueKind.DWord);
                            ((CheckBox)CurrentControl).Checked = Convert.ToBoolean(GetModuleKey(SelectedFolder, ModuleName).GetValue(ControlName));
                            break;
                        case ADControl.PushButton:
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private void SelectButton_Click(object sender, EventArgs e)
        {
            SetConfiguration();
            SetFolder();
            SetModule();
            SetModuleConfiguration();
        }

        
        private void FolderComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListModules();
            GetModule();
        }

        private void RandomCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ModulesListView.MultiSelect = RandomCheckBox.Checked;
            ModulesListView.CheckBoxes = RandomCheckBox.Checked;
        }

        private void ModulesListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            ModuleConfig.Controls.Clear();
            ListView ModulesList = (ListView)sender;
            if (ModulesList.SelectedItems.Count > 0)
            {
                ListViewItem SelectedModule = ModulesList.SelectedItems[0];
                string filename = (string)SelectedModule.Tag;
                using (ResourceInfo vi = new ResourceInfo())
                {
                    try
                    {
                        vi.Load(filename);
                        int idIndex = vi.ResourceTypes.IndexOf(new ResourceId((Kernel32.ResourceTypes)1000));
                        ResourceId id = vi.ResourceTypes[idIndex];
                        
                        List<Resource> Resources = vi.Resources[id].FindAll((x) => x.Language == 1033 || x.Language == 0);
                        int ControlNumber = 0;
                        foreach (Resource resource in Resources)
                        {
                            try
                            {
                                ADControlInfo ControlInfo = new ADControlInfo(resource.WriteAndGetBytes());
                                Label ControlLabel = new Label();
                                Control CurrentControl = null;
                                Label ControlValue = new Label();
                                switch (ControlInfo.ControlType)
                                {
                                    case ADControl.NumberSlider:
                                        ControlLabel.Text = ControlInfo.ControlName;
                                        CurrentControl = new TrackBar();
                                        ((TrackBar)CurrentControl).Minimum = ControlInfo.MinValue;
                                        ((TrackBar)CurrentControl).Maximum = ControlInfo.MaxValue;
                                        ((TrackBar)CurrentControl).Value = ControlInfo.DefaultValue;
                                        ControlValue.Text = string.Format("{0}" + ControlInfo.Suffix, ((TrackBar)CurrentControl).Value);
                                        ((TrackBar)CurrentControl).ValueChanged += trackBar_ValueChanged;
                                        break;
                                    case ADControl.TextSlider:
                                        ControlLabel.Text = ControlInfo.ControlName;
                                        CurrentControl = new TrackBar();
                                        ((TrackBar)CurrentControl).Minimum = 0;
                                        ((TrackBar)CurrentControl).Maximum = ControlInfo.Steps - 1;
                                        int i;
                                        for (i = 0; i < ControlInfo.Steps; i++)
                                        {
                                            if (ControlInfo.DefaultValue < ControlInfo.Thresholds[i])
                                            {
                                                break;
                                            }
                                        }
                                        ((TrackBar)CurrentControl).Value = i - 1;
                                        ControlValue.Text = string.Format("{0}", ControlInfo.Values[((TrackBar)CurrentControl).Value]);
                                        ((TrackBar)CurrentControl).ValueChanged += textTrackBar_ValueChanged;
                                        break;
                                    case ADControl.ComboBox:
                                        ControlLabel.Text = ControlInfo.ControlName;
                                        CurrentControl = new ComboBox();
                                        ((ComboBox)CurrentControl).Items.AddRange(ControlInfo.Values);
                                        ((ComboBox)CurrentControl).SelectedIndex = ControlInfo.DefaultValue;
                                        break;
                                    case ADControl.CheckBox:
                                        ControlLabel.Text = ControlInfo.ControlName;
                                        CurrentControl = new CheckBox();
                                        ((CheckBox)CurrentControl).Checked = false;
                                        if (ControlInfo.DefaultValue > 0)
                                        {
                                            ((CheckBox)CurrentControl).Checked = true;
                                        }
                                        break;
                                    case ADControl.PushButton:
                                        CurrentControl = new Button();
                                        ((Button)CurrentControl).Text = ControlInfo.ControlName;
                                        break;
                                    default:
                                        CurrentControl = new Label();
                                        break;
                                }
                                CurrentControl.Name = String.Format("{0}{1}", ControlPrefix, ControlNumber);
                                ControlValue.Name = String.Format("{0}{1}", ValuePrefix, ControlNumber);
                                CurrentControl.Tag = ControlInfo;
                                /*ControlLabel.BackColor = Color.Black;
                                CurrentControl.BackColor = Color.Black;
                                ControlValue.BackColor = Color.Black;*/
                                ModuleConfig.Controls.Add(ControlLabel);
                                ModuleConfig.Controls.Add(CurrentControl);
                                ModuleConfig.Controls.Add(ControlValue);
                                ControlLabel.Dock = DockStyle.Fill;
                                CurrentControl.Dock = DockStyle.Fill;
                                ControlValue.Dock = DockStyle.Fill;
                                ControlLabel.TextAlign = ContentAlignment.MiddleLeft;
                                ControlValue.TextAlign = ContentAlignment.MiddleLeft;
                                ControlNumber++;
                            }
                            catch (Exception ex)
                            {

                                throw ex;
                            }
                        }
                        GetModuleConfiguration();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void trackBar_ValueChanged(object sender, EventArgs e)
        {
            TrackBar CurrentControl = (TrackBar)sender;
            ADControlInfo ControlInfo = (ADControlInfo)CurrentControl.Tag;
            string ControlName = CurrentControl.Name.Replace(ControlPrefix, ValuePrefix);
            Control[] Controls = ModuleConfig.Controls.Find(ControlName, true);
            Label ControlValue = (Label)Controls[0];
            ControlValue.Text = string.Format("{0}" + ControlInfo.Suffix, CurrentControl.Value);
        }

        private void textTrackBar_ValueChanged(object sender, EventArgs e)
        {
            TrackBar CurrentControl = (TrackBar)sender;
            ADControlInfo ControlInfo = (ADControlInfo)CurrentControl.Tag;
            string ControlName = CurrentControl.Name.Replace(ControlPrefix, ValuePrefix);
            Control[] Controls = ModuleConfig.Controls.Find(ControlName, true);
            Label ControlValue = (Label)Controls[0];
            ControlValue.Text = string.Format("{0}", ControlInfo.Values[CurrentControl.Value]);
        }
    }
}
