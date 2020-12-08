using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.GameObjects
{
	static class UUIDGenerator
	{
		private static uint currentId = 1u;

		public static uint GetNewId()
		{
			uint newId = UUIDGenerator.currentId;
			UUIDGenerator.currentId++;
			return newId;
		}
	}
}
