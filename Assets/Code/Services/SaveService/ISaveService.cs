using System;
using Code.Data;

namespace Code.Services.SaveService
{
	public interface ISaveService
	{
		event Action ProgressSaved;
		PlayerProgress Load();
		void Save();
	}
}