#### How to use

- Firstly, you need to create the Pref ScriptableObjects at `Assets/ScriptableObject/Editor/Prefs` folder. You can find them in the CreatMenu `Prefs>EditorPrefs` and `Prefs>PlayerPrefs`.
- Now you can basically save your prefs to **CustomPlayerPrefs.Instance** or **CustomEditorPrefs.Instance**.

---------------------------------------------------------------------------------------
#### Features

- **ScriptableObjects** does not keep their states between sessions outside of Editor so **CustomPlayerPrefs** falls back to **UnityPlayerPrefs** outside of Editor. **CustomPlayerPrefs** class is there for easy debugging purposes only.
- You can have more than one Pref state with multiple ScriptableObjects. The one with the exact name `PlayerPrefs` or `EditorPrefs` will be used. For example, you can have `PlayerPrefs_TestCase01`, `PlayerPrefs_FinalBossState` etc. ScriptableObjects and rename to switch to certain states of prefs easily.

---------------------------------------------------------------------------------------
#### Screenshots
![](screenshots/image.png)
