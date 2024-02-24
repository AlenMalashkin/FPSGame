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
		private IProgressModel _progressModel;

		public SaveService(IProgressModel progressModel)
		{
			_progressModel = progressModel;
		}

		public PlayerProgress Load()
			=> PlayerPrefs.GetString(SavePath).FromJson<PlayerProgress>();

		public void Save()
		{
			PlayerPrefs.SetString(SavePath, _progressModel.Progress.ToJson());
			ProgressSaved?.Invoke();
		}
	}
}