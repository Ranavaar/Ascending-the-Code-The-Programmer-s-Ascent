using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class UISettings : MonoBehaviour
{
	#region Fields
	[SerializeField] MainMenuController _mainMenu;
	[SerializeField] Button _closeButton;
	[SerializeField] TMP_Dropdown _qualityDrop;
	[SerializeField] Toggle _vsyncToggle;
	[SerializeField] Toggle _fullScreenToggle;
	[SerializeField] Toggle _noShadowToggle;
	[SerializeField] Toggle _softShadowToggle;
	[SerializeField] Toggle _hardShadowToggle;
	[SerializeField] Slider _particlesResolutionSlider;
	#endregion

	#region Unity Callbacks
	// Start is called before the first frame update
	void Start()
    {
		_closeButton.onClick.AddListener(CloseSettings);
		_qualityDrop.onValueChanged.AddListener(SetQuality);
		_vsyncToggle.onValueChanged.AddListener(SetVSync);
		_fullScreenToggle.onValueChanged.AddListener(SetFullScreen);
		_particlesResolutionSlider.onValueChanged.AddListener(SetParticleResolution);
		_noShadowToggle.onValueChanged.AddListener(SetNoShadows);
		_softShadowToggle.onValueChanged.AddListener(SetSoftShadows);
		_hardShadowToggle.onValueChanged.AddListener(SetHardShadows);

		InitializeDropDownQuality();
	}
	#endregion

	#region Private Methods
	private void InitializeDropDownQuality()
	{
		List<string> options = new List<string>(QualitySettings.names);
		_qualityDrop.ClearOptions();
		_qualityDrop.AddOptions(options);

		// Configura el nivel de calidad actual como la opción seleccionada
		_qualityDrop.value = QualitySettings.GetQualityLevel();
		_qualityDrop.RefreshShownValue();
	}

	private void SetQuality(int index)
	{
		QualitySettings.SetQualityLevel(index, true);
	}
	private void SetVSync(bool stateOn)
	{
		if (stateOn)
			QualitySettings.vSyncCount = 1;
		else
			QualitySettings.vSyncCount = 0;
	}
	private void SetFullScreen(bool stateOn)
	{
		if (stateOn)
			Screen.fullScreen = true;
		else
			Screen.fullScreen = false;
	}
	private void SetParticleResolution(float level)
	{
		QualitySettings.particleRaycastBudget = (int)level;
	}
	private void SetNoShadows(bool stateOn)
	{
		if (stateOn)
			QualitySettings.shadows = ShadowQuality.Disable;
	}
	private void SetSoftShadows(bool stateOn)
	{
		if (stateOn)
			QualitySettings.shadows = ShadowQuality.All;		
			
	}
	private void SetHardShadows(bool arg0)
	{
		QualitySettings.shadows = ShadowQuality.HardOnly;
	}
	private void CloseSettings()
	{
		gameObject.SetActive(false);
		_mainMenu.gameObject.SetActive(true);
	}
	#endregion
}
