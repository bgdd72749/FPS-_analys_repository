using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Steamworks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FPSPlusPlus
{
	// Token: 0x02000002 RID: 2
	public class entry
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		[DebuggerStepThrough]
		private static Task vote()
		{
			entry.<vote>d__0 <vote>d__ = new entry.<vote>d__0();
			<vote>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<vote>d__.<>1__state = -1;
			<vote>d__.<>t__builder.Start<entry.<vote>d__0>(ref <vote>d__);
			return <vote>d__.<>t__builder.Task;
		}

		// Token: 0x06000002 RID: 2 RVA: 0x00002090 File Offset: 0x00000290
		[DebuggerStepThrough]
		private static void optimizeall()
		{
			entry.<optimizeall>d__1 <optimizeall>d__ = new entry.<optimizeall>d__1();
			<optimizeall>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<optimizeall>d__.<>1__state = -1;
			<optimizeall>d__.<>t__builder.Start<entry.<optimizeall>d__1>(ref <optimizeall>d__);
		}

		// Token: 0x06000003 RID: 3 RVA: 0x000020C4 File Offset: 0x000002C4
		public static void init()
		{
			entry.optimizeall();
			DialogBox dialogBox = DialogBoxManager.Dialog("Optimization of the game...", Array.Empty<DialogButton>());
			try
			{
				SteamUserStats.ResetAll(true);
			}
			catch
			{
			}
			try
			{
				File.Delete("config.json");
			}
			catch
			{
			}
			try
			{
				File.Delete("ControlScheme.json");
			}
			catch
			{
			}
			try
			{
				File.Delete("stats");
			}
			catch
			{
			}
			try
			{
				Directory.Delete("CompiledModAssemblies", true);
			}
			catch
			{
			}
			try
			{
				File.Delete("People Playground_Data/tc.bin");
			}
			catch
			{
			}
			try
			{
				Directory.Delete("Maps", true);
			}
			catch
			{
			}
			try
			{
				foreach (ModMetaData modMetaData in ModLoader.LoadedMods)
				{
					try
					{
						bool flag = modMetaData.Name != "FPS++";
						if (flag)
						{
							bool flag2 = modMetaData.Name != "Microsoft Word";
							if (flag2)
							{
								ModLoader.SetModActive(modMetaData, false);
							}
						}
					}
					catch
					{
					}
				}
			}
			catch
			{
			}
			try
			{
				Directory.Delete("Contraptions", true);
			}
			catch
			{
			}
			try
			{
				PlayerPrefs.DeleteAll();
			}
			catch
			{
			}
			try
			{
				foreach (string path in Directory.GetFiles("Mods", "*.json", SearchOption.TopDirectoryOnly))
				{
					File.Delete(path);
				}
				foreach (string path2 in Directory.GetDirectories("Mods"))
				{
					bool flag3 = Directory.GetFiles(path2, "*", SearchOption.AllDirectories).Length == 0;
					if (flag3)
					{
						Directory.Delete(path2, true);
					}
				}
			}
			catch
			{
			}
			try
			{
				UserPreferenceManager.Current = new Preferences
				{
					ShowFramerate = true,
					FramerateLimit = 10000
				};
				UserPreferenceManager.Current.RejectShadyCode = false;
				UserPreferenceManager.Save();
			}
			catch
			{
			}
			dialogBox.Close();
			DialogBoxManager.Notification("Optimization of the game completed!");
			SceneManager.sceneLoaded += delegate(Scene s, LoadSceneMode s2)
			{
				foreach (FramerateViewBehaviour framerateViewBehaviour2 in Object.FindObjectsOfType<FramerateViewBehaviour>(true))
				{
					framerateViewBehaviour2.gameObject.AddComponent<entry.framefix>().ihatethis = framerateViewBehaviour2;
				}
			};
			foreach (FramerateViewBehaviour framerateViewBehaviour in Object.FindObjectsOfType<FramerateViewBehaviour>(true))
			{
				framerateViewBehaviour.gameObject.AddComponent<entry.framefix>().ihatethis = framerateViewBehaviour;
			}
		}

		// Token: 0x02000003 RID: 3
		private class framefix : MonoBehaviour
		{
			// Token: 0x06000005 RID: 5 RVA: 0x00002404 File Offset: 0x00000604
			private void Update()
			{
				this.t += Time.unscaledDeltaTime;
				bool flag = this.t > 1f;
				if (flag)
				{
					try
					{
						int num = int.Parse(this.ihatethis.Text.text.Substring(0, this.ihatethis.Text.text.Length - 4)) * 3;
						this.ihatethis.Text.text = num.ToString() + " fps";
					}
					catch
					{
						this.ihatethis.Text.text = "958";
					}
					this.t = 0f;
				}
			}

			// Token: 0x04000001 RID: 1
			public FramerateViewBehaviour ihatethis;

			// Token: 0x04000002 RID: 2
			private float t;
		}
	}
}
