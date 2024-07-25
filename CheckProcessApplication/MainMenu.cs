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
            panelComplete.Visible = false;
        }

        private void hideSubMenu() {
            if (FoundryPanelSub.Visible) {
                FoundryPanelSub.Visible = false;
            }
            if (DressPanelSub.Visible) {
                DressPanelSub.Visible = false;
            }
            if (BuryPanelSub.Visible) {
                BuryPanelSub.Visible = false;
            }
            if (BathePanelSub.Visible) {
                BathePanelSub.Visible = false;
            }
            if (PolishPanelSub.Visible) {
                PolishPanelSub.Visible = false;
            }
            if (panelComplete.Visible) { 
                panelComplete.Visible = false;
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

        private void LeeBtn_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void CompleteMain_Click(object sender, EventArgs e)
        {
            showSubMenu(panelComplete);
        }

        private void completeNecklaceBtn_Click(object sender, EventArgs e)
        {
            openChildForms(new completeForm());
            hideSubMenu();
        }

        private void FoundryBtn_Click(object sender, EventArgs e)
        {
            openChildForms(new Foundry());
            hideSubMenu();
        }

        private void FoundryAndDressBtn_Click(object sender, EventArgs e)
        {

        }

        private void DressAndPolishBtn_Click(object sender, EventArgs e)
        {

        }

        private void PolishBtn_Click(object sender, EventArgs e)
        {
            openChildForms(new Polish());
            hideSubMenu();
        }

        private void PolishAndBuryBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
