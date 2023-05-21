using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitDropdownSounds : MonoBehaviour
{
	Dropdown dropdown;

	[SerializeField]
	BEProgrammingEnv env;

	void Awake()
	{
		BEBlock thisBlock = GetComponent<BEBlock>();
		thisBlock.InitializeBlock();

		dropdown = thisBlock.BlockHeader.GetChild(thisBlock.userInputIndexes[0]).GetComponent<Dropdown>();
		string targetObject = env.TargetObject.transform.gameObject.GetComponent<SpriteRenderer>().sprite.name;
		
		//populating dropdown
		dropdown.ClearOptions();

		foreach (AudioClip audio in thisBlock.BeController.beSoundsList)
		{
			if (targetObject == "WandaWhale" && audio.name == "Harp")
			{
				dropdown.options.Add(new Dropdown.OptionData(audio.name));
			}
			else if (targetObject == "AmandaPanda" && audio.name == "Erhu")
			{
				dropdown.options.Add(new Dropdown.OptionData(audio.name));
			}
			else if (targetObject == "Caterpillar" && audio.name == "Flute")
			{
				dropdown.options.Add(new Dropdown.OptionData(audio.name));
			}
			else if (targetObject == "HugiHippo" && audio.name == "Bass")
			{
				dropdown.options.Add(new Dropdown.OptionData(audio.name));
			}
			else if (targetObject == "LittleGorrila" && audio.name == "Organ")
			{
				dropdown.options.Add(new Dropdown.OptionData(audio.name));
			}
			else if (targetObject == "Rhino" && audio.name == "Drums")
			{
				dropdown.options.Add(new Dropdown.OptionData(audio.name));
			}
			else if (targetObject == "SamSnake" && audio.name == "Sax")
			{
				dropdown.options.Add(new Dropdown.OptionData(audio.name));
			}
			else if (targetObject == "TinyTiger" && audio.name == "Sitar")
			{
				dropdown.options.Add(new Dropdown.OptionData(audio.name));
			}
			else if (targetObject == "Bottle" && (audio.name == "Bottle-Drop" || audio.name == "Juice-Squeeze"))
			{
				dropdown.options.Add(new Dropdown.OptionData(audio.name));
			}
			else if (targetObject == "Litter" && audio.name == "Paper-Crunch")
			{
				dropdown.options.Add(new Dropdown.OptionData(audio.name));
			}
			else if (targetObject == "RecycleBin" && audio.name == "Bin-Lid-Plastic")
			{
				dropdown.options.Add(new Dropdown.OptionData(audio.name));
			}
			else if (targetObject == "TreePalm" && (audio.name == "Axe-Chop" || audio.name == "Tree-Falling-Down"))
			{
				dropdown.options.Add(new Dropdown.OptionData(audio.name));
			}
			else if (targetObject == "TreeFullyGrown" && audio.name == "Tree-Creak")
			{
				dropdown.options.Add(new Dropdown.OptionData(audio.name));
			}
			else if (targetObject == "WaterButt" && audio.name == "Water-Drops")
			{
				dropdown.options.Add(new Dropdown.OptionData(audio.name));
			}
			else if (targetObject == "WaterDrop" && audio.name == "Water-Drops")
			{
				dropdown.options.Add(new Dropdown.OptionData(audio.name));
			}
		}


		dropdown.RefreshShownValue();
	}
}
