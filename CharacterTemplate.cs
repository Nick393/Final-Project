using System;

public abstract class CharacterTemplate
{

	private string name;

	public string getName()
	{
		return name;
	}

	public string setName(string newName)
    {
		name = newName;
    }
}
