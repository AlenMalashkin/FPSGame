using System;
using Code.Data;
using Code.Extensions.DataExtensions;
using UnityEngine;

namespace Code.Services.SaveService
{
	public class SaveService : ISaveService
	{
		public event Action ProgressSaved;
		
		private const string SavePath = "Progress";
		private IPersistentProgressModel _persistentProgressModel;

		public SaveService(IPersistentProgressModel persistentProgressModel)
		{
			_persistentProgressModel = persistentProgressModel;
		}

		public PlayerProgress Load()
			=> PlayerPrefs.GetString(SavePath).FromJson<PlayerProgress>();

		public void Save()
		{
			PlayerPrefs.SetString(SavePath, _persistentProgressModel.Progress.ToJson());
			ProgressSaved?.Invoke();
		}
	}
}