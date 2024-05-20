using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExcelAsset]
public class StageDB : ScriptableObject
{
	public List<StageDBEntity> StageDBEntities; // Replace 'EntityType' to an actual type that is serializable.
}
