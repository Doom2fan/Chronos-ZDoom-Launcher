using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Diagnostics;
using IniParser;
using IniParser.Parser;
using IniParser.Model.Configuration;
using IniParser.Model;

namespace Launcher {
	public class iniParserConfiguration : BaseIniParserConfiguration {
		public iniParserConfiguration () {
			CommentString = "#";
			SectionStartChar = '[';
			SectionEndChar = ']';
			KeyValueAssigmentChar = '=';
			AssigmentSpacer = " ";
			AllowKeysWithoutSection = true;
			AllowDuplicateKeys = false;
			AllowDuplicateSections = false;
			ThrowExceptionsOnError = true;
			SkipInvalidLines = false;
		}
	}

	public class Config {
		iniParserConfiguration parserConfig = new iniParserConfiguration ();
		FileIniDataParser dataParser = new FileIniDataParser ();
		IniData parsedData = new IniData ();

		
		public Config () {
		}

		public string ProgramPath = Path.GetDirectoryName (Assembly.GetExecutingAssembly ().Location);
		public string CFGFilePath = Path.GetDirectoryName (Assembly.GetExecutingAssembly ().Location) + "\\Config\\";
		public string PatchesPath = Path.GetDirectoryName (Assembly.GetExecutingAssembly ().Location) + "\\Patches\\";
		public string ConfigName = "Default";

		// Paths
		public class PathConfigs {
			public string IWADPath = string.Empty;
			public string DisPath = string.Empty;
			public string FDPath = string.Empty;
		}
		public PathConfigs Paths = new PathConfigs ();

		// Basic
		public class BasicConfigs {
			public string IWAD = string.Empty;
			public bool NoSkill = true;
			public short Skill = 0;
			public bool MapNameOn = false;
			public short MapNumber = 0;
			public string MapName = string.Empty;
			public bool ClassNumberOn = false;
			public short ClassNumber = 0;
			public string ClassName = string.Empty;
		}
		public BasicConfigs Basic = new BasicConfigs ();

		// Multiplayer
		public class MultiplayerConfigs {
			public bool MultiplayerOn = false;
			public int MPPort = 5029;
			// Joining
			public bool MPJoining = false;
			public string MPHostname = string.Empty;
			// Hosting
			public short MPPlayers = 1;
			public bool Netmode = false;
			public bool ExtraTics = false;
			public short MPDup = 0;
			public bool altdeath = false;
			public bool Deathmatch = false;
		}
		public MultiplayerConfigs Multiplayer = new MultiplayerConfigs ();

		// Advanced
		public class AdvancedConfigs {
			public bool sv_cheats = false;
			public bool LogToFile = false;
			public string CustomCommands = string.Empty;
		}
		public AdvancedConfigs Advanced = new AdvancedConfigs ();

		// Gameplay options
		public class GameplayOptionsClass {
			public bool teamplay = false;
			public string sv_fallingdamage = string.Empty;
			public bool sv_weapondrop = false;
			public bool sv_doubleammo = false;
			public bool sv_infiniteammo = false;
			public bool sv_infiniteinventory = false;
			public bool sv_nomonsters = false;
			public bool sv_killallmonsters = false;
			public bool sv_monsterrespawn = false;
			public bool sv_norespawn = false;
			public bool sv_itemsrespawn = false;
			public bool sv_respawnsuper = false;
			public bool sv_fastmonsters = false;
			public bool sv_degeneration = false;
			public bool sv_noautoaim = false;
			public bool sv_disallowsuicide = false;
			public Trilean sv_jump = Trilean.Indeterminate;
			public Trilean sv_crouch = Trilean.Indeterminate;
			public Trilean sv_freelook = Trilean.Indeterminate;
			public bool sv_nofov = false;
			public bool sv_nobfgaim = false;
			public bool sv_noautomap = false;
			public bool sv_noautomapallies = false;
			public bool sv_disallowspying = false;
			public bool sv_chasecam = false;
			public bool sv_dontcheckammo = false;
			public bool sv_killbossmonst = false;
			public bool sv_nocountendmonst = false;
			// Deathmatch
			public bool sv_weaponstay = false;
			public bool sv_noitems = false;
			public bool sv_noarmor = false;
			public bool sv_nohealth = false;
			public bool sv_spawnfarthest = false;
			public bool sv_samelevel = false;
			public bool sv_forcerespawn = false;
			public bool sv_noexit = false;
			public bool sv_barrelrespawn = false;
			public bool sv_respawnprotect = false;
			public bool sv_losefrag = false;
			public bool sv_keepfrag = false;
			public bool sv_noteamswitch = false;
			// Cooperative
			public bool sv_noweaponspawn = false;
			public bool sv_cooploseinventory = false;
			public bool sv_cooplosekeys = false;
			public bool sv_cooploseweapons = false;
			public bool sv_cooplosearmor = false;
			public bool sv_cooplosepowerups = false;
			public bool sv_cooploseammo = false;
			public bool sv_coophalveammo = false;
			public bool sv_samespawnspot = false;
		}
		public GameplayOptionsClass GameplayOptions = new GameplayOptionsClass ();

		// Mods
		public List<string> ModList = new List<string> ();

		public List<string> patchesList = new List<string> ();

		/*public void Save () {
			List<string> FileData = new List<string> ();

			FileData.Add ("[Paths]");
			FileData.Add ("DisPath = \"" + DisPath + "\";");
			FileData.Add ("IWADPath = \"" + IWADPath + "\";");
			FileData.Add ("FDPath = \"" + FDPath + "\";");
			FileData.Add ("");
			FileData.Add ("[Basic]");
			FileData.Add ("IWAD = \"" + IWAD + "\"");
			FileData.Add ("Skill = \"" + Skill + "\";");
			FileData.Add ("NoSkill = \"" + NoSkill + "\";");
			FileData.Add ("MapNameOn = \"" + MapNameOn + "\";");
			FileData.Add ("MapNumber = \"" + MapNumber + "\";");
			FileData.Add ("MapName = \"" + MapName + "\";");
			FileData.Add ("ClassNumberOn = \"" + ClassNumberOn + "\";");
			FileData.Add ("ClassNumber = \"" + ClassNumber + "\";");
			FileData.Add ("ClassName = \"" + ClassName + "\";");
			FileData.Add ("");
			FileData.Add ("[Multiplayer");
			FileData.Add ("MultiplayerOn = \"" + MultiplayerOn + "\";");
			FileData.Add ("MPPort = \"" + MPPort + "\";");
			FileData.Add ("MPJoining = \"" + MPJoining + "\";");
			FileData.Add ("MPHostname = \"" + MPHostname + "\";");
			FileData.Add ("MPPlayers = \"" + MPPlayers + "\";");
			FileData.Add ("Netmode = \"" + Netmode + "\";");
			FileData.Add ("ExtraTics = \"" + ExtraTics + "\";");
			FileData.Add ("MPDup = \"" + MPDup + "\";");
			FileData.Add ("Altdeath = \"" + altdeath + "\";");
			FileData.Add ("Deathmatch = \"" + Deathmatch + "\";");
			FileData.Add ("");
			FileData.Add ("[Mods]");

			if (ModList.Count > 0) {
				FileData.Add ("ModList = {");
				foreach (string line in ModList) {
					FileData.Add ("\"" + line + "\"");
				}
				FileData.Add ("};");
			}

			FileData.Add ("");
			FileData.Add ("[Advanced]");
			FileData.Add ("LogToFile = \"" + LogToFile + "\";");
			FileData.Add ("sv_cheats = \"" + sv_cheats + "\";");
			FileData.Add ("CustomCommands = \"" + CustomCommands + "\";");
			FileData.Add ("");
			FileData.Add ("[Gameplay Settings]");

			File.Delete (CFGFilePath);
			File.WriteAllLines (CFGFilePath, FileData);
		}*/

		public void Save2 (string path, string file) {
			List<string> data = new List<string> ();
			List<string> data2 = new List<string> ();
			
			try {
				if (!Directory.Exists (path))
					Directory.CreateDirectory (path);

				foreach (FieldInfo field in this.Paths.GetType ().GetFields ())
					parsedData ["Paths"] [field.Name] = field.GetValue (this).ToString ();

				foreach (FieldInfo field in this.Basic.GetType ().GetFields ())
					parsedData ["Basic"] [field.Name] = field.GetValue (this).ToString ();

				foreach (FieldInfo field in this.Multiplayer.GetType ().GetFields ())
					parsedData ["Multiplayer"] [field.Name] = field.GetValue (this).ToString ();

				foreach (FieldInfo field in this.Advanced.GetType ().GetFields ())
					parsedData ["Advanced"] [field.Name] = field.GetValue (this).ToString ();

				foreach (FieldInfo field in this.GameplayOptions.GetType ().GetFields ())
					parsedData ["GameplayOptions"] [field.Name] = field.GetValue (this).ToString ();

				foreach (string mod in ModList)
					parsedData ["Modlist"] [Path.GetFileName (mod)] = mod;
				
				File.WriteAllLines (path + file + ".cfg", data);
			} catch (Exception e) {
				Utils.ShowError (e);
			}
		}

		public void Save (string file) {
			Save2 (CFGFilePath, file);
		}

		public void Load (string file) {
			try {
				if (!File.Exists (CFGFilePath + file + ".txt"))
					dataParser.WriteFile (CFGFilePath + file + ".txt", parsedData);

				parsedData = dataParser.ReadFile (CFGFilePath + file + ".txt");
			} catch (Exception e) {
				Utils.ShowError (e);
			}
		}

		/*public void Load () {
			if (!File.Exists (CFGFilePath))
				return;
			string[] FileData = File.ReadAllLines (CFGFilePath);
			bool ParsingModList = false;
			List<string> NewModList = new List<string> ();
			foreach (string line in FileData) {
				if (ParsingModList) {
					if (line.Equals ("};")) {
						ModList.AddRange (NewModList);
						ParsingModList = false;
						continue;
					}

					NewModList.Add (line.Trim ('"'));
				} else {
					if ((line.StartsWith ("[") && line.EndsWith ("]")) || line.Equals (""))
						continue;
					string[] s = line.Split ('=');
					if (s.Count () < 2)
						continue;

					s[0] = s[0].Trim ();
					s[1] = s[1].Trim ();
					s[1] = s[1].Remove (s[1].Count () - 1);
					s[1] = s[1].Trim ('"');

					// Paths
					if (s[0].Equals ("DisPath"))
						DisPath = s[1];
					if (s[0].Equals ("IWADPath"))
						IWADPath = s[1];
					if (s[0].Equals ("FDPath"))
						FDPath = s[1];
					// Basic
					if (s[0].Equals ("IWAD"))
						IWAD = s[1];
					if (s[0].Equals ("Skill"))
						Skill = Convert.ToInt16 (s[1]);
					if (s[0].Equals ("NoSkill"))
						NoSkill = Convert.ToBoolean (s[1]);
					if (s[0].Equals ("MapNameOn"))
						MapNameOn = Convert.ToBoolean (s[1]);
					if (s[0].Equals ("MapNumber"))
						MapNumber = Convert.ToInt16 (s[1]);
					if (s[0].Equals ("MapName"))
						MapName = s[1];
					if (s[0].Equals ("ClassNumberOn"))
						ClassNumberOn = Convert.ToBoolean (s[1]);
					if (s[0].Equals ("ClassNumber"))
						ClassNumber = Convert.ToInt16 (s[1]);
					if (s[0].Equals ("ClassName"))
						ClassName = s[1];
					// Multiplayer
					if (s[0].Equals ("MultiplayerOn"))
						MultiplayerOn = Convert.ToBoolean (s[1]);
					if (s[0].Equals ("MPPort"))
						MPPort = Convert.ToInt32 (s[1]);
					if (s[0].Equals ("MPJoining"))
						MPJoining = Convert.ToBoolean (s[1]);
					if (s[0].Equals ("MPHostname"))
						MPHostname = s[1];
					if (s[0].Equals ("MPPlayers"))
						MPPlayers = Convert.ToInt16 (s[1]);
					if (s[0].Equals ("Netmode"))
						Netmode = Convert.ToBoolean (s[1]);
					if (s[0].Equals ("ExtraTics"))
						ExtraTics = Convert.ToBoolean (s[1]);
					if (s[0].Equals ("MPDup"))
						MPDup = Convert.ToInt16 (s[1]);
					if (s[0].Equals ("Altdeath"))
						altdeath = Convert.ToBoolean (s[1]);
					if (s[0].Equals ("Deathmatch"))
						Deathmatch = Convert.ToBoolean (s[1]);
					// Mods
					if (s[0].Equals ("ModList"))
						ParsingModList = true;
					// Advanced
					if (s[0].Equals ("sv_cheats"))
						sv_cheats = Convert.ToBoolean (s[1]);
					if (s[0].Equals ("CustomCommands"))
						CustomCommands = s[1];
				}
			}
		}*/
	}
}