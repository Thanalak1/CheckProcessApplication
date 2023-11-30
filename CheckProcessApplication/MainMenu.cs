using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckProcessApplication
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
            customizeDesign();
        }

        private void customizeDesign() {
            FoundryPanelSub.Visible = false;
            DressPanelSub.Visible = false;
            BuryPanelSub.Visible = false;
            BathePanelSub.Visible=false;
            PolishPanelSub.Visible = false;
        }

        private void hideSubMenu() {
            if (FoundryPanelSub.Visible = true) {
                FoundryPanelSub.Visible = false;
            }
            if (DressPanelSub.Visible = true) {
                DressPanelSub.Visible = false;
            }
            if (BuryPanelSub.Visible = true) {
                BuryPanelSub.Visible = false;
            }
            if (BathePanelSub.Visible = true) {
                BathePanelSub.Visible = false;
            }
            if (PolishPanelSub.Visible = true) {
                PolishPanelSub.Visible = false;
            }
        }

        private void showSubMenu(Panel subMenu) {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else { 
                subMenu.Visible = false;
            }
        }

        private void BatheBtn_Click(object sender, EventArgs e)
        {
            openChildForms(new BatheForms());
            hideSubMenu();
        }

        private void FoundryMain_Click(object sender, EventArgs e)
        {
            showSubMenu(FoundryPanelSub);
        }

        private void DressMain_Click(object sender, EventArgs e)
        {
            showSubMenu(DressPanelSub);
        }

        private void PolishMain_Click(object sender, EventArgs e)
        {
            showSubMenu(PolishPanelSub);
        }

        private void BuryMain_Click(object sender, EventArgs e)
        {
            showSubMenu(BuryPanelSub);
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BatheMain_Click(object sender, EventArgs e)
        {
            showSubMenu(BathePanelSub);
        }

        private Form activeForm = null;
        private void openChildForms(Form childForm)
        {

            if (activeForm != null)
            {
                activeForm.Close();
            }

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            ProgramPanel.Controls.Add(childForm);
            ProgramPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void BuryBtn_Click(object sender, EventArgs e)
        {
            openChildForms(new BuryForms());
            hideSubMenu();
        }

        private void DressBtn_Click(object sender, EventArgs e)
        {
            openChildForms(new DressForms());
            hideSubMenu();
        }

        private void BatheAndPolishBtn_Click(object sender, EventArgs e)
        {
            openChildForms(new BatheAndPolish());
            hideSubMenu();
        }
    }
}
