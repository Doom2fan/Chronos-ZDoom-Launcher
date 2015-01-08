using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Launcher {
    public partial class FormGameplayOptions : Form {
        public FormGameplayOptions () {
            InitializeComponent ();

			PopulateFields ();
        }

		#region ============ Functions ============

		// Populate the form's fields
		private void PopulateFields () {
			#region ============ General ============

			comboBoxFallingDamage.Text = Game.Configurations.GameplayOptions.sv_fallingdamage;
			checkBoxDoubleAmmo.Checked = Game.Configurations.GameplayOptions.sv_doubleammo;
			checkBoxDropWeapon.Checked = Game.Configurations.GameplayOptions.sv_weapondrop;
			checkBoxInfiniteAmmo.Checked = Game.Configurations.GameplayOptions.sv_infiniteammo;
			checkBoxInfiniteInventory.Checked = Game.Configurations.GameplayOptions.sv_infiniteinventory;
			checkBoxNoMonsters.Checked = Game.Configurations.GameplayOptions.sv_nomonsters;
			checkBoxKillAllMonsters.Checked = Game.Configurations.GameplayOptions.sv_killallmonsters;
			checkBoxMonstersRespawn.Checked = Game.Configurations.GameplayOptions.sv_monsterrespawn;
			checkBoxNoRespawn.Checked = Game.Configurations.GameplayOptions.sv_norespawn;
			checkBoxItemsRespawn.Checked = Game.Configurations.GameplayOptions.sv_itemsrespawn;
			checkBoxRespawnSuper.Checked = Game.Configurations.GameplayOptions.sv_respawnsuper;
			checkBoxFastMonsters.Checked = Game.Configurations.GameplayOptions.sv_fastmonsters;
			checkBoxDegeneration.Checked = Game.Configurations.GameplayOptions.sv_degeneration;
			checkBoxAllowAutoaim.Checked = !Game.Configurations.GameplayOptions.sv_noautoaim;

			if (Game.Configurations.GameplayOptions.sv_jump == Trilean.Indeterminate)
				checkBoxAllowJump.CheckState = CheckState.Indeterminate;
			else if (Game.Configurations.GameplayOptions.sv_jump == Trilean.True)
				checkBoxAllowJump.CheckState = CheckState.Checked;
			else if (Game.Configurations.GameplayOptions.sv_jump == Trilean.False)
				checkBoxAllowJump.CheckState = CheckState.Unchecked;

			if (Game.Configurations.GameplayOptions.sv_crouch == Trilean.Indeterminate)
				checkBoxAllowCrouch.CheckState = CheckState.Indeterminate;
			else if (Game.Configurations.GameplayOptions.sv_crouch == Trilean.True)
				checkBoxAllowCrouch.CheckState = CheckState.Checked;
			else if (Game.Configurations.GameplayOptions.sv_crouch == Trilean.False)
				checkBoxAllowCrouch.CheckState = CheckState.Unchecked;

			if (Game.Configurations.GameplayOptions.sv_freelook == Trilean.Indeterminate)
				checkBoxAllowFreelook.CheckState = CheckState.Indeterminate;
			else if (Game.Configurations.GameplayOptions.sv_freelook == Trilean.True)
				checkBoxAllowFreelook.CheckState = CheckState.Checked;
			else if (Game.Configurations.GameplayOptions.sv_freelook == Trilean.False)
				checkBoxAllowFreelook.CheckState = CheckState.Unchecked;

			checkBoxAllowFOV.Checked = !Game.Configurations.GameplayOptions.sv_nofov;
			checkBoxBFGAiming.Checked = !Game.Configurations.GameplayOptions.sv_nobfgaim;
			checkBoxAllowAutomap.Checked = !Game.Configurations.GameplayOptions.sv_noautomap;
			checkBoxAutomapAllies.Checked = !Game.Configurations.GameplayOptions.sv_noautomapallies;
			checkBoxAllowSpying.Checked = !Game.Configurations.GameplayOptions.sv_disallowspying;
			checkBoxChasecamCheat.Checked = Game.Configurations.GameplayOptions.sv_chasecam;
			checkBoxDontCheckAmmo.Checked = !Game.Configurations.GameplayOptions.sv_dontcheckammo;
			checkBoxKillBossMonst.Checked = Game.Configurations.GameplayOptions.sv_killbossmonst;
			checkBoxNoCountEndMonst.Checked = !Game.Configurations.GameplayOptions.sv_nocountendmonst;

			#endregion

			#region ============ Deathmatch ============

			checkBoxWeaponsStay.Checked = Game.Configurations.GameplayOptions.sv_weaponstay;
			checkBoxAllowPowerups.Checked = !Game.Configurations.GameplayOptions.sv_noitems;
			checkBoxAllowHealth.Checked = !Game.Configurations.GameplayOptions.sv_nohealth;
			checkBoxAllowArmor.Checked = !Game.Configurations.GameplayOptions.sv_noarmor;
			checkBoxSpawnFarthest.Checked = Game.Configurations.GameplayOptions.sv_spawnfarthest;
			checkBoxSameMap.Checked = Game.Configurations.GameplayOptions.sv_samelevel;
			checkBoxForceRespawn.Checked = Game.Configurations.GameplayOptions.sv_forcerespawn;
			checkBoxAllowExit.Checked = !Game.Configurations.GameplayOptions.sv_noexit;
			checkBoxBarrelsRespawn.Checked = Game.Configurations.GameplayOptions.sv_barrelrespawn;
			checkBoxRespawnProtection.Checked = Game.Configurations.GameplayOptions.sv_respawnprotect;
			checkBoxLoseFrag.Checked = Game.Configurations.GameplayOptions.sv_losefrag;
			checkBoxKeepFrags.Checked = Game.Configurations.GameplayOptions.sv_keepfrag;
			checkBoxNoSwitching.Checked = Game.Configurations.GameplayOptions.sv_noteamswitch;

			#endregion

			#region ============ Cooperative ============

			checkBoxNoWeaponSpawn.Checked = !Game.Configurations.GameplayOptions.sv_noweaponspawn;
			checkBoxLoseInventory.Checked = Game.Configurations.GameplayOptions.sv_cooploseinventory;
			checkBoxKeepKeys.Checked = !Game.Configurations.GameplayOptions.sv_cooplosekeys;
			checkBoxKeepWeapons.Checked = !Game.Configurations.GameplayOptions.sv_cooploseweapons;
			checkBoxKeepArmor.Checked = !Game.Configurations.GameplayOptions.sv_cooplosearmor;
			checkBoxKeepPowerups.Checked = !Game.Configurations.GameplayOptions.sv_cooplosepowerups;
			checkBoxKeepAmmo.Checked = !Game.Configurations.GameplayOptions.sv_cooploseammo;
			checkBoxHalfAmmo.Checked = Game.Configurations.GameplayOptions.sv_coophalveammo;
			checkBoxSameSpawnSpot.Checked = Game.Configurations.GameplayOptions.sv_samespawnspot;

			#endregion
		}

		#endregion

		#region ============ Form code ============

		#region ============ General ============

		private void comboBoxFallingDamage_SelectedIndexChanged (object sender, EventArgs e) {
            Game.Configurations.GameplayOptions.sv_fallingdamage = comboBoxFallingDamage.Text;
        }

        private void checkBoxDoubleAmmo_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.GameplayOptions.sv_doubleammo = checkBoxDoubleAmmo.Checked;
        }

        private void checkBoxDropWeapon_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.GameplayOptions.sv_weapondrop = checkBoxDropWeapon.Checked;
        }

        private void checkBoxInfiniteAmmo_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.GameplayOptions.sv_infiniteammo = checkBoxInfiniteAmmo.Checked;
        }

        private void checkBoxInfiniteInventory_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.GameplayOptions.sv_infiniteinventory = checkBoxInfiniteInventory.Checked;
        }

        private void checkBoxNoMonsters_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.GameplayOptions.sv_nomonsters = checkBoxNoMonsters.Checked;
        }

        private void checkBoxKillAllMonsters_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.GameplayOptions.sv_killallmonsters = checkBoxKillAllMonsters.Checked;
        }

        private void checkBoxMonstersRespawn_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.GameplayOptions.sv_monsterrespawn = checkBoxMonstersRespawn.Checked;
        }

        private void checkBoxNoRespawn_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.GameplayOptions.sv_norespawn = checkBoxNoRespawn.Checked;
        }

        private void checkBoxItemsRespawn_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.GameplayOptions.sv_itemsrespawn = checkBoxItemsRespawn.Checked;
        }

        private void checkBoxRespawnSuper_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.GameplayOptions.sv_respawnsuper = checkBoxRespawnSuper.Checked;
        }

        private void checkBoxFastMonsters_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.GameplayOptions.sv_fastmonsters = checkBoxFastMonsters.Checked;
        }

        private void checkBoxDegeneration_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.GameplayOptions.sv_degeneration = checkBoxDegeneration.Checked;
        }

        private void checkBoxAllowAutoaim_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.GameplayOptions.sv_noautoaim = !checkBoxAllowAutoaim.Checked;
        }

        private void checkBoxAllowSuicide_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.GameplayOptions.sv_disallowsuicide = !checkBoxAllowSuicide.Checked;
        }

        private void checkBoxAllowJump_CheckStateChanged (object sender, EventArgs e) {
            if (checkBoxAllowJump.CheckState == CheckState.Indeterminate)
                Game.Configurations.GameplayOptions.sv_jump = Trilean.Indeterminate;
            else if (checkBoxAllowJump.CheckState == CheckState.Checked)
                Game.Configurations.GameplayOptions.sv_jump = Trilean.True;
            else if (checkBoxAllowJump.CheckState == CheckState.Unchecked)
                Game.Configurations.GameplayOptions.sv_jump = Trilean.False;
        }

        private void checkBoxAllowCrouch_CheckStateChanged (object sender, EventArgs e) {
            if (checkBoxAllowCrouch.CheckState == CheckState.Indeterminate)
                Game.Configurations.GameplayOptions.sv_crouch = Trilean.Indeterminate;
            else if (checkBoxAllowCrouch.CheckState == CheckState.Checked)
                Game.Configurations.GameplayOptions.sv_crouch = Trilean.True;
            else if (checkBoxAllowCrouch.CheckState == CheckState.Unchecked)
                Game.Configurations.GameplayOptions.sv_crouch = Trilean.False;
        }

        private void checkBoxAllowFreelook_CheckStateChanged (object sender, EventArgs e) {
            if (checkBoxAllowFreelook.CheckState == CheckState.Indeterminate)
                Game.Configurations.GameplayOptions.sv_freelook = Trilean.Indeterminate;
            else if (checkBoxAllowFreelook.CheckState == CheckState.Checked)
                Game.Configurations.GameplayOptions.sv_freelook = Trilean.True;
            else if (checkBoxAllowFreelook.CheckState == CheckState.Unchecked)
                Game.Configurations.GameplayOptions.sv_freelook = Trilean.False;
        }

        private void checkBoxAllowFOV_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.GameplayOptions.sv_nofov = !checkBoxAllowFOV.Checked;
        }

        private void checkBoxBFGAiming_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.GameplayOptions.sv_nobfgaim = !checkBoxBFGAiming.Checked;
        }

        private void checkBoxAllowAutomap_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.GameplayOptions.sv_noautomap = !checkBoxAllowAutomap.Checked;
        }

        private void checkBoxAutomapAllies_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.GameplayOptions.sv_noautomapallies = !checkBoxAutomapAllies.Checked;
        }

        private void checkBoxAllowSpying_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.GameplayOptions.sv_disallowspying = !checkBoxAllowSpying.Checked;
        }

        private void checkBoxChasecamCheat_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.GameplayOptions.sv_chasecam = checkBoxChasecamCheat.Checked;
        }

        private void checkBoxDontCheckAmmo_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.GameplayOptions.sv_dontcheckammo = !checkBoxDontCheckAmmo.Checked;
        }

        private void checkBoxKillBossMonst_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.GameplayOptions.sv_killbossmonst = checkBoxKillBossMonst.Checked;
        }

        private void checkBoxNoCountEndMonst_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.GameplayOptions.sv_nocountendmonst = !checkBoxNoCountEndMonst.Checked;
        }

        #endregion

        #region ============ Deathmatch ============

        private void checkBoxWeaponsStay_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.GameplayOptions.sv_weaponstay = checkBoxWeaponsStay.Checked;
        }

        private void checkBoxAllowPowerups_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.GameplayOptions.sv_noitems = !checkBoxAllowPowerups.Checked;
        }

        private void checkBoxAllowHealth_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.GameplayOptions.sv_nohealth = !checkBoxAllowHealth.Checked;
        }

        private void checkBoxAllowArmor_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.GameplayOptions.sv_noarmor = !checkBoxAllowArmor.Checked;
        }

        private void checkBoxSpawnFarthest_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.GameplayOptions.sv_spawnfarthest = checkBoxSpawnFarthest.Checked;
        }

        private void checkBoxSameMap_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.GameplayOptions.sv_samelevel = checkBoxSameMap.Checked;
        }

        private void checkBoxForceRespawn_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.GameplayOptions.sv_forcerespawn = checkBoxForceRespawn.Checked;
        }

        private void checkBoxAllowExit_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.GameplayOptions.sv_noexit = !checkBoxAllowExit.Checked;
        }

        private void checkBoxBarrelsRespawn_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.GameplayOptions.sv_barrelrespawn = checkBoxBarrelsRespawn.Checked;
        }

        private void checkBoxRespawnProtection_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.GameplayOptions.sv_respawnprotect = checkBoxRespawnProtection.Checked;
        }

        private void checkBoxLoseFrag_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.GameplayOptions.sv_losefrag = checkBoxLoseFrag.Checked;
        }

        private void checkBoxKeepFrags_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.GameplayOptions.sv_keepfrag = checkBoxKeepFrags.Checked;
        }

        private void checkBoxNoSwitching_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.GameplayOptions.sv_noteamswitch = checkBoxNoSwitching.Checked;
        }

        #endregion

        #region ============ Cooperative ============

        private void checkBoxNoWeaponSpawn_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.GameplayOptions.sv_noweaponspawn = !checkBoxNoWeaponSpawn.Checked;
        }

        private void checkBoxLoseInventory_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.GameplayOptions.sv_cooploseinventory = checkBoxLoseInventory.Checked;
        }

        private void checkBoxKeepKeys_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.GameplayOptions.sv_cooplosekeys = !checkBoxKeepKeys.Checked;
        }

        private void checkBoxKeepWeapons_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.GameplayOptions.sv_cooploseweapons = !checkBoxKeepWeapons.Checked;
        }

        private void checkBoxKeepArmor_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.GameplayOptions.sv_cooplosearmor = !checkBoxKeepArmor.Checked;
        }

        private void checkBoxKeepPowerups_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.GameplayOptions.sv_cooplosepowerups = !checkBoxKeepPowerups.Checked;
        }

        private void checkBoxKeepAmmo_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.GameplayOptions.sv_cooploseammo = !checkBoxKeepAmmo.Checked;
        }

        private void checkBoxHalfAmmo_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.GameplayOptions.sv_coophalveammo = checkBoxHalfAmmo.Checked;
        }

        private void checkBoxSameSpawnSpot_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.GameplayOptions.sv_samespawnspot = !checkBoxSameSpawnSpot.Checked;
        }

        #endregion

		#endregion
	}
}
