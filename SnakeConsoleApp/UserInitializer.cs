using System;

public static class UserInitializer
{
	public static List<User> GetSampleUserData()
	{
		List<User> users = new List<User>();

		users.Add(new User { Name = "Middle Player", Score = 123});
		users.Add(new User { Name = "Professional Player", Score = 500 });
		users.Add(new User { Name = "Simple Player", Score = 5 });
		users.Add(new User { Name = "Low Player", Score = 1 });

		return users;
	}
}
