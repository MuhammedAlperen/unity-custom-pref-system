#### How to use

- Firstly, you need to create the Pref ScriptableObjects at `Assets/ScriptableObject/Editor/Prefs` folder. You can find them in the CreatMenu `Prefs>EditorPrefs` and `Prefs>PlayerPrefs`.
- Now you can basically save your prefs to **CustomPlayerPrefs.Instance** or **CustomEditorPrefs.Instance**.

---------------------------------------------------------------------------------------
#### Features

- **ScriptableObjects** does not keep their states between sessions outside of Editor so **CustomPlayerPrefs** falls back to **UnityPlayerPrefs** outside of Editor. **CustomPlayerPrefs** class is there for easy debugging purposes only.
- You can have more than one Pref state with multiple ScriptableObjects. The one with the exact name `PlayerPrefs` or `EditorPrefs` will be used. For example, you can have `PlayerPrefs_TestCase01`, `PlayerPrefs_FinalBossState` etc. ScriptableObjects and rename to switch to certain states of prefs easily.

---------------------------------------------------------------------------------------
#### Planned Features

- Getters of the prefs default to 0's or empty string if the pref is not found. Changing the CustomPlayerPrefs to provide default values to UnityPlayerPrefs can allow editing default values outside of code. But if CustomPlayerPrefs is actively used in editor, this might not work as intended so this needs to be addressed first.
- Might add an easier way to switch Prefs than renaming the files.

---------------------------------------------------------------------------------------
#### Screenshots
![](screenshots/image.png)
